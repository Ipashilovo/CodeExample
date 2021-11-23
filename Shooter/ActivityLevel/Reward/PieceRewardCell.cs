using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;

namespace ActivityLevel.Reward
{
    public class PieceRewardCell : RewardCell
    {
        public readonly Sprite GunSprite;
        public readonly GunBase GunBase;
        private UnlockElementsFolder _unlockElementsFolder; 

        public PieceRewardCell(GunBase gunBase, Sprite gunSprite, UnlockElementsFolder unlockElementsFolder)
        {
            GunBase = gunBase;
            GunSprite = gunSprite;
            _unlockElementsFolder = unlockElementsFolder;
        }

        public override Sprite GetSprite()
        {
            return GunSprite;
        }

        public override string GetText()
        {
            string rezult = $"{GunBase}";
            return rezult.ToUpper();
        }

        public override void Select()
        {
            _unlockElementsFolder.UnlockGun(GunBase);
        }
    }
}