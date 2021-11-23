using DefaultNamespace.GameSystems;
using GameSystems;
using UnityEngine;

namespace UI.EndGame
{
    public interface IWinScreen
    {
        public void Disable();
        public void Enable();
        public void Init(LevelLoader levelLoader, MoneyFolder moneyFolder);
        public void ShowLevelRezults(RewardLooker rewardLooker);
    }
}