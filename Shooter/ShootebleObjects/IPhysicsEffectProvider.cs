using UnityEngine;

namespace ShootedObjects
{
    public interface IPhysicsEffectProvider
    {
        public void Burn();
        public void SetMagnite(Transform point);
        public void SetMagnite(RaycastHit hit);
        public void AddForce(Vector3 force);
        public void Freeze(float freezeValue);
    }
}