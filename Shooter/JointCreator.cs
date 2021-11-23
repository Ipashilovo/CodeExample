using BulletData;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class JointCreator
    {
        private Rigidbody _rigidbody;
        private Transform _point;

        public float Time { get; private set; }

        public void CreateJoint(Rigidbody rigidbody, Transform point, float speed)
        {
            _rigidbody = rigidbody;
            _point = point;
            Time = CalculateTime(rigidbody.position, point.position, speed);
            rigidbody.DOMove(point.position - (point.position - rigidbody.position).normalized, Time).OnComplete(TryCreateJoint);
        }

        public void CreateJoint(Rigidbody rigidbody, RaycastHit hitInfo, float speed)
        {
            _rigidbody = rigidbody;
            _point = hitInfo.transform;
            Time = CalculateTime(rigidbody.position, hitInfo.point, speed);
            rigidbody.DOMove(hitInfo.point, Time).OnComplete(TryCreateJoint);
        }

        private float CalculateTime(Vector3 startPosition, Vector3 endPosition, float speed)
        {
            float distance = Vector3.Distance(startPosition, endPosition);
            return distance / speed;
        }

        private void TryCreateJoint()
        {
            if (!_point.gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                _point.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            }

            _point.gameObject.AddComponent<FixedJoint>().connectedBody = _rigidbody;
        }
    }
}