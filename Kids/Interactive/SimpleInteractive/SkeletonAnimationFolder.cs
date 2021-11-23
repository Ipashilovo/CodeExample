using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.SimpleInteractive
{
    public class SkeletonAnimationFolder : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _animationReferenceAsset;
        private float _time;

        private void Start()
        {
            _time = _animationReferenceAsset.Animation.Duration;
        }

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            _skeletonAnimation.state.SetAnimation(0, _animationReferenceAsset, false);
            StartCoroutine(NotifyAfterDelay(_time));
        }
    }
}