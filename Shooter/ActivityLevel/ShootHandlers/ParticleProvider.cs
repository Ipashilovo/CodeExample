using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public abstract class ParticleProvider
    {
        public abstract void Play(Vector3 startPosition, Vector3 direction);
        public abstract void Stop();

        public abstract ParticleProvider Copy();

        public abstract void SetParent(Transform parent);
    }
}