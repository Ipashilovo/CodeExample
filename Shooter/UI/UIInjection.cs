using ActivityLevel;
using DefaultNamespace.GameSystems;
using GameSystems;
using GameSystems.GunsInfo;
using LevelSystem;
using UI;
using UI.EndGame;
using UI.GameplayScreens;
using UI.StartGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.UI
{
    public class UIInjection : MonoBehaviour
    {
        [SerializeField] private GunNameView _gunNameView;
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private TapToStartButton _tapToStartButton;
        [SerializeField] private EndGameUI _endGameUI;
        [SerializeField] private LifeView _lifeView;

        [Inject]
        public void Inject(UnlockElementsFolder unlockElementsFolder, FirstInputLisener firstInputLisener, LevelLoader levelLoader, RewardLooker rewardLooker, MoneyFolder moneyFolder)
        {
            _moneyView.Init(moneyFolder);
            _gunNameView.Init(unlockElementsFolder);
            _tapToStartButton.Init(firstInputLisener);
            _endGameUI.Init(levelLoader, moneyFolder);
        }

        [Inject]
        public void InjectLife(PlayerFacade playerFacade)
        {
            _lifeView.Init(playerFacade);
        }
    }
}