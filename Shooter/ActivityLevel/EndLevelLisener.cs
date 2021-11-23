using System;
using ActivityLevel.EnemySystems;
using DefaultNamespace.Stickman;
using DefaultNamespace.UI;
using GameSystems;
using LevelSystem;
using UnityEngine;

namespace ActivityLevel.Reward
{
    public class EndLevelLisener : MonoBehaviour
    {
        [SerializeField] private StickmanLooker _stickmanLooker;
        [SerializeField] private RewardProvider _rewardProvider;
        private StateUIFolder _stateUIFolder;
        private CameraHandler _cameraHandler;
        private PlayerFacade _playerFacade;
        private RewardLooker _rewardLooker;

        public event Action LevelEnded;
        
        public void Init(StateUIFolder stateUIFolder, CameraHandler cameraHandler, PlayerFacade playerFacade, RewardLooker rewardLooker)
        {
            _rewardLooker = rewardLooker;
            _playerFacade = playerFacade;
            _cameraHandler = cameraHandler;
            _stateUIFolder = stateUIFolder;
        }

        private void OnEnable()
        {
            _playerFacade.Dying += OnPlayerDie;
            _stickmanLooker.LastStickmanDead += OnLastEnemyDead;
            _cameraHandler.AnimationEnd += EnableEndLevelScreen;
        }

        private void OnDisable()
        {
            _playerFacade.Dying -= OnPlayerDie;
            _cameraHandler.AnimationEnd -= EnableEndLevelScreen;
            _stickmanLooker.LastStickmanDead -= OnLastEnemyDead;
        }

        private void OnPlayerDie()
        {
            _playerFacade.Dying -= OnPlayerDie;
            LevelEnded?.Invoke();
            _stateUIFolder.ShowLoose();
        }

        private void EnableEndLevelScreen()
        {
            _rewardLooker.AddCurrentLevelToReward();
            _stateUIFolder.ShowWin();
            if (_rewardLooker.CheckReward())
            {
                _rewardProvider.CreateRewards();
            }
            else
            {
                _stateUIFolder.ShowUnrewardScreen(_rewardLooker);
            }
        }

        private void OnLastEnemyDead(Transform lastStickman)
        {
            LevelEnded?.Invoke();
            _cameraHandler.LookAtLastStickman(lastStickman);
        }
    }
}