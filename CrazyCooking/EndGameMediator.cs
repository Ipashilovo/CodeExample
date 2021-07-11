using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMediator : MonoBehaviour
{
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private ActivatorGameplayElements _activatorGameplayElements;
    [SerializeField] private CookingLooker _cookingLooker;
    [SerializeField] private LifeLooker _lifeLooker;
    [SerializeField] private RecipeLooker _recipeLooker;

    private void OnEnable()
    {
        _cookingLooker.CookingComplited += OnLevelComplite;
        _lifeLooker.LifeEnded += OnLifeEnded;
    }

    private void OnDisable()
    {
        _cookingLooker.CookingComplited -= OnLevelComplite;
        _lifeLooker.LifeEnded -= OnLifeEnded;
    }

    private void OnLifeEnded()
    {
        Debug.Log("LooseGame");
        _recipeLooker.FixCurrentRecipe();
        _endGameScreen.ShowLoose();
        DeactivateGameplayElements();
    }

    private void OnLevelComplite()
    {
        _endGameScreen.ShowWin();
        DeactivateGameplayElements();;
    }

    private void DeactivateGameplayElements()
    {
        _activatorGameplayElements.Deactivate();
    }
}
