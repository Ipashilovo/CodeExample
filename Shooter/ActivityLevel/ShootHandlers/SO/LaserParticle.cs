using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "LaserParticleByType", menuName = "ScriptableObjects/Particle/LaserParticleByType", order = 1)]
    public class LaserParticle : ParticleByElementalType
    {
        [SerializeField] private EGA_Laser _egaLaser;
        public override ParticleProvider GetParticle()
        {
            var particle = Instantiate(_egaLaser);
            particle.gameObject.SetActive(false);
            return new LaserProvider(particle);
        }
    }
}