using System;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.SimpleInteractive
{
    public class SimpleOneTimeInteractiveWithFolder : SimpleOneTimeInteractive
    {
        [SerializeField] private AnimationFolder[] _animationFolders;
        private Collider2D _collider;
        
        public override event Action Interacting;
        public override event Action EndInteracting;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public override void Interact(ISkeletonHandler skeletonHandler)
        {
            _collider.enabled = false;
            foreach (var animation in _animationFolders)
            {
                animation.Animate(skeletonHandler);
            }
        }
    }
}