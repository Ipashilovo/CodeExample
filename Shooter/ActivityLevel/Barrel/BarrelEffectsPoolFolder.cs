using LevelSystem.GroundEffects;
using LevelSystem.GroundEffects.SO;
using UnityEngine;

namespace ActivityLevel.Barrel
{
    public class BarrelEffectsPoolFolder : MonoBehaviour
    {
        [SerializeField] private ForceGroundEffectSo _forceGroundEffectSo;
        [SerializeField] private DamageGroundEffectSo _damageGroundEffectSo;
        private GroundEffectPool _forcePool;
        private GroundEffectPool _damagePool;

        private void Awake()
        {
            _forcePool = _forceGroundEffectSo.GetPool();
            _damagePool = _damageGroundEffectSo.GetPool();
        }

        public GroundEffectPool GetForcePool()
        {
            return _forcePool;
        }

        public GroundEffectPool GetDamagePool()
        {
            return _damagePool;
        }
    }
}