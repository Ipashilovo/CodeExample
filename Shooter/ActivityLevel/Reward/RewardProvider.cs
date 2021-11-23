using System;
using System.Collections.Generic;
using System.Reflection;
using DefaultNamespace.GameSystems;
using DefaultNamespace.UI.Rewards;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;

namespace ActivityLevel.Reward
{
    public class RewardProvider : MonoBehaviour
    {
        [SerializeField] private RewardCellCreator _rewardCellCreator;
        private RewardView _rewardView;
        private UnlockElementsFolder _unlockElementsFolder;
        private MoneyFolder _moneyFolder;

        public void Init(UnlockElementsFolder unlockElementsFolder, MoneyFolder moneyFolder, RewardView rewardView)
        {
            _rewardView = rewardView;
            _unlockElementsFolder = unlockElementsFolder;
            _moneyFolder = moneyFolder;
        }

        public void CreateRewards()
        {
            List<RewardCell> rewardCells = new List<RewardCell>();
            if (_unlockElementsFolder.TryGetLockedGunBase(out GunBase gunBase))
            {
                rewardCells = _rewardCellCreator.CreateCell(gunBase);
            }
            else
            {
                rewardCells = _rewardCellCreator.CreateMoneyCell();
            }
            _rewardView.SetRewards(rewardCells);
        }
    }
}