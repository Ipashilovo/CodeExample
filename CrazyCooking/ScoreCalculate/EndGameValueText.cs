using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameValueText : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private ScoreCalculator _scoreCalculator;

    private void OnEnable()
    {
        _scoreText.text = _scoreCalculator.Score.ToString();
    }
}
