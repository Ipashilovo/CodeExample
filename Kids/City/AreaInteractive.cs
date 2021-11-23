using System;
using Interactive;
using Player;
using UnityEngine;

namespace City
{
    public class AreaInteractive : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] _monoBehaviour;
        private ISimpleInteractive[] _simpleInteractive;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            _simpleInteractive = new ISimpleInteractive[_monoBehaviour.Length];
            for (int i = 0; i < _simpleInteractive.Length; i++)
            {
                if (_monoBehaviour[i] is ISimpleInteractive simpleInteractive)
                {
                    _simpleInteractive[i] = simpleInteractive;
                }
                else
                {
                    _monoBehaviour = null;
                }
            }
        }
#endif

        private void Awake()
        {
            _simpleInteractive = new ISimpleInteractive[_monoBehaviour.Length];
            for (int i = 0; i < _simpleInteractive.Length; i++)
            {
                _simpleInteractive[i] = (ISimpleInteractive) _monoBehaviour[i];
            } 
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                foreach (var simpleInteractive in _simpleInteractive)
                {
                    simpleInteractive.Interact();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                foreach (var simpleInteractive in _simpleInteractive)
                {
                    simpleInteractive.StopInteract();
                }
            }
        }
    }
}