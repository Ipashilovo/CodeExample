using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField] private EndGameText _endGameText;
    public void ShowWin()
    {
        _endGameText.Show(GameRezalt.Win);
        Enable();
    }

    public void ShowLoose()
    {
        _endGameText.Show(GameRezalt.Loose);
        Enable();
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
