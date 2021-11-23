using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    public abstract class ParticleByElementalType : ScriptableObject
    {
        [SerializeField] private ElementalType _elemental;
        public ElementalType Type => _elemental;

        public abstract ParticleProvider GetParticle();
    }
}