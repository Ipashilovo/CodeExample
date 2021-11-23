using System;
using Effects;
using UnityEngine;

namespace DefaultNamespace.Stickman
{
    public class ParticleSetter : MonoBehaviour
    {
        [SerializeField] private HitParticle[] _hitParticles;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleToPool _particleToPool;
        [SerializeField] private ParticleSystem _particleSystem;
        private ParticlePool _particlePool;

        private void Start()
        {
            _particleToPool = Instantiate(_particleToPool);
            _particleToPool.Init(_particleSystem);
            _particlePool = new ParticlePool(_particleToPool);
            foreach (var hitParticle in _hitParticles)
            {
                hitParticle.SetParticle(_particlePool, _audioSource);
            }
        }
    }
}