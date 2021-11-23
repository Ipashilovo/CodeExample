using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "SimpleParticleByType", menuName = "ScriptableObjects/Particle/SimpleParticleByType", order = 1)]
    public class SimpleParticleByType : ParticleByElementalType
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public override ParticleProvider GetParticle()
        {
            var particle = Instantiate(_particleSystem);
            return new BulletProvider(particle);
        }
    }
}