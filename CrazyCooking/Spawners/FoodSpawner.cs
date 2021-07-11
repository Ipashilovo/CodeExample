using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodSpawner : Spawner
{
    [SerializeField] private Food[] _foods;
    
    public override CookingItemType Spawn()
    {
        var newFood = Instantiate(_foods[Random.Range(0, _foods.Length)]);
        newFood.transform.position = GetPosition();
        Spawned?.Invoke(newFood.gameObject);
        return newFood.ItemType;
    }

    public override CookingItemType Spawn(CookingItemType cookingItemType)
    {
        var newFood = _foods.First(f => f.ItemType == cookingItemType);
        newFood.transform.position = GetPosition();
        Spawned?.Invoke(newFood.gameObject);
        return newFood.ItemType;
    }

    public override List<CookingItemType> GetCookingTypes()
    {
        List<CookingItemType> itemTypes = new List<CookingItemType>();
        foreach (var food in _foods)
        {
            itemTypes.Add(food.ItemType);
        }

        return itemTypes;
    }
}
