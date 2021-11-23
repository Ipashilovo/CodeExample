using System;
using System.Collections;
using Move.Animation;
using Player;
using Sound;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class LoopAnimationFolderWithIdleAndSacle : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset _idleAnimation;
        [SerializeField] private AnimationReferenceAsset _interactiveAnimation;
        [SerializeField] private AudioHandler[] _audioHandlers;
        [SerializeField] private float _time;
        [SerializeField] private float[] _timeScales;

        private int _currentScaleNumber;

        private void Start()
        {
            _skeletonAnimation.state.SetAnimation(0, _idleAnimation, true).TimeScale = 1;
        }

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            _audioHandlers[_currentScaleNumber].Play();
            _skeletonAnimation.state.SetAnimation(0, _interactiveAnimation, true).TimeScale = _timeScales[_currentScaleNumber];
            StartCoroutine(SetIdleAfterDelay());
        }

        private IEnumerator SetIdleAfterDelay()
        {
            yield return new WaitForSeconds(_time / _timeScales[_currentScaleNumber]);
            Notify();
            _skeletonAnimation.state.AddAnimation(0, _idleAnimation, true, 0).TimeScale = 1;
            _currentScaleNumber++;
            _currentScaleNumber %= _timeScales.Length;
        }
    }
}