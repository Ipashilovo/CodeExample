using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodConteinerByType : FoodConteiner
{
    public CookingItemType _cookingItemType { get; }
    private List<Food> _foods;
    
    public FoodConteinerByType(CookingItemType cookingItem)
    {
        _cookingItemType = cookingItem;
        _foods = new List<Food>();
    }

    public override void Add(Food food)
    {
        _foods.Add(food);
        food.Destroing += Remove;
    }

    public override void Remove(Food food)
    {
        food.Destroing -= Remove;
        _foods.Remove(food);
    }

    public override bool TryGetFood(out Food food)
    {
        if (_foods.Count > 0)
        {
            food  = _foods[0];
            return true;
        }

        food = null;
        return false;
    }

    public override int GetFoodAmount()
    {
        return _foods.Count;
    }
}
