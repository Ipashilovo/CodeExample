using System;
using DG.Tweening;
using UnityEngine;

namespace City
{
    public class LocationScale : MonoBehaviour
    {
        [SerializeField] private float _scaleValue = 1.2f;
        [SerializeField] private float _timeToScale = 0.3f;
        private LockationTrigger _lockationTrigger;

        private Vector3 _startScale;

        private Tween _tween;

        private void Awake()
        {
            _startScale = transform.localScale;
        }

        private void Start()
        {
            _lockationTrigger = GetComponent<LockationTrigger>();
            _lockationTrigger.Coming += ScaleUp;
            _lockationTrigger.Removed += ScaleDown;
        }
        
        private void OnDestroy()
        {
            _lockationTrigger.Coming -= ScaleUp;
            _lockationTrigger.Removed -= ScaleDown;
        }

        private void ScaleDown()
        {
            ClearTween();
            _tween = transform.DOScale(_startScale, _timeToScale).OnComplete(() => _tween = null);
        }

        private void ScaleUp()
        {
            ClearTween();
            _tween = transform.DOScale(_startScale * _scaleValue, _timeToScale).OnComplete(() => _tween = null);
        }

        private void ClearTween()
        {
            if (_tween != null)
            {
                _tween.Kill();
                _tween = null;
            }
        }
    }
}