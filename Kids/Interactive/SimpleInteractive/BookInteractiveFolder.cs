using System;
using System.Collections;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Interactive
{
    public class BookInteractiveFolder : MonoBehaviour, IInteractive, ISimpleInteractive
    {
        [SerializeField] private BookMovement[] _bookMovements;
        [SerializeField] private float _timeForOneBook;
        private bool _firstSide = true;
        private Coroutine _coroutine;
        
        public event Action Interacting;
        public event Action EndInteracting;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_coroutine != null) return;

            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                Interact();
            }
        }


        public void Interact()
        {
            _coroutine = StartCoroutine(_firstSide ? PlayAnimation() : PlayMirrorAnimation());
            _firstSide = !_firstSide;

            Interacting?.Invoke();
        }

        public void StopInteract()
        {
            
        }

        private IEnumerator PlayAnimation()
        {
            for (int i = 0; i < _bookMovements.Length; i++)
            {
                _bookMovements[i].Move(_timeForOneBook);
                yield return new WaitForSeconds(_timeForOneBook);
            }

            _coroutine = null;
        }

        private IEnumerator PlayMirrorAnimation()
        {
            for (int i = _bookMovements.Length - 1; i >= 0; i--)
            {
                _bookMovements[i].Move(_timeForOneBook);
                yield return new WaitForSeconds(_timeForOneBook);
            }

            EndInteracting?.Invoke();
            _coroutine = null;
        }
    }
}