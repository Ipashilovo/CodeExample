using System;
using DefaultNamespace.GameSystems;
using DefaultNamespace.Tutorials;
using GameSystems;
using UI.EndGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tutorials.FirstLevelTutorial.UI
{
    public class TutorialWinScreen : MonoBehaviour, IWinScreen
    {
        [SerializeField] private Button _nextButton;
        [SerializeField] private UnrewardScreen _unrewardScreen;
        private Tutorial _tutorial;
        private LevelLoader _levelLoader;
        private MoneyFolder _moneyFolder;

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            _nextButton.onClick.AddListener(LoadNextLevel);
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(LoadNextLevel);
        }

        [Inject]
        public void Construct(Tutorial tutorial)
        {
            _tutorial = tutorial;
        }

        public void Init(LevelLoader levelLoader, MoneyFolder moneyFolder)
        {
            _levelLoader = levelLoader;
            _moneyFolder = moneyFolder;
        }

        public void ShowLevelRezults(RewardLooker rewardLooker)
        {
            _unrewardScreen.ShowLevelRezult(rewardLooker);
            _unrewardScreen.SetCount(_moneyFolder.MoneyForLevel);
            _unrewardScreen.gameObject.SetActive(true);
            _nextButton.gameObject.SetActive(true);
        }

        private void LoadNextLevel()
        {
            _tutorial.LoadArmory();
        }
    }
}