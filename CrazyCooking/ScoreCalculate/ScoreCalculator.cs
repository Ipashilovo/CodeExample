using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private int _valueBurst;
    [SerializeField] private CookingLooker _cookingLooker;

    public int Score { get; private set; }

    private void Start()
    {
        Score = 0;
    }

    private void OnEnable()
    {
        _cookingLooker.CommandDone += Add;
    }

    private void OnDisable()
    {
        _cookingLooker.CommandDone -= Add;
    }

    public void StartNewGame()
    {
        Score = 0;
    }
    
    private void Add()
    {
        Score += _valueBurst;
    }
}
