using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Food : MonoBehaviour
{
    [FormerlySerializedAs("_cookingItemType")] [SerializeField] private CookingItemType _itemType;
    [SerializeField] private FoodCollisionHandler _foodCollisionHandler;

    public CookingItemType ItemType => _itemType;
    public FoodState CutingState { get; private set; }
    public float SlicingСondition { get; private set; }

    public event Action<Food> Destroing;

    public event Action<Food> CutEnded;

    private void OnEnable()
    {
        Follow();
    }

    private void OnDisable()
    {
        Unfollow();
    }

    private void OnDestroy()
    {
        Destroing?.Invoke(this);
    }

    private void Awake()
    {
        CutingState = FoodState.NoSlicing;
    }

    public void SetNewFoodCollisionHandler(FoodCollisionHandler foodCollisionHandler)
    {
        Unfollow();
        _foodCollisionHandler = foodCollisionHandler;
        Follow();
    }
    
    public void SetSlicining()
    {
        if (CutingState != FoodState.FinishSlicing)
            CutingState = FoodState.Slicining;
    }

    public void RemoveSlicining()
    {
        if (CutingState != FoodState.FinishSlicing)
            CutingState = FoodState.NoSlicing;
    }

    private void OnSlicing()
    {
        if (CutingState != FoodState.Slicining)
        {
            return;
        }

        float slicingSpeed = 1f;
        SlicingСondition += slicingSpeed * Time.deltaTime;
        if (SlicingСondition > 1)
        {
            SlicingСondition = 1;
            CutingState = FoodState.FinishSlicing;
            CutEnded?.Invoke(this);
        }
    }

    private void OnFoodModelDestroing()
    {
        Destroy(this);
    }

    private void Follow()
    {
        _foodCollisionHandler.Destroing += OnFoodModelDestroing;
        _foodCollisionHandler.Slising += OnSlicing;
    }

    private void Unfollow()
    {
        _foodCollisionHandler.Destroing -= OnFoodModelDestroing;
        _foodCollisionHandler.Slising -= OnSlicing;
    }
}
