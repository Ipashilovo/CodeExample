using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive
{
    public class InteractiveFolderOnlyPlayer : AnimationFolder
    {
        [SerializeField] private AnimationReferenceAsset _animationReferenceAsset; 
            
        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            skeletonHandler.SetAnimation(_animationReferenceAsset);
            float time = _animationReferenceAsset.Animation.Duration;
            StartCoroutine(NotifyAfterDelay(time));
        }
    }
}