using System.Collections.Generic;
using BulletData.BulletsType;
using Gun;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public class SimpleDamage : Effect
    {
        private readonly float _damage;

        public SimpleDamage(float damage)
        {
            _damage = damage;
        }

        public override void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo)
        {
            foreach (var provider in providers)
            {
                provider.TakeDamage(_damage);
            }
        }
    }
}