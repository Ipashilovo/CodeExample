using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeasoningLooker : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private List<Seasoning> _seasonings = new List<Seasoning>();

    private void OnEnable()
    {
        _spawner.Spawned += TryAdd;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= TryAdd;
    }

    private void TryAdd(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Seasoning seasoning))
        {
            _seasonings.Add(seasoning);
        }
    }

    public bool TryGetCommand(out ActionCommand command)
    {
        int count = _seasonings.Count;
        if (count > 0)
        {
            command = new ActionCommand(CookingAction.Seasoning, _seasonings[Random.Range(0, count)].ItemType);
            return true;
        }
        
        command = null;
        return false;
    }

    public int GetSeasoningCount()
    {
        return _seasonings.Count;
    }

    public CookingItemType[] GetExistSeasoningType()
    {
        CookingItemType[] cookingItemTypes = new CookingItemType[_seasonings.Count];
        for (int i = 0; i < _seasonings.Count; i++)
        {
            cookingItemTypes[i] = _seasonings[i].ItemType;
        }

        return cookingItemTypes;
    }
}
