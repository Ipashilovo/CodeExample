using System;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public class OneTimeInteractive : DropInputBase
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Transform _point;
        [SerializeField] private AnimationFolder[] _animationFolder;

        private void OnEnable()
        {
            _animationFolder[0].Ended += NotifyEnd;
            _animationFolder[0].Ended += DisableCollider;
        }

        private void OnDisable()
        {
            _animationFolder[0].Ended -= NotifyEnd;
            _animationFolder[0].Ended -= DisableCollider;
        }

        public override Vector2 GetStartPosition()
        {
            return _point.position;
        }
        

        public override Vector2 GetLookAtPosition()
        {
            Vector2 rezult = (Vector2)_point.position + Vector2.right; 
            return rezult;
        }

        public override void Interact(ISkeletonHandler skeletonHandler)
        {
            base.Interact(skeletonHandler);
            foreach (var animationFolder in _animationFolder)
            {
                animationFolder.Animate(skeletonHandler);
            }
        }

        private void DisableCollider()
        {
            _collider.enabled = false;
        }
    }
}