using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecipeLoader : MonoBehaviour
{
    private readonly string[] _recipeNames =
    {
        "Recipe"
    };

    private readonly string _passedRecipePlayerPrefName = "PassedRecipePlayerPrefName";
    private readonly string _fixedPlayerPrefRecipeName = "FixedPlayerPrefRecipeName";

    private string _currentRecipeName;

    public SORecipe GetRecipe()
    {
        if (PlayerPrefs.HasKey(_fixedPlayerPrefRecipeName))
        {
            LoadFixedRecipe();
            SORecipe newRecipe = Resources.Load<SORecipe>(_currentRecipeName);
            return newRecipe;
        }
        
        
        if (PlayerPrefs.HasKey(_passedRecipePlayerPrefName))
        {
            List<string> passedRecipeNames = GetPassedRecipes();
            List<string> unpassedRecipeNames = GetUnpassedRecipeNames(ref passedRecipeNames);
            _currentRecipeName = ChooseRecipe(unpassedRecipeNames);
            SetNewPassedRecipe(passedRecipeNames, _currentRecipeName);
        }
        else
        {
            _currentRecipeName = _recipeNames[Random.Range(0, _recipeNames.Length)];
            SetNewPassedRecipe(new List<string>(), _currentRecipeName);
        }
        
        SORecipe recipe = Resources.Load<SORecipe>(_currentRecipeName);
        return recipe;
    }

    public void FixRecipe()
    {
        PlayerPrefs.SetString(_fixedPlayerPrefRecipeName, _currentRecipeName);
    }

    private List<string> GetPassedRecipes()
    {
        string jsonSavedRecipe = PlayerPrefs.GetString(_passedRecipePlayerPrefName);
        List<string> passedRecipes = JsonConvert.DeserializeObject<List<string>>(jsonSavedRecipe);
        return passedRecipes;
    }

    private List<string> GetUnpassedRecipeNames(ref List<string> passedRecipes)
    {
        if (passedRecipes.Count >= _recipeNames.Length)
        {
            passedRecipes = new List<string>();
            return _recipeNames.ToList();
        }
        
        List<string> unpassedRecipes = _recipeNames.Except(passedRecipes).ToList();
        return unpassedRecipes;
    }
    

    private void SetNewPassedRecipe(List<string> passedRecipes, string recipe)
    {
        passedRecipes.Add(recipe);
        string jsonSavedRecipes = JsonConvert.SerializeObject(passedRecipes);
        PlayerPrefs.SetString(_passedRecipePlayerPrefName, jsonSavedRecipes);
    }

    private string ChooseRecipe(List<string> unpassedRecipes)
    {
        string recipe = unpassedRecipes[Random.Range(0, unpassedRecipes.Count)];
        return recipe;
    }

    private void LoadFixedRecipe()
    {
        _currentRecipeName = PlayerPrefs.GetString(_fixedPlayerPrefRecipeName);
        PlayerPrefs.DeleteKey(_fixedPlayerPrefRecipeName);
    }
}
