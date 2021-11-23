using System;
using System.Collections;
using Analytics;
using Input;
using Interactive.DropInputInteractive;
using UnityEngine;

namespace Player
{
    public class ClickHandler : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private LayerMask _layerMask;
        private bool _isMoving;
        private Camera _camera;
        private Coroutine _lisenInputPosition;

        public bool IsMoving => _isMoving;

        public event Action ClickEnded;

        private void OnEnable()
        {
            InputFolder.Clicked += OnClickStarted;
            InputFolder.ClickEnded += OnClickEnded;
            InputFolder.Enable();
            
            new EventSender().SendLevelStart();
        }

        private void Start()
        {
            _camera = Camera.main;
            InputFolder.EnableInfinity();
        }

        private void OnDestroy()
        {
            if (_lisenInputPosition != null)
            {
                StopCoroutine(_lisenInputPosition);
                _lisenInputPosition = null;
            }
            InputFolder.ClickEnded -= OnClickEnded;
            InputFolder.Clicked -= OnClickStarted;
        }

        private void OnClickStarted()
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(InputFolder.GetInputPosition());
            if (!Physics2D.Raycast(mousePosition, Vector2.zero, 0, _layerMask))
            {
                _isMoving = true;
                if (_lisenInputPosition != null)
                {
                    StopCoroutine(_lisenInputPosition);
                    _lisenInputPosition = null;
                }
                _lisenInputPosition = StartCoroutine(LisenInputPosition());
            }
        }

        private void OnClickEnded()
        {
            if (!_isMoving) return;
            
            _isMoving = false;
            
            if (_lisenInputPosition != null)
            {
                StopCoroutine(_lisenInputPosition);
                _lisenInputPosition = null;
            }
            ClickEnded?.Invoke();
        }

        private IEnumerator LisenInputPosition()
        {
            while (true)
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(InputFolder.GetInputPosition());
                if (!Physics2D.Raycast(mousePosition, Vector2.zero, 0, _layerMask))
                {
                    _playerMover.MoveToPosition(mousePosition);
                }
                yield return null;
            }
        }
    }
}