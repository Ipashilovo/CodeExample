using System.Collections;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public class DropInputMultipleAnimation : DropInputBase
    {
        [SerializeField] private Transform _interactivePosition;
        [SerializeField] private AnimationFolder[] _animationFolder;

        private void OnEnable()
        {
            _animationFolder[0].Ended += NotifyEnd;
        }

        private void OnDisable()
        {
            _animationFolder[0].Ended -= NotifyEnd;
        }

        public override Vector2 GetStartPosition()
        {
            return _interactivePosition.position;
        }

        public override void Interact(ISkeletonHandler skeletonHandler)
        {
            base.Interact(skeletonHandler);
            foreach (var animationFolder in _animationFolder)
            {
                animationFolder.Animate(skeletonHandler);
            }
        }
    }
}