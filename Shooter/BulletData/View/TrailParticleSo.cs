using Effects;
using Gun;
using UnityEngine;

namespace BulletData.View
{
    [CreateAssetMenu(fileName = "TrailParticleSo", menuName = "ScriptableObjects/Bullet/TrailParticleSo", order = 1)]
    public class TrailParticleSo : ScriptableObject
    {
        [SerializeField] private ElementalType _elementalType;
        [SerializeField] private TrailParticle _trailParticle;

        public ElementalType Type => _elementalType;

        public TrailParticle GetParticle()
        {
            var particle = Instantiate(_trailParticle);
            return particle;
        }
    }
}