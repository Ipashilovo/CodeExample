using Move.Animation;
using Player;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class AnimationFolderPlayerWithCircleAnimation : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationCell[] _animationCells;
        private int _currentNumber;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            AnimationCell currentCell = _animationCells[_currentNumber];
            skeletonHandler.SetAnimation(currentCell.PlayerAnimation);
            _skeletonAnimation.state.SetAnimation(0, currentCell.AnimationReferenceAsset, false);
            StartCoroutine(NotifyAfterDelay(currentCell.AnimationReferenceAsset.Animation.Duration));
            _currentNumber++;
            _currentNumber %= _animationCells.Length;
        }
    }
}