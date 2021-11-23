using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class AnimationFolderWithFinalIdle : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _animationReference;
        [SerializeField] private AnimationReferenceAsset _idle;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            float time = _animationReference.Animation.Duration;
            _skeletonAnimation.state.SetAnimation(0, _animationReference, false);
            _skeletonAnimation.state.AddAnimation(0, _idle, true, 0);
            StartCoroutine(NotifyAfterDelay(time));
        }
    }
}