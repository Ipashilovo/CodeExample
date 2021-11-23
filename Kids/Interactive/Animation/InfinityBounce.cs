using System;
using City;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Interactive.Animation
{
    public class InfinityBounce : LockationChangeAnimation
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private int _vibrato = 4;
        [SerializeField] private float _scale = 0.1f;
        private Vector3 _startScale;

        private Tween _tween;

        private void Awake()
        {
            _startScale = transform.localScale;
        }
        
        
        protected override void OnRemoved()
        {
            if (_tween != null)
            {
                _tween.Kill();
                _tween = null;
            }

            transform.localScale = _startScale;
        }

        protected override void OnComing()
        {
            _tween = transform.DOPunchScale(new Vector3(_scale, _scale, _scale), _duration, _vibrato).OnComplete(OnComing);
        }
    }
}