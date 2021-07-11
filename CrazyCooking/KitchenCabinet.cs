using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCabinet : StorageBox
{
    [SerializeField] private NeededSeasoningChoiser _neededSeasoningChoiser;
    protected void OnTriggerEnter(Collider other)
    {
        if (_neededSeasoningChoiser.TryGetNewItemType(out CookingItemType cookingItemType) && other.TryGetComponent(out Leg leg))
        {
            Spawn(cookingItemType);
            GenerateAction();
        }
    }
}
