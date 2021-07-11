using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliсingFoodModelSetter : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private FoodCollisionHandler _oldFoodModel;
    [SerializeField] private CutObjVisualize _cutObjVisualize;
    [SerializeField] private float _newModelScale;
    [SerializeField] private Vector3 _distanceByOldModel;

    private void OnEnable()
    {
        _food.CutEnded += SetNewModel;
    }

    private void OnDisable()
    {
        _food.CutEnded -= SetNewModel;
    }

    private void Start()
    {
        _cutObjVisualize.SetCollisionHandler(_oldFoodModel);
        _cutObjVisualize.enabled = true;
    }

    private void SetNewModel(Food food)
    {
        Quaternion rotation = _oldFoodModel.transform.rotation;
        Vector3 position = _oldFoodModel.transform.position + _distanceByOldModel;
        var resourceModel = Resources.Load<FoodCollisionHandler>(SlicinfFoodNamesByType.GetInemName(food.ItemType));
        _oldFoodModel.gameObject.SetActive(false);
        
        FoodCollisionHandler newModel = Instantiate(resourceModel, position, rotation, _food.transform);
        newModel.transform.localScale = newModel.transform.localScale * _newModelScale;
        newModel.Init(_food);

        if (newModel == null)
        {
            throw new NullReferenceException(this.name);
        }

        _cutObjVisualize.SetCollisionHandler(newModel);
        _food.SetNewFoodCollisionHandler(newModel);
    }
}
