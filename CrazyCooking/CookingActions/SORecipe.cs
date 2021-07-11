using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SORecipe", menuName = "ScriptableObjects/SORecipe", order = 1)]
public class SORecipe : ScriptableObject
{
    [SerializeField] private SORecipeStep[] _soRecipeSteps;

    public bool ChekLength(int number)
    {
        if (number >= _soRecipeSteps.Length)
        {
            return false;
        }

        return true;
    }

    public ActionCommand GetCommand(int number)
    {
        return _soRecipeSteps[number].GetActionCommand();
    }
    
}
