using System;
using System.Collections.Generic;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletsType
{
    public class SimpleBullet : Bullet
    {
        [SerializeField] private Rigidbody _rigidbody;
        private List<IEffectProvider> _effectProviders = new List<IEffectProvider>();

        private void OnCollisionEnter(Collision other)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            
            if (other.collider.TryGetComponent(out IEffectProvider effectProvider))
            {
                _effectProviders.Add(effectProvider);
            }

            Shooting(other.transform);
        }

        public override void Shoot(Vector3 startPosition, Vector3 direction)
        {
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
            transform.position = startPosition;
            transform.LookAt(startPosition + direction);
            gameObject.SetActive(true);
        }

        protected override void SpecialInit(BulletConfiguration bulletConfiguration)
        {
            
        }

        private void Update()
        {
            transform.position += transform.forward * (_speed * Time.deltaTime);
        }

        protected override void Shooting(Transform target)
        {
            DoEffects(_effectProviders, target);
            PlayAudio();
            _particlePool.Play(transform.position, transform.forward);
            gameObject.SetActive(false);
            Notify();
        }
    }
}