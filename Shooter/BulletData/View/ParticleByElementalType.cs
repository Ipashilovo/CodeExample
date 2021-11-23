using ActivityLevel.ShootHandlers;
using DefaultNamespace;
using Gun;
using UnityEngine;

namespace BulletData.View
{
    [CreateAssetMenu(fileName = "ParticleByElementalType", menuName = "ScriptableObjects/Bullet/ParticleByElementalType", order = 1)]
    public class ParticleByElementalType : ScriptableObject
    {
        [SerializeField] private ElementalType _elementalType;
        [SerializeField] private ParticleSystem _particleSystem;

        public ElementalType Type => _elementalType;

        public ParticleSystem GetParticle()
        {
            return _particleSystem;
        }
    }
}