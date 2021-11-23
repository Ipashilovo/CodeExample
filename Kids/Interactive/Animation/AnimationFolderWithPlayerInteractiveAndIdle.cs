using System;
using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive
{
    public class AnimationFolderWithPlayerInteractiveAndIdle : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _playerAnimation;
        [SerializeField] private AnimationReferenceAsset _animationReference;
        [SerializeField] private AnimationReferenceAsset _idle;
        [SerializeField] private float _animationScale = 1;


        private void Start()
        {
            _skeletonAnimation.state.SetAnimation(0, _idle, true);
        }

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            float time = _playerAnimation.Animation.Duration;
            _skeletonAnimation.state.SetAnimation(0, _animationReference, false).TimeScale = _animationScale;
            _skeletonAnimation.state.AddAnimation(0, _idle, true, 0);
            skeletonHandler.SetAnimation(_playerAnimation, _animationScale);
            StartCoroutine(NotifyAfterDelay(time / _animationScale));
        }
    }
}