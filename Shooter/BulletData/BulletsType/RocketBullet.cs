using System;
using System.Collections.Generic;
using BulletData.BulletEffect;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletsType
{
    public class RocketBullet : Bullet
    {
        [SerializeField] private TriggerHandler _triggerHandler;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _forcePower = 10;
        private List<IEffectProvider> _effectProviders = new List<IEffectProvider>();

        protected override void OnEnable()
        {
            base.OnEnable();
            _triggerHandler.ColliderFinded += OnTriggerEntered;
            _triggerHandler.ColliderLoosed += OnTriggerExited;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _triggerHandler.ColliderFinded -= OnTriggerEntered;
            _triggerHandler.ColliderLoosed -= OnTriggerExited;
        }

        private void OnTriggerEntered(Collider other)
        {
            if (other.TryGetComponent(out IEffectProvider effectProvider))
            {
                _effectProviders.Add(effectProvider);
            }
        }

        private void OnTriggerExited(Collider other)
        {
            if (other.TryGetComponent(out IEffectProvider effectProvider))
            {
                _effectProviders.Remove(effectProvider);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Shooting(other.transform);
        }

        private void Update()
        {
            transform.position += transform.forward * (Time.deltaTime * _speed);
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

        protected override void Shooting(Transform target)
        {
            _particlePool.Play(transform.position, transform.forward);
            PlayAudio();
            DoEffects(_effectProviders, target);
            gameObject.SetActive(false);
            Notify();
        }
    }
}