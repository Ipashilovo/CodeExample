using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeLooker : MonoBehaviour
{
    [SerializeField] private RecipeLoader _recipeLoader;
    private SORecipe _soRecipe;
    private int _currentComandNumber;
    
    private void Start()
    {
        _currentComandNumber = -1;
        _soRecipe = _recipeLoader.GetRecipe();
    }

    public void FixCurrentRecipe()
    {
        _recipeLoader.FixRecipe();
    }
    
    public bool TryGetNextCommand(out ActionCommand command)
    {
        _currentComandNumber++;
        if (_soRecipe.ChekLength(_currentComandNumber))
        {
            command = _soRecipe.GetCommand(_currentComandNumber);
            return true;
        }
        else
        {
            command = null;
            return false;
        }
    }
}
