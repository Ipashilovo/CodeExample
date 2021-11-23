using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class CityExitButtonBounce : MonoBehaviour
    {
        [SerializeField] private float _startScaleTime;
        [SerializeField] private float _scaleTime;
        [SerializeField] private float _scaleValue;
        private Vector3 _startScale;

        private Tween _tweener;

        private void Awake()
        {
            _startScale = transform.localScale;
            gameObject.SetActive(false);
        }

        public void Show()
        {
            ClearTweener();
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
            _tweener = transform.DOScale(_startScale, _startScaleTime).OnComplete(Bounce);
        }

        private void Bounce()
        {
            ClearTweener();
            _tweener = DOTween.Sequence().Append(transform.DOScale(_startScale * _scaleValue, _scaleTime))
                .Append(transform.DOScale(_startScale * 1 / _scaleValue, _scaleTime));
            _tweener.OnComplete(Bounce);
        }

        public void Hide()
        {
            ClearTweener();
            _tweener = transform.DOScale(0, _startScaleTime).OnComplete(Disable);
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }

        private void ClearTweener()
        {
            if (_tweener != null)
            {
                _tweener.Kill();
                _tweener = null;
            }
        }
    }
}