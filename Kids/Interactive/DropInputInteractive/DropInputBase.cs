using System;
using Input;
using LevelSystems;
using Player;
using UnityEngine;

namespace Interactive.DropInputInteractive
{
    public abstract class DropInputBase : MonoBehaviour, IDropInputBase, IInteractive
    {
        [SerializeField] private Transform _lookAtPosition;
        [SerializeField] private float _zoomValue = 1;
        public event Action Interacting;
        public event Action EndInteracting;
        public abstract Vector2 GetStartPosition();


        public virtual void Interact(ISkeletonHandler skeletonHandler)
        {
            CameraZoom.Zoom(_zoomValue);
            Interacting?.Invoke();
        }

        public virtual Vector2 GetLookAtPosition()
        {
            if (_lookAtPosition == null)
            {
                return transform.position;
            }
            else
            {
                return _lookAtPosition.position;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                playerFacade.RemoveInteractOpportunity(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                playerFacade.SetInteractOpportunity(this);
            }
        }

        protected void NotifyEnd()
        {
            EndInteracting?.Invoke();
            CameraZoom.Rezoome();
            InputFolder.Enable();
        }
    }
}