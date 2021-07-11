using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeasoningSpawner : Spawner
{
    [SerializeField] private Seasoning[] _seasonings;
    private Vector3 _previousSpawnPosition;

    public override CookingItemType Spawn()
    {
        var newSeasoning = Instantiate(_seasonings[Random.Range(0, _seasonings.Length)]);
        newSeasoning.transform.position = GetUnicPosition();
        Spawned?.Invoke(newSeasoning.gameObject);
        return newSeasoning.ItemType;
    }

    public override CookingItemType Spawn(CookingItemType cookingItemType)
    {
        Seasoning seasoning = _seasonings.First(s => s.ItemType == cookingItemType);
        var newSeasoning = Instantiate(seasoning);
        newSeasoning.transform.position = GetUnicPosition();
        Spawned?.Invoke(newSeasoning.gameObject);
        return newSeasoning.ItemType;
    }

    public override List<CookingItemType> GetCookingTypes()
    {
        List<CookingItemType> itemTypes = new List<CookingItemType>();
        foreach (var seasoning in _seasonings)
        {
            itemTypes.Add(seasoning.ItemType);
        }

        return itemTypes;
    }

    private Vector3 GetUnicPosition()
    {
        Vector3 position = new Vector3();

        do
        {
            position = GetPosition();
        } while (position == _previousSpawnPosition);

        _previousSpawnPosition = position;

        return position;
    }
}
