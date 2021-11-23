using System;
using DefaultNamespace.GameSystems;
using DefaultNamespace.UI.Rewards;
using GameSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EndGame
{
    public class WinScreen : MonoBehaviour, IWinScreen
    {
        [SerializeField] private Button _nextButton;
        [SerializeField] private RewardView _rewardView;
        [SerializeField] private UnrewardScreen _unrewardScreen;
        private LevelLoader _levelLoader;
        private MoneyFolder _moneyFolder;

        private void OnEnable()
        {
            _nextButton.onClick.AddListener(ChangeLevel);
            ShowNextButton();
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(ChangeLevel);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Init(LevelLoader levelLoader, MoneyFolder moneyFolder)
        {
            _moneyFolder = moneyFolder;
            _levelLoader = levelLoader;
        }
        
        private void ShowNextButton()
        {
            _nextButton.gameObject.SetActive(true);
        }

        
        public void ShowLevelRezults(RewardLooker rewardLooker)
        {
            _unrewardScreen.ShowLevelRezult(rewardLooker);
            _unrewardScreen.SetCount(_moneyFolder.MoneyForLevel);
            _unrewardScreen.gameObject.SetActive(true);
            _nextButton.gameObject.SetActive(true);
        }
        
        private void ChangeLevel()
        {
            _levelLoader.IncreaseNumber();
            _nextButton.onClick.RemoveListener(ChangeLevel);
            _levelLoader.LoadArmory();
        }
    }
}