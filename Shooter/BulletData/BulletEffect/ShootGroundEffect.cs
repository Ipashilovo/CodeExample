using System.Collections.Generic;
using ActivityLevel.ShootHandlers.GroundEffects;
using LevelSystem.GroundEffects;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public class ShootGroundEffect : Effect
    {
        private GroundEffectPool _groundEffectPool;
        
        public ShootGroundEffect(GroundEffectPool groundEffectPool)
        {
            _groundEffectPool = groundEffectPool;
        }
        
        public override void Clear()
        {
            _groundEffectPool.Clear();
        }

        public override void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo)
        {
            var groundEffect = _groundEffectPool.GetGroundEffect();
            groundEffect.Effect(hitInfo.StartPosition);
        }
    }
}