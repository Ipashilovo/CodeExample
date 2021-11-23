using System;
using System.Collections.Generic;
using ActivityLevel.Reward;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Rewards
{
    public class RewardViewCell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;
        private RewardCell _rewardCell;
        public event Action<RewardViewCell> Selected;

        public void Init(RewardCell rewardCell)
        {
            _rewardCell = rewardCell;
            _text.text = rewardCell.GetText();
            _image.sprite = rewardCell.GetSprite();
            _rewardCell.Select();
            _button.onClick.AddListener(Select);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Select);
        }

        private void Select()
        {
            _button.onClick.RemoveListener(Select);
            Selected?.Invoke(this);
        }
    }
}