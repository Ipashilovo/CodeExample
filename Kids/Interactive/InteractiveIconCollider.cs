using System;
using Player;
using UnityEngine;

namespace Interactive
{
    public class InteractiveIconCollider : MonoBehaviour
    {
        [SerializeField] private InteractiveIcon _interactiveIcon;
        [SerializeField] private MonoBehaviour _interactiveBase;
        [SerializeField] private bool _isOneTimeInteract;
        private Collider2D _collider;
        private IInteractive _interactive;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!(_interactiveBase is IInteractive))
            {
                _interactiveBase = null;
            }
        }
#endif

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _interactive = (IInteractive) _interactiveBase;
            _interactive.Interacting += OnInteract;
            _interactive.EndInteracting += OnInteractEnd;
            InteractiveMediator.InteractStarted += DisableCollider;
            InteractiveMediator.InteractEnded += EnableCollider;
        }

        private void OnDestroy()
        {
            _interactive.Interacting -= OnInteract;
            _interactive.EndInteracting -= OnInteractEnd;
            InteractiveMediator.InteractStarted -= DisableCollider;
            InteractiveMediator.InteractEnded -= EnableCollider;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                _interactiveIcon.Show();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                Hide();
            }
        }

        private void DisableCollider()
        {
            _collider.enabled = false;
        }

        private void EnableCollider()
        {
            _collider.enabled = true;
        }

        private void OnInteractEnd()
        {
            InteractiveMediator.NotifyEnd();
        }

        private void OnInteract()
        {
            InteractiveMediator.NotifyStart();
            if (_isOneTimeInteract)
            {
                InteractiveMediator.InteractEnded -= EnableCollider;
            }
        }

        private void Hide()
        {
            _interactiveIcon.Hide();
        }
    }
}