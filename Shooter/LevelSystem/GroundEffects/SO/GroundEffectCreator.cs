using Gun;
using LevelSystem.GroundEffects;
using UnityEngine;

namespace ActivityLevel.ShootHandlers.GroundEffects.SO
{
    public abstract class GroundEffectCreator : ScriptableObject
    {
        [SerializeField] private ElementalType _elementalType;

        public ElementalType Type => _elementalType;

        public GroundEffectPool GetPool()
        {
            var effect = CreateGroundEffect();
            var pool = new GroundEffectPool(effect);
            return pool;
        }
        
        protected abstract GroundEffect CreateGroundEffect();
    }
}