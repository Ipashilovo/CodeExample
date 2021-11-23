using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.SimpleInteractive
{
    public class AnimationFolderWithDropIdle : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _indle;
        [SerializeField] private AnimationReferenceAsset _interactive;
        private AnimationReferenceAsset _currentAnimation;


        private void Start()
        {
            _skeletonAnimation.state.SetAnimation(0, _indle, true);
        }

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            _skeletonAnimation.state.SetAnimation(0, _interactive, false);
            StartCoroutine(NotifyAfterDelay(_interactive.Animation.Duration));
            _skeletonAnimation.state.AddAnimation(0, _indle, true, 0);
        }
    }
}