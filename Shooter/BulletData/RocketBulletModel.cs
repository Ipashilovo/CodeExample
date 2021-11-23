using System.Collections.Generic;
using System.Linq;
using ActivityLevel.ShootHandlers.GroundEffects.SO;
using BulletData.BulletEffect;
using Gun;
using LevelSystem.GroundEffects;
using UnityEngine;

namespace BulletData
{
    [CreateAssetMenu(fileName = "RocketBulletModel", menuName = "ScriptableObjects/Bullet/RocketBulletModel", order = 1)]
    public class RocketBulletModel : BulletModelBase
    {
        [SerializeField] private GroundEffectCreator[] _groundEffectCreators;
        protected override void SpecialInit(GunSaveData gunSaveData, DamageMultiplicate damageMultiplicate,
            List<Effect> effects)
        {
            if (TryGetGroundEffect(out GroundEffectPool groundEffectPool, gunSaveData))
            {
                effects.Add(new ShootGroundEffect(groundEffectPool));
            }
        }

        private bool TryGetGroundEffect(out GroundEffectPool groundEffectPool, GunSaveData gunSaveData)
        {
            if (_groundEffectCreators.Any(g => g.Type == gunSaveData.Elemental))
            {
                GroundEffectCreator groundEffectCreator =
                    _groundEffectCreators.First(g => g.Type == gunSaveData.Elemental);
                groundEffectPool = groundEffectCreator.GetPool();
                return true;
            }

            groundEffectPool = null;
            return false;
        }
    }
}