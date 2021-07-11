using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    [SerializeField] private CookingAction _puttingOnBoard;
    [SerializeField] private CookingAction _cutting;
    private FoodsConteiner _foonOnBoard;
    private FoodsConteiner _cuttingFood;

    private void Awake()
    {
        _foonOnBoard = new FoodsConteiner();
        _cuttingFood = new FoodsConteiner();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out FoodCollisionHandler foodComponent))
        {
            Food food = foodComponent.Food;
            if (food.CutingState == FoodState.NoSlicing)
            {
                food.SetSlicining();
                _foonOnBoard.Add(food);
                food.CutEnded += OnFoodFinishedCutting;
                ActionCommand command = new ActionCommand(_puttingOnBoard, food.ItemType);
                EventsLooker.ActionDone?.Invoke(command);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out FoodCollisionHandler foodComponent))
        {
            Food food = foodComponent.Food;
            if (food.CutingState == FoodState.NoSlicing)
            {
                food.RemoveSlicining();
                _foonOnBoard.Remove(food);
                food.CutEnded -= OnFoodFinishedCutting;
            }
        }
    }

    private void OnFoodFinishedCutting(Food food)
    {
        food.CutEnded -= OnFoodFinishedCutting;
        ActionCommand command = new ActionCommand(_cutting, food.ItemType);
        EventsLooker.ActionDone?.Invoke(command);
        _foonOnBoard.Remove(food);
        _cuttingFood.Add(food);
    }

    public IFoodFinder GetFinder()
    {
        return _foonOnBoard;
    }

    public IFoodFinder GetFinishCuttingFinder()
    {
        return _cuttingFood;
    }
}
