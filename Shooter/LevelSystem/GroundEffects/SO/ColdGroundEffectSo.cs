using ActivityLevel.ShootHandlers.GroundEffects;
using ActivityLevel.ShootHandlers.GroundEffects.SO;
using UnityEngine;

namespace LevelSystem.GroundEffects.SO
{
    [CreateAssetMenu(fileName = "ColdGroundEffectSo", menuName = "ScriptableObjects/GroundEffects/ColdGroundEffectSo", order = 1)]
    public class ColdGroundEffectSo : GroundEffectCreator
    {
        [SerializeField] private ColdGroundEffect _coldGroundEffect;
        [SerializeField] private float _coldValue;
        
        protected override GroundEffect CreateGroundEffect()
        {
            var coldEffect = Instantiate(_coldGroundEffect);
            coldEffect.SetValue(_coldValue);
            coldEffect.gameObject.SetActive(false);
            return coldEffect;
        }
    }
}