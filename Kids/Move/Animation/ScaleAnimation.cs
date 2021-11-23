using System;
using DG.Tweening;
using UnityEngine;

namespace Move.Animation
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField] private float _maxScale;
        [SerializeField] private float _minScale;
        [SerializeField] private float _time;
        private Vector3 _startScale;

        private void Start()
        {
            _startScale = transform.localScale;
            DoMinScale();
        }

        private void DoMinScale()
        {
            transform.DOScale(_startScale * _minScale, _time).OnComplete(DoMaxScale);
        }

        private void DoMaxScale()
        {
            transform.DOScale(_startScale * _maxScale, _time).OnComplete(DoMinScale);
        }
    }
}