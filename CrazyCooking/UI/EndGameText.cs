using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndGameText : MonoBehaviour
{
    [SerializeField] private EndGameTextVariant[] _variants;
    [SerializeField] private Text _headerText;
    [SerializeField] private Text _buttonText;

    public void Show(GameRezalt gameRezalt)
    {
        EndGameTextVariant endGameTextVariant = _variants.First(variant => variant.GameRezalt == gameRezalt);
        _headerText.text = endGameTextVariant.HeaderText;
        _buttonText.text = endGameTextVariant.ButtonText;
    }
}
[System.Serializable]
public class EndGameTextVariant
{
    public GameRezalt GameRezalt;
    public string ButtonText;
    public string HeaderText;
}
