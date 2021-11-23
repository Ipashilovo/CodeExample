using System;
using UnityEngine;

namespace DefaultNamespace.GameSystems
{
    public class MoneyFolder : MonoBehaviour
    {
        [SerializeField] private int _defultMoneyToAdd = 10;
        private int _money;
        private int _moneyForLevel;

        public int MoneyForLevel => _moneyForLevel;
        public int Money => _money;

        public event Action MoneyCountChanged;

        private void Awake()
        {
            _money = PlayerPrefs.GetInt(PlayerPrefsName.Money);
        }

        public void AddMoney(int money)
        {
            _money += money;
            MoneyCountChanged?.Invoke();
            Save();
        }
        
        public void AddMoney()
        {
            _moneyForLevel += _defultMoneyToAdd;
            _money += _defultMoneyToAdd;
            MoneyCountChanged?.Invoke();
            Save();
        }

        public void RemoveMoney(int money)
        {
            _money -= money;
            MoneyCountChanged?.Invoke();
            Save();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(PlayerPrefsName.Money, _money);
        }

        public void StartLisen()
        {
            _moneyForLevel = 0;
        }
    }
}