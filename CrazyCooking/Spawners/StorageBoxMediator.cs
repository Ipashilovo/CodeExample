using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StorageBoxMediator : MonoBehaviour
{
    [SerializeField] private StorageBox _storageBox;
    [SerializeField] private CookingLooker _cookingLooker;

    public bool TryGetCurrentItemType(List<CookingItemType> typesInStorageBox, out CookingItemType cookingItemType)
    {
        CookingItemType itemType = _cookingLooker.CurrentCommand.CookingItem;
        if (typesInStorageBox.Any(item => item == itemType))
        {
            cookingItemType = itemType;
            return true;
        }
        else
        {
            cookingItemType = default;
            return false;
        }
    }
}
