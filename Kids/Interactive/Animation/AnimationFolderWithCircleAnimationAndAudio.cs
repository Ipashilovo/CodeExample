using Move.Animation;
using Player;
using Sound;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class AnimationFolderWithCircleAnimationAndAudio : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationCell[] _animationCells;
        [SerializeField] private AudioHandler[] _audioHandlers;
        private int _currentNumber;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            AnimationCell currentCell = _animationCells[_currentNumber];
            skeletonHandler.SetAnimation(currentCell.PlayerAnimation);
            _skeletonAnimation.state.SetAnimation(0, currentCell.AnimationReferenceAsset, false);
            _audioHandlers[_currentNumber].Play();
            StartCoroutine(NotifyAfterDelay(currentCell.AnimationReferenceAsset.Animation.Duration));
            _currentNumber++;
            _currentNumber %= _animationCells.Length;
        }
    }
}