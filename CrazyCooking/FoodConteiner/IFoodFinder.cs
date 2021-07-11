using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFoodFinder
{
    bool TryGetFood(out Food food);

    public int GetFoodAmount();
}
