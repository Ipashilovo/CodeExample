using System.Collections.Generic;
using BulletData.BulletsType;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public class ForceEffect : Effect
    {
        private float _forcePower;

        public ForceEffect(float forcePower)
        {
            _forcePower = forcePower;
        }

        public override void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo)
        {
            foreach (var effectProvider in providers)
            {
                if (effectProvider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
                {
                    Vector3 position = effectProvider.GetPosition();
                    Vector3 direction = (position - hitInfo.StartPosition).normalized;
                    physicsEffectProvider.AddForce(direction * _forcePower);
                }
            }
        }
    }
}