using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class AnimationFolderWithMultipleAnimation : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset[] _animationReferenceAssets;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            _skeletonAnimation.state.SetAnimation(0, _animationReferenceAssets[0], false);
            for (int i = 1; i < _animationReferenceAssets.Length; i++)
            {
                _skeletonAnimation.state.AddAnimation(0, _animationReferenceAssets[i], false, 0);
            }

            StartCoroutine(NotifyAfterDelay(_animationReferenceAssets[0].Animation.Duration));
        }
    }
}