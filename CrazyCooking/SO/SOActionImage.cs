using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOActionImages", menuName = "ScriptableObjects/SOActionImages", order = 1)]
public class SOActionImage : ScriptableObject
{
    [SerializeField] private CookingAction _action;
    [SerializeField] private Sprite _interactibleItem;
    [SerializeField] private Sprite _actionSprite;

    public Sprite InteractibleWith => _interactibleItem;
    public Sprite ActionImage => _actionSprite;
    public CookingAction Action => _action;
}
