using System;
using Effects;
using Stickmans;
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    [RequireComponent(typeof(IDamageTakerObserver))]
    public class HitParticle : MonoBehaviour
    {
        private AudioSource _audioSource;
        private IDamageTakerObserver _damageTakerObserver;
        private ParticlePool _particlePool;
        private void Awake()
        {
            _damageTakerObserver = GetComponent<IDamageTakerObserver>();
        }

        private void OnEnable()
        {
            _damageTakerObserver.Taked += PlayParticle;
        }

        private void OnDisable()
        {
            _damageTakerObserver.Taked -= PlayParticle;
        }

        public void SetParticle(ParticlePool particlePool, AudioSource audioSource)
        {
            _audioSource = audioSource;
            _particlePool = particlePool;
        }

        private void PlayParticle()
        {
            _audioSource.Play();
            _particlePool.Play(transform.position, Vector3.zero);
        }
    }
}