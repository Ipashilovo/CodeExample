using System;
using DG.Tweening;
using Input;
using Move;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private MoveSpeed _moveSpeed;
        [SerializeField] private SkeletonHandler _skeletonHandler;
        [SerializeField] private float _delta = 0.5f;
        private Vector3 _currentPosition;
        private Vector3 _previousPosition;
        private Tweener _tweener;
        private bool _isMoving;
        private int number;

        public bool IsMoving => _isMoving;
        public event Action MoveEnded;
        public event Action ReachedPosition;


        public void MoveToInteractiblePosition(Vector2 position)
        {
            _currentPosition = position;
            _tweener.Kill();
            _skeletonHandler.StartMoving();
            SetNewTweener(position);
            LookAt(position);
            _tweener.OnComplete(NotifyPositionReach);
        }

        public void MoveToPosition(Vector3 position)
        {
            _currentPosition = position;
            if (Vector2.Distance(_currentPosition, _previousPosition) < _delta) return;
            _previousPosition = _currentPosition;
            _skeletonHandler.StartMoving();
            LookAt(position);
            Move(position);
        }

        private void Move(Vector3 position)
        {
            SetNewTweener(position);
            _tweener.OnComplete(NotyfyMoveEnded);
        }

        private void SetNewTweener(Vector3 position)
        {
            _isMoving = true;
            if (_tweener != null && _tweener.IsPlaying())
            {
                _tweener.Kill();
            }
            
            position.z = transform.position.z;
            float time = Vector2.Distance(transform.position, position) / _moveSpeed.Speed;
            _tweener = transform.DOMove(position, time);
        }

        public void LookAt(Vector2 position)
        {
            position.y = transform.position.y;
            Vector2 endPosition = (position - (Vector2)transform.position).normalized;
            transform.right = endPosition;
        }

        private void NotyfyMoveEnded()
        {
            _isMoving = false;
            _skeletonHandler.StopMoving();
            MoveEnded?.Invoke();
        }

        private void NotifyPositionReach()
        {
            _skeletonHandler.StopMoving();
            _isMoving = false;
            ReachedPosition?.Invoke();
        }
    }
}