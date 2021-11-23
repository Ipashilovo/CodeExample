using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class SkeletonAnimationWithRandomAnimationAndPlayerAnimation : AnimationFolder
    {
        [SerializeField] private AnimationReferenceAsset _playerAnimation;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset[] _animationReferenceAssets;


        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            skeletonHandler.SetAnimation(_playerAnimation);
            AnimationReferenceAsset currentAnimation =
                _animationReferenceAssets[Random.Range(0, _animationReferenceAssets.Length)]; 
            _skeletonAnimation.state.SetAnimation(0, currentAnimation, false);
            StartCoroutine(NotifyAfterDelay(currentAnimation.Animation.Duration));
        }
    }
}