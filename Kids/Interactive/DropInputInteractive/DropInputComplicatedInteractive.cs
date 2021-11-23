using System.Collections;
using Move.Animation;
using Player;
using Sound;
using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public class DropInputComplicatedInteractive : DropInputBase
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Transform _interactivePosition;
        [SerializeField] private AnimationFolder[] _firstAnimation;
        [SerializeField] private AnimationFolder[] _secondAnimation;
        [SerializeField] private AudioHandler _audioHandler;
        private ISkeletonHandler _skeletonHandler;

        private void OnEnable()
        {
            _secondAnimation[0].Ended += EnableCollider;
            _secondAnimation[0].Ended += NotifyEnd;
            _firstAnimation[0].Ended += PlaySecondAnimation;
        }

        private void OnDisable()
        {
            _secondAnimation[0].Ended -= EnableCollider;
            _secondAnimation[0].Ended -= NotifyEnd;
            _firstAnimation[0].Ended -= PlaySecondAnimation;
        }

        public override Vector2 GetStartPosition()
        {
            return _interactivePosition.position;
        }

        public override void Interact(ISkeletonHandler skeletonHandler)
        {
            base.Interact(skeletonHandler);
            _skeletonHandler = skeletonHandler;
            foreach (var animationFolder in _firstAnimation)
            {
                animationFolder.Animate(skeletonHandler);
            }
        }

        private void PlaySecondAnimation()
        {
            _collider.enabled = false;
            _audioHandler.Play();
            foreach (var animationFolder in _secondAnimation)
            {
                animationFolder.Animate(_skeletonHandler);
            }
        }
        
        private void EnableCollider()
        {
            _collider.enabled = true;
        }
    }
}