using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FoodConteiner
{
    public abstract void Add(Food food);

    public abstract void Remove(Food food);

    public abstract bool TryGetFood(out Food food);
    public abstract int GetFoodAmount();

    public Action<Food> FoodStateChanged;
}
