using System;
using System.Collections.Generic;
using DefaultNamespace.GameSystems;
using Gun;
using UnityEngine;

namespace ActivityLevel.Reward
{
    public class MoneyRewardCell : RewardCell
    {
        public readonly int Money;
        public readonly Sprite Sprite;
        private MoneyFolder _moneyFolder;

        public MoneyRewardCell(Sprite sprite, int money, MoneyFolder moneyFolder)
        {
            Sprite = sprite;
            Money = money;
            _moneyFolder = moneyFolder;
        }

        public override Sprite GetSprite()
        {
            return Sprite;
        }

        public override string GetText()
        {
            return "Money".ToUpper();
        }

        public override void Select()
        {
            _moneyFolder.AddMoney(Money);
        }
    }
}