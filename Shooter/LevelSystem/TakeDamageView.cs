using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace LevelSystem
{
    public class TakeDamageView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _startTime;
        [SerializeField] private float _secondTime;

        public void Animate()
        {
            Color targetColor = _image.color;
            targetColor.a = 1;
            Color startColor = targetColor;
            startColor.a = 0;
            DOTween.Sequence().Append(_image.DOColor(targetColor, _startTime))
                .Append(_image.DOColor(startColor, _secondTime));
        }
    }
}