using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class AnimationFolderWithRandomAnimationAndIdle : AnimationFolder
    {
        [SerializeField] private AnimationReferenceAsset _idle;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset[] _animationReferenceAssets;


        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            AnimationReferenceAsset currentAnimation =
                _animationReferenceAssets[Random.Range(0, _animationReferenceAssets.Length)]; 
            _skeletonAnimation.state.SetAnimation(0, currentAnimation, false);
            _skeletonAnimation.state.AddAnimation(0, _idle, false, 0);
            StartCoroutine(NotifyAfterDelay(currentAnimation.Animation.Duration));
        }
    }
}