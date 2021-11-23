using UnityEngine;

namespace BulletData
{
    public class HitInfo
    {
        public readonly Vector3 StartPosition;
        public readonly Vector3 ForwardDirection;
        public Transform Target;

        public HitInfo(Transform target, Vector3 forwardDirection, Vector3 startPosition)
        {
            Target = target;
            ForwardDirection = forwardDirection;
            StartPosition = startPosition;
        }
    }
}