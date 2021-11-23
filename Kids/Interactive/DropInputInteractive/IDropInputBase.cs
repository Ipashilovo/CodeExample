using System;
using Player;
using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public interface IDropInputBase
    {
        public event Action EndInteracting;

        public Vector2 GetStartPosition();

        public void Interact(ISkeletonHandler skeletonHandler);
        public Vector2 GetLookAtPosition();
    }
}