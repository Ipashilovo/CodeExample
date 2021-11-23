using System;
using Spine.Unity;
using UnityEngine;

namespace City
{
    public class LocationsEnterAnimation : MonoBehaviour
    {
        [SerializeField] private LockationTrigger _lockationTrigger;
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _idle;
        [SerializeField] private AnimationReferenceAsset _animation;

        private void OnEnable()
        {
            _lockationTrigger.Coming += PlayInteractive;
            _lockationTrigger.Removed += PlayIdle;
        }

        private void OnDisable()
        {
            _lockationTrigger.Coming -= PlayInteractive;
            _lockationTrigger.Removed -= PlayIdle;
        }

        private void PlayIdle()
        {
            _skeletonAnimation.state.SetAnimation(0, _idle, true);
        }

        private void PlayInteractive()
        {
            _skeletonAnimation.state.SetAnimation(0, _animation, true);
        }
    }
}