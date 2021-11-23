using UnityEngine;

namespace Stickmans.Weapons
{
    public class StickmanWeapon : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;

        public void Drop()
        {
            transform.parent = null;
            _collider.enabled = true;
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(Vector3.up);
        }
    }
}