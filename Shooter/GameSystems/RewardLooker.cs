using System;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;

namespace GameSystems
{
    public class RewardLooker : MonoBehaviour
    {
        [SerializeField] private RewardStep _rewardStep;
        private int _currentLevelToReward;
        private int _currentStepToReward;
        private LevelLoader _levelLoader;
        private UnlockElementsFolder _unlockElementsFolder;

        private void Awake()
        {
            _currentLevelToReward = PlayerPrefs.GetInt(PlayerPrefsName.LevelToReward);
            _currentStepToReward = PlayerPrefs.GetInt(PlayerPrefsName.RewardStep);
        }

        public void Init(LevelLoader levelLoader, UnlockElementsFolder unlockElementsFolder)
        {
            _unlockElementsFolder = unlockElementsFolder;
            _levelLoader = levelLoader;
        }

        public float GetPersentOfReward()
        {
            return (float)_currentLevelToReward / _rewardStep.GetCurrentStepValue(_currentStepToReward);
        }

        public bool TryGetNextRewardGunBase(out GunBase gunBase)
        {
            if (_unlockElementsFolder.TryGetLockedGunBase(out gunBase))
            {
                return true;
            }

            return false;
        }

        public bool CheckReward()
        {
            if (_currentLevelToReward >= _rewardStep.GetCurrentStepValue(_currentStepToReward))
            {
                _currentLevelToReward = 0;
                _currentStepToReward++;
                SaveStep();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveStep()
        {
            PlayerPrefs.SetInt(PlayerPrefsName.LevelToReward, _currentLevelToReward);
            PlayerPrefs.SetInt(PlayerPrefsName.RewardStep, _currentStepToReward);
        }

        public void AddCurrentLevelToReward()
        {
            _currentLevelToReward++;
            PlayerPrefs.SetInt(PlayerPrefsName.LevelToReward, _currentLevelToReward);
        }
    }
}