using UnityEngine;

namespace ShootedObjects
{
    public interface IMainEffectProvider
    {
        public void TakeDamage(float damage);
        public void TakeDamageOverTime(float damage, float time);
    }
}