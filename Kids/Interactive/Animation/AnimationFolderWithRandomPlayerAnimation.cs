using Move.Animation;
using Player;
using Sound;
using Spine.Unity;
using UnityEngine;

namespace Interactive.Animation
{
    public class AnimationFolderWithRandomPlayerAnimation : AnimationFolder
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;
        [SerializeField] private AnimationCell[] _animationCells;
        [SerializeField] private AudioHandler[] _audioHandlers;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            int number = Random.Range(0, _animationCells.Length);
            AnimationCell animationCell = _animationCells[number];
            _audioHandlers[number].Play();
            skeletonHandler.SetAnimation(animationCell.PlayerAnimation);
            _skeletonAnimation.state.SetAnimation(0, animationCell.AnimationReferenceAsset, false);
            StartCoroutine(NotifyAfterDelay(animationCell.PlayerAnimation.Animation.Duration));
        }
    }
}