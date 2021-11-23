using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public class BulletProvider : ParticleProvider
    {
        private ParticleSystem _particleSystem;

        public BulletProvider(ParticleSystem particleSystem)
        {
            _particleSystem = particleSystem;
        }

        public override void Play(Vector3 startPosition, Vector3 direction)
        {
            _particleSystem.transform.position = startPosition;
            _particleSystem.Play();
        }

        public override void Stop()
        {
            _particleSystem.Stop();
        }

        public override ParticleProvider Copy()
        {
            ParticleSystem particleSystem = Object.Instantiate(_particleSystem);
            ParticleProvider particleProvider = new BulletProvider(particleSystem);
            return particleProvider;
        }

        public override void SetParent(Transform parent)
        {
            _particleSystem.transform.parent = parent;
        }
    }
}