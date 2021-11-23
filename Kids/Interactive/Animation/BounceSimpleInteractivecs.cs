using System;
using DG.Tweening;
using UnityEngine;

namespace Interactive.Animation
{
    public class BounceSimpleInteractivecs : MonoBehaviour, ISimpleInteractive
    {
        [SerializeField] private float _maxScale;
        [SerializeField] private float _duration;

        private Vector3 _startScale;

        private void Awake()
        {
            _startScale = transform.localScale;
        }

        private Tween _tween;

        public void Interact()
        {
            _tween = transform.DOScale(_startScale * _maxScale, _duration);
        }

        public void StopInteract()
        {
            if (_tween != null)
            {
                _tween.Kill();
                _tween = null;
            }

            _tween = transform.DOScale(_startScale, _duration);
        }
    }
}