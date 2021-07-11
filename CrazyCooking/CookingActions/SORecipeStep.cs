using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SORecipeStep", menuName = "ScriptableObjects/SORecipeStep", order = 1)]
public class SORecipeStep : ScriptableObject
{
    [SerializeField] private CookingItemType _cookingItemType;
    [SerializeField] private CookingAction _cookingAction;

    public ActionCommand GetActionCommand()
    {
        ActionCommand command = new ActionCommand(_cookingAction, _cookingItemType);
        return command;
    }
}