using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public class ConnectingPlayerDropInput : DropInputBase
    {
        [SerializeField] private Transform _interactPosition;
        [SerializeField] private AnimationFolder[] _animationFolders;
        private Transform _skeletonHandler;
        
        private void OnEnable()
        {
            _animationFolders[0].Ended += EndInteract;
        }

        private void OnDisable()
        {
            _animationFolders[0].Ended -= EndInteract;
        }

        public override Vector2 GetStartPosition()
        {
            return _interactPosition.position;
        }

        private void EndInteract()
        {
            _skeletonHandler.parent = null;
            NotifyEnd();
        }

        public override void Interact(ISkeletonHandler skeletonHandler)
        {
            base.Interact(skeletonHandler);
            _skeletonHandler = skeletonHandler.GetTransform();
            _skeletonHandler.parent = transform;
            foreach (var animationFolder in _animationFolders)
            {
                animationFolder.Animate(skeletonHandler);
            }
        }
    }
}