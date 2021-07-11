using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeededSeasoningChoiser : MonoBehaviour
{
    [SerializeField] private SeasoningLooker _seasoningLooker;
    [SerializeField] private CookingItemType[] _cookingItemTypes;

    public bool TryGetNewItemType(out CookingItemType cookingItemType)
    {
        if (_seasoningLooker.GetExistSeasoningType() == null)
        {
            cookingItemType = _cookingItemTypes[Random.Range(0, _cookingItemTypes.Length)];
            return true;
        }
        
        CookingItemType[] cookingItemTypes = _cookingItemTypes.Except(_seasoningLooker.GetExistSeasoningType()).ToArray();

        if (cookingItemTypes.Length == 0)
        {
            cookingItemType = CookingItemType.Base;
            return false;
        }
        else
        {
            cookingItemType = cookingItemTypes[Random.Range(0, cookingItemTypes.Length)];
            return true;
        }
    }
}
