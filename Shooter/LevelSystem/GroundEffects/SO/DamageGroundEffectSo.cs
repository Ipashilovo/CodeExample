using ActivityLevel.ShootHandlers.GroundEffects.SO;
using UnityEngine;

namespace LevelSystem.GroundEffects.SO
{
    [CreateAssetMenu(fileName = "DamageGroundEffectSo", menuName = "ScriptableObjects/GroundEffects/DamageGroundEffectSo", order = 1)]
    public class DamageGroundEffectSo : GroundEffectCreator
    {
        [SerializeField] private float _damage;
        [SerializeField] private DamageGroundEffect _damageGroundEffect;
        
        protected override GroundEffect CreateGroundEffect()
        {
            var groundEffect = Instantiate(_damageGroundEffect);
            groundEffect.Init(_damage);
            return groundEffect;
        }
    }
}