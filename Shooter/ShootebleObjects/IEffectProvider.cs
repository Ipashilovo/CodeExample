using UnityEngine;

namespace ShootedObjects
{
    public interface IEffectProvider
    {
        public bool TryGetMainEffectProvider(out IMainEffectProvider mainEffectProvider);
        public void TakeDamage(float damage);
        public Vector3 GetPosition();
        public bool TryGetPhysicsEffectProvider(out IPhysicsEffectProvider physicsEffectProvider);
    }
}