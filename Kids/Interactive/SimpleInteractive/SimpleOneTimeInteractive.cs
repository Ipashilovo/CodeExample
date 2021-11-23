using System;
using Player;
using UnityEngine;

namespace Interactive
{
    public abstract class SimpleOneTimeInteractive : MonoBehaviour, IInteractive
    {
        public abstract event Action Interacting;
        public abstract event Action EndInteracting;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out ISkeletonHandler playerFacade))
            {
                Interact(playerFacade);
            }
        }

        public abstract void Interact(ISkeletonHandler skeletonHandler);
    }
}