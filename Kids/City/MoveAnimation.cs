using System;
using DG.Tweening;
using UnityEngine;

namespace City
{
    public class MoveAnimation : LockationChangeAnimation
    {
        [SerializeField] private float _animationTime;
        [SerializeField] private float _movePower;
        [SerializeField] private Side _side;
        private Vector3 _startPosition;
        private Tweener _tweener;


        private void Start()
        {
            _startPosition = transform.localPosition;
        }

        protected override void OnRemoved()
        {
            if (_tweener != null && _tweener.IsPlaying())
            {
                _tweener.Kill();
            }

            _tweener = transform.DOLocalMove(_startPosition, _animationTime);
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
                    Vector3 position = transform.localPosition;
                    position.x += _movePower;
                    position.y += _movePower;
                    _tweener = transform.DOLocalMove(position, _animationTime);
                    break;
                case Side.X:
                    _tweener = transform.DOLocalMoveX(_startPosition.x + _movePower, _animationTime);
                    break;
                case Side.Y:
                    _tweener = transform.DOLocalMoveY(_startPosition.y + _movePower, _animationTime);
                    break;
            }
        }
    }
}