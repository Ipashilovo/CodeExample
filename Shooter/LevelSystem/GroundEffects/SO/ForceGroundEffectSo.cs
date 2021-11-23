using ActivityLevel.ShootHandlers.GroundEffects;
using ActivityLevel.ShootHandlers.GroundEffects.SO;
using UnityEngine;

namespace LevelSystem.GroundEffects.SO
{
    [CreateAssetMenu(fileName = "ForceGroundEffectSo", menuName = "ScriptableObjects/GroundEffects/ForceGroundEffectSo", order = 1)]
    public class ForceGroundEffectSo : GroundEffectCreator
    {
        [SerializeField] private ForceGroundEffect _forceGroundEffect;
        [SerializeField] private float _power;
        
        protected override GroundEffect CreateGroundEffect()
        {
            ForceGroundEffect groundEffect = Instantiate(_forceGroundEffect);
            groundEffect.Init(_power);
            groundEffect.gameObject.SetActive(false);
            return groundEffect;
        }
    }
}