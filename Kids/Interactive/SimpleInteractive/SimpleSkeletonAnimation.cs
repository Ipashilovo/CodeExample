using System;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive
{
    public class SimpleSkeletonAnimation : MonoBehaviour, IInteractive
    {
        [SerializeField] private AnimationFolder _animationFolder;
        private bool _isPlay;

        public event Action Interacting;
        public event Action EndInteracting;

        private void OnEnable()
        {
            _animationFolder.Ended += OnAnimationEnd;
        }

        private void OnDisable()
        {
            _animationFolder.Ended -= OnAnimationEnd;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isPlay) return;
            
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                _animationFolder.Animate(playerFacade.GetSceletonHandler());
                Interacting?.Invoke();
                _isPlay = true;
            }
        }

        private void OnAnimationEnd()
        {
            EndInteracting?.Invoke();
            _isPlay = false;
        }
    }
}