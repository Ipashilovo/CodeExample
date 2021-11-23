using System;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.SimpleInteractive
{
    public class SimpleAnimationWithRotate : MonoBehaviour, IInteractive
    {
        [SerializeField] private AnimationFolder _animationFolder;
        [SerializeField] private bool _isCurrentAnimationStartByRighteSidePlayer;
        private bool _isPlay;

        private event Action<Vector2> Rotate;

        public event Action Interacting;
        public event Action EndInteracting;

        private void Awake()
        {
            if (_isCurrentAnimationStartByRighteSidePlayer)
            {
                Rotate += StartRightSideRotation;
            }
            else
            {
                Rotate += StartLeftSideRotation;
            }
        }

        private void OnEnable()
        {
            _animationFolder.Ended += OnAnimationEnd;
        }

        private void OnDisable()
        {
            _animationFolder.Ended -= OnAnimationEnd;
        }

        private void OnDestroy()
        {
            Rotate -= StartRightSideRotation;
            Rotate -= StartLeftSideRotation;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isPlay) return;
            
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                Rotate?.Invoke(other.transform.position);
                _animationFolder.Animate(playerFacade.GetSceletonHandler());
                Interacting?.Invoke();
                _isPlay = true;
            }
        }

        private void StartRightSideRotation(Vector2 enemyPosition)
        {
            float value = enemyPosition.x - transform.position.x;
            if (value > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void StartLeftSideRotation(Vector2 enemyPosition)
        {
            float value = enemyPosition.x - transform.position.x;
            if (value < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void OnAnimationEnd()
        {
            EndInteracting?.Invoke();
            _isPlay = false;
        }
    }
}