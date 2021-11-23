using ActivityLevel.ShootHandlers.GroundEffects;
using ActivityLevel.ShootHandlers.GroundEffects.SO;
using UnityEngine;

namespace LevelSystem.GroundEffects.SO
{
    [CreateAssetMenu(fileName = "FireGroundEffectSO", menuName = "ScriptableObjects/GroundEffects/FireGroundEffectSO", order = 1)]
    public class FireGroundEffectSo : GroundEffectCreator
    {
        [SerializeField] private FireGroundEffect _fireGroundEffect;
        [SerializeField] private float _damageInSec;
        
        protected override GroundEffect CreateGroundEffect()
        {
            FireGroundEffect groundEffect = Instantiate(_fireGroundEffect);
            groundEffect.Init(_damageInSec);
            groundEffect.gameObject.SetActive(false);
            return groundEffect;
        }
    }
}