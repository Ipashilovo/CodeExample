using System;
using DefaultNamespace.GameSystems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GunCreateUI
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private MoneyFolder _moneyFolder;

        [Inject]
        public void Construct(MoneyFolder moneyFolder)
        {
            _moneyFolder = moneyFolder; 
            ShowNewValue();
        }

        private void Start()
        {
            _moneyFolder.MoneyCountChanged += ShowNewValue;
        }

        private void OnDestroy()
        {
            _moneyFolder.MoneyCountChanged -= ShowNewValue;
        }

        private void ShowNewValue()
        {
            _text.text = _moneyFolder.Money.ToString();
        }
    }
}