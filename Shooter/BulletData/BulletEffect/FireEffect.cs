using System.Collections.Generic;
using BulletData.BulletsType;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public class FireEffect : Effect
    {
        private float _damage;
        private float _burningTime;

        public FireEffect(float damage, float burningTime)
        {
            _damage = damage;
            _burningTime = burningTime;
        }

        public override void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo)
        {
            foreach (var provider in providers)
            {
                if (provider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
                {
                    physicsEffectProvider.Burn();
                }

                if (provider.TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider))
                {
                    mainEffectProvider.TakeDamageOverTime(_damage, _burningTime);
                }
            }
        }
    }
}