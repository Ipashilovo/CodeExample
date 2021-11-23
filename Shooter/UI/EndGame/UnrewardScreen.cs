using System.Linq;
using DG.Tweening;
using GameSystems;
using Gun;
using GunCreateUI.SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EndGame
{
    public class UnrewardScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        [SerializeField] private Image _rewardImage;
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _text;
        [SerializeField] private Text _percentText;
        [SerializeField] private SpriteFolderCell<GunBase>[] _spriteFolders;
        [SerializeField] private float _sliderMoveTime = 2f;

        public void ShowLevelRezult(RewardLooker rewardLooker)
        {
            float persentOfReward = rewardLooker.GetPersentOfReward();
            _slider.value = 0;
            _slider.DOValue(persentOfReward, _sliderMoveTime);
            
            _percentText.text = $"{(int)(persentOfReward * 100)}%";

            if (rewardLooker.TryGetNextRewardGunBase(out GunBase gunBase))
            {
                _rewardImage.sprite = _spriteFolders.First(s => s.Type == gunBase).GetSprite();
                _rewardImage.gameObject.SetActive(true);
            }
            else
            {
                _textMeshPro.gameObject.SetActive(true);
            }
        }

        public void SetCount(int moneyCount)
        {
            _text.text = $"+{moneyCount}";
        }
    }
}