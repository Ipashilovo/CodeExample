using System;
using DG.Tweening;
using UnityEngine;

namespace City
{
    public class ScaleAnimation : LockationChangeAnimation
    {
        [SerializeField] private Side _side;
        [SerializeField] private float _timeToAnimate = 0.3f;
        [SerializeField] private float _scaleValue;
        private Vector3 _startScale;
        private Tweener _tweener;
        
        private void Start()
        {
            _startScale = transform.localScale;
        }

        protected override void OnRemoved()
        {
            if (_tweener != null && _tweener.IsPlaying())
            {
                _tweener.Kill();
            }

            _tweener = transform.DOScale(_startScale, _timeToAnimate);
        }

        protected override void OnComing()
        {
            if (_tweener != null && _tweener.IsPlaying())
            {
                _tweener.Kill();
            }

            switch (_side)
            {
                case Side.Both:
                    _tweener = transform.DOScale(_scaleValue, _timeToAnimate);
                    break;
                case Side.X:
                    _tweener = transform.DOScaleX(_scaleValue, _timeToAnimate);
                    break;
                case Side.Y:
                    _tweener = transform.DOScaleY(_scaleValue, _timeToAnimate);
                    break;
            }
        }
    }
}