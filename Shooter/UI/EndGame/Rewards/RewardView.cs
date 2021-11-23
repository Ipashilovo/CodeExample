using System;
using System.Collections.Generic;
using System.Linq;
using ActivityLevel.Reward;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.UI.Rewards
{
    public class RewardView : MonoBehaviour
    {
        [SerializeField] private RewardViewCell _rewardViewCell;
        [SerializeField] private Transform _content;
        private List<RewardViewCell> _rewardViewCells;

        public event Action Selected;
        
        public void SetRewards(List<RewardCell> rewardCells)
        {
            _rewardViewCells = new List<RewardViewCell>(rewardCells.Count);
            foreach (var rewardCell in rewardCells)
            {
                var newCell = Instantiate(_rewardViewCell, _content);
                newCell.Init(rewardCell);
                _rewardViewCells.Add(newCell);
                newCell.Selected += OnSelect;
            }
        }

        private void OnDestroy()
        {
            if (_rewardViewCells != null)
            {
                foreach (var reward in _rewardViewCells)
                {
                    reward.Selected -= OnSelect;
                }
            }
        }

        private void OnSelect(RewardViewCell rewardViewCell)
        {
            var unselectedCell = _rewardViewCells.Where(r => r != rewardViewCell);
            foreach (var cell in unselectedCell)
            {
                cell.gameObject.SetActive(false);
            }
            Selected?.Invoke();
        }
    }
}