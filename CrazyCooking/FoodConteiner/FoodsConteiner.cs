using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodsConteiner : FoodConteiner, IFoodFinder
{
    private FoodConteinerByType[] _conteiners = new FoodConteinerByType[3]
    {
        new FoodConteinerByType(CookingItemType.Carrot),
        new FoodConteinerByType(CookingItemType.Fish),
        new FoodConteinerByType(CookingItemType.Eggplant)
    };

    private List<Food> _foods;

    public FoodsConteiner()
    {
        _foods = new List<Food>();
    }
    
    public override void Add(Food food)
    {
        foreach (var conteiner in _conteiners)
        {
            if (conteiner._cookingItemType == food.ItemType)
            {
                conteiner.Add(food);
                return;
            }
        }
    }

    public override void Remove(Food food)
    {
        foreach (var conteiner in _conteiners)
        {
            if (conteiner._cookingItemType == food.ItemType)
            {
                conteiner.Remove(food);
                return;
            }
        }
    }

    public override bool TryGetFood(out Food food)
    {
        _foods = new List<Food>();
        foreach (var conteiner in _conteiners)
        {
            if (conteiner.TryGetFood(out Food newFood))
            {
                _foods.Add(newFood);
            }
        }

        if (_foods.Count > 0)
        {
            food = _foods[Random.Range(0, _foods.Count)];
            return true;
        }
        
        

        food = null;
        return false;
    }

    public override int GetFoodAmount()
    {
        int value = 0;
        foreach (var VARIABLE in _conteiners)
        {
            value += VARIABLE.GetFoodAmount();
        }

        return value;
    }
}
