using System;
using System.Collections.Generic;
using System.Linq;
using BulletData;
using DefaultNamespace.GameSystems;
using GameSystems.GunsInfo;
using Gun;
using GunCreateUI.SO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ActivityLevel.Reward
{
    public class RewardCellCreator : MonoBehaviour
    {
        [SerializeField] private MoneyReward[] _moneyRewards;
        [SerializeField] private SpriteFolder<GunBase> _gunSpriteFolder;
        [SerializeField] private Sprite _moneySprite;
        private MoneyFolder _moneyFolder;
        private UnlockElementsFolder _unlockElementsFolder;
        
        public List<RewardCell> CreateCell(GunBase gunBase)
        {
            List<RewardCell> rewardCells = new List<RewardCell>();
            var sprite = _gunSpriteFolder.GetSprites().First(g => g.Type == gunBase).GetSprite();
            rewardCells.Add(new PieceRewardCell(gunBase, sprite, _unlockElementsFolder));
            return rewardCells;
        }

        public List<RewardCell> CreateMoneyCell()
        {
            List<RewardCell> rewardCells = new List<RewardCell>();
            rewardCells.Add(new MoneyRewardCell(_moneySprite, _moneyRewards[Random.Range(0, _moneyRewards.Length)].Money, _moneyFolder));
            return rewardCells;
        }

        public void Init(UnlockElementsFolder unlockElementsFolder, MoneyFolder moneyFolder)
        {
            _moneyFolder = moneyFolder;
            _unlockElementsFolder = unlockElementsFolder;
        }
    }
}