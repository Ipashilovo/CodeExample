using System;
using Stickmans;
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class HeadParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private MonoBehaviour _iDamageTaker;
        private IDamageTakerObserver _damageTakerObserver;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_iDamageTaker is IDamageTakerObserver damageTaker)
            {
                _damageTakerObserver = damageTaker;
            }
            else
            {
                _iDamageTaker = null;
            }
        }

#endif
        private void Awake()
        {
            _damageTakerObserver = (IDamageTakerObserver) _iDamageTaker;
        }

        private void Start()
        {
            _particleSystem = Instantiate(_particleSystem, transform);
        }

        private void OnEnable()
        {
            _damageTakerObserver.Taked += PlayParticle;
        }

        private void OnDisable()
        {
            _damageTakerObserver.Taked -= PlayParticle;
        }

        private void PlayParticle()
        {
            _particleSystem.Play();
        }
    }
}