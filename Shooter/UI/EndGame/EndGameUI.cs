using System;
using DefaultNamespace.GameSystems;
using DefaultNamespace.UI.Rewards;
using GameSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EndGame
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour _winScreenBase;
        [SerializeField] private MonoBehaviour _looseScreenBase;
        private IWinScreen _iWinScreen;
        private ILooseScreen _iLooseScreen;
        private LevelLoader _levelLoader;
        private MoneyFolder _moneyFolder;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!(_winScreenBase is IWinScreen))
            {
                _winScreenBase = null;
            }
            
            if (!(_looseScreenBase is ILooseScreen))
            {
                _looseScreenBase = null;
            }
        }
#endif

        private void Awake()
        {
            _iWinScreen = (IWinScreen)_winScreenBase;
            _iLooseScreen = (ILooseScreen) _looseScreenBase;
        }

        public void Init(LevelLoader levelLoader, MoneyFolder moneyFolder)
        {
            _moneyFolder = moneyFolder;
            _levelLoader = levelLoader;
        }

        private void Start()
        {
            _iWinScreen.Init(_levelLoader, _moneyFolder);
            _iLooseScreen.Init(_levelLoader);
        }


        public void ShowWin()
        {
            _iWinScreen.Enable();
        }

        

        public void ShowLoose()
        {
            _iLooseScreen.Enable();
        }

        public void ShowLevelRezults(RewardLooker rewardLooker)
        {
            _iWinScreen.Enable();
            _iWinScreen.ShowLevelRezults(rewardLooker);
        }
    }
}