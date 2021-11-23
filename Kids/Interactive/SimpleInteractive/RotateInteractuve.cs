using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Interactive
{
    public class RotateInteractuve : MonoBehaviour, IInteractive, ISimpleInteractive
    {
        [SerializeField] private float _time;
        [SerializeField] private float _rotatePower;
        private Coroutine _coroutine;
        
        
        public event Action Interacting;
        public event Action EndInteracting;

        private void Update()
        {
            transform.Rotate(new Vector3(0,0, _rotatePower * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                    _coroutine = null;
                }

                Interact();
                enabled = true;
                _coroutine = StartCoroutine(AnimationTime());
            }
        }
        
        public void Interact()
        {
            Interacting?.Invoke();
        }

        public void StopInteract()
        {
            enabled = false;
        }

        private IEnumerator AnimationTime()
        {
            yield return new WaitForSeconds(_time);
            enabled = false;
            _coroutine = null;
        }
    }
}