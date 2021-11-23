using System;
using DG.Tweening;
using UnityEngine;

namespace Gun.GunShootAnimations
{
    public class SlideAnimation : GunShootAnimation
    {
        [SerializeField] private float _firstAnimationScale;
        [SerializeField] private float _moveScale;
        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.localPosition;
        }

        public override void Animate(float time)
        {
            float fistTime = time / _firstAnimationScale;
            Vector3 currentPosition = transform.localPosition;
            DOTween.Sequence().Append(transform.DOLocalMove(currentPosition - Vector3.forward * _moveScale, fistTime))
                .Append(transform.DOLocalMove(_startPosition, time - fistTime));
        }
    }
}