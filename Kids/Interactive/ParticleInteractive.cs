using System;
using UnityEngine;

namespace Interactive
{
    public class ParticleInteractive : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private MonoBehaviour _iInteractiveBase;
        private IInteractive _interactive;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_iInteractiveBase is IInteractive interactive)
            {
                _interactive = interactive;
            }
            else
            {
                _iInteractiveBase = null;
            }
        }
#endif

        private void Awake()
        {
            _interactive = (IInteractive) _iInteractiveBase;
            _interactive.EndInteracting += StopPlay;
            _interactive.Interacting += StartPlay;
        }

        private void OnDestroy()
        {
            _interactive.EndInteracting -= StopPlay;
            _interactive.Interacting -= StartPlay;
        }

        private void StopPlay()
        {
            _particleSystem.Stop();
        }

        private void StartPlay()
        {
            _particleSystem.Play();
        }
    }
}