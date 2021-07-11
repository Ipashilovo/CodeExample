using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOInteractibleItem", menuName = "ScriptableObjects/SOInteractibleItem", order = 1)]
public class SOInteractibleItem : ScriptableObject
{
    [SerializeField] private CookingItemType _cookingItemType;
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite => _sprite;
    public CookingItemType CookingItemType => _cookingItemType;

}
