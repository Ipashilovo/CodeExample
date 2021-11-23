using System.Collections.Generic;
using UnityEngine;

namespace Effects
{
    public class ParticlePool
    {
        private List<ParticleToPool> _particleToPools;
        private List<ParticleToPool> _activatedParticle;
        private ParticleToPool _particleToPool;
        private ParticleSystem _particleSystem;

        public ParticlePool(ParticleToPool particleSystem)
        {
            _activatedParticle = new List<ParticleToPool>();
            _particleToPools = new List<ParticleToPool>();
            _particleToPool = particleSystem;
            _particleSystem = particleSystem.GetParticleSystem();
            particleSystem.Destroyed += Clear;
            _particleToPools.Add(particleSystem);
        }
        private void Clear()
        {
            foreach (var particle in _activatedParticle)
            {
                particle.Destroyed -= Clear;
                particle.PlayEnded -= AddParticle;
            }

            foreach (var particle in _particleToPools)
            {
                particle.Destroyed -= Clear;
            }
        }

        public void Play(Vector3 position, Vector3 direction)
        {
            ParticleToPool particleToPool;
            if (_particleToPools.Count > 0)
            {
                particleToPool = _particleToPools[0];
                _particleToPools.Remove(particleToPool);
            }
            else
            {
                particleToPool = Object.Instantiate(_particleToPool);
                particleToPool.Init(_particleSystem);
            }

            _activatedParticle.Add(particleToPool);
            particleToPool.PlayEnded += AddParticle;
            particleToPool.Play(position, direction);
        }

        private void AddParticle(ParticleToPool particleToPool)
        {
            particleToPool.PlayEnded -= AddParticle;
            _activatedParticle.Remove(particleToPool);
            _particleToPools.Add(particleToPool);
        }
    }
}