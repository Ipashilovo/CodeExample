using ActivityLevel;
using ActivityLevel.EnemySystems;
using ActivityLevel.Reward;
using DefaultNamespace.Input;
using DefaultNamespace.UI;
using DefaultNamespace.UI.Rewards;
using GameSystems;
using GameSystems.GunsInfo;
using LevelSystem;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.GameSystems
{
    public class ActivityLevelInjection : MonoBehaviour
    {
        [SerializeField] private StickmanLooker _stickmanLooker;
        [SerializeField] private GunSetter _gunSetter;
        [SerializeField] private GunRotatable _gunRotatable;
        [SerializeField] private RewardProvider _rewardProvider;
        [SerializeField] private EndLevelLisener _endLevelLisener;
        [SerializeField] private SystemStarterOnFirstClick _systemStarterOnFirstClick;
        [SerializeField] private RewardCellCreator _rewardCellCreator;

        [Inject]
        public void Inject(UnlockElementsFolder unlockElementsFolder, InputFolder inputFolder, MoneyFolder moneyFolder, RewardView rewardView, FirstInputLisener firstInputLisener)
        {
            _rewardCellCreator.Init(unlockElementsFolder, moneyFolder);
            _gunRotatable.Init(inputFolder, _endLevelLisener);
            _gunSetter.Init(unlockElementsFolder, inputFolder);
            _rewardProvider.Init(unlockElementsFolder, moneyFolder, rewardView);
            _systemStarterOnFirstClick.Init(firstInputLisener);
        }

        [Inject]
        public void InjectUI(StateUIFolder stateUIFolder, CameraHandler cameraHandler, PlayerFacade playerFacade, RewardLooker rewardLooker)
        {
            _endLevelLisener.Init(stateUIFolder, cameraHandler, playerFacade, rewardLooker);
        }

        [Inject]
        public void InjectMoney(MoneyFolder moneyFolder)
        {
            _stickmanLooker.SetMoneyFolder(moneyFolder);
        }
    }
}