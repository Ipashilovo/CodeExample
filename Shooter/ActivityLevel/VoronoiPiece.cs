using System;
using DG.Tweening;
using UnityEngine;

namespace ActivityLevel
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class VoronoiPiece : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Collider _collider;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public void EnablePhysics()
        {
            _collider.enabled = true;
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
        }

        public void AddForce(Vector3 forcePower)
        {
            _rigidbody.AddForce(forcePower, ForceMode.Impulse);
        }
    }
}