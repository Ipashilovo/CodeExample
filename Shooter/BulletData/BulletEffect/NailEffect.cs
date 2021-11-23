using System.Collections.Generic;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletEffect
{
    public class NailEffect : Effect
    {
        public override void DoEffect(List<IEffectProvider> providers, HitInfo hitInfo)
        {
            Ray ray = new Ray(hitInfo.StartPosition, hitInfo.ForwardDirection);
            if (Physics.Raycast(ray, out RaycastHit hit, 10, LayerMask.GetMask("Default")))
            {
                foreach (var provider in providers)
                {
                    if (provider.TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider))
                    {
                        physicsEffectProvider.SetMagnite(hit);
                    }
                }
            }
        }
    }
}