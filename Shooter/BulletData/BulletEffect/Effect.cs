using System.Collections.Generic;
using BulletData.BulletsType;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public abstract class Effect
    {
        public abstract void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo);

        public virtual void Clear()
        {
            
        }
        
    }
}