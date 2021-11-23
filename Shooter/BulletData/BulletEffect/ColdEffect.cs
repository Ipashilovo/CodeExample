using System.Collections.Generic;
using BulletData.BulletsType;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public class ColdEffect : Effect
    {
        private float _coldValue;

        public ColdEffect(float coldValue)
        {
            _coldValue = coldValue;
        }

        public override void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo)
        {
            foreach (var provider in providers)
            {
                if (provider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
                {
                    physicsEffectProvider.Freeze(_coldValue);
                }
            }
        }
    }
}