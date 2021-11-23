using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive
{
    public class AnimationFolderWithPlayerInteractive : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _playerAnimation;
        [SerializeField] private AnimationReferenceAsset _animationReference;
        [SerializeField] private float _animationScale = 1;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            float time = _playerAnimation.Animation.Duration;
            _skeletonAnimation.state.SetAnimation(0, _animationReference, false).TimeScale = _animationScale;
            skeletonHandler.SetAnimation(_playerAnimation, _animationScale);
            StartCoroutine(NotifyAfterDelay(time / _animationScale));
        }
    }
}