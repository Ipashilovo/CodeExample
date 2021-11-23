using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ActivityLevel.ShootHandlers;
using BulletData.BulletEffect;
using DefaultNamespace;
using Effects;
using Gun.Elements;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletsType
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField, Min(8f)] private float _maxTimeForBullet = 10;
        [SerializeField] private MeshRenderer _meshRenderer;
        private BulletConfiguration _bulletConfiguration;
        private TrailParticle _trailParticle;
        private Coroutine _coroutine;
        protected ParticlePool _particlePool;
        protected List<Effect> _effects = new List<Effect>();
        protected float _speed;

        public event Action<Bullet> Shooted;

        protected virtual void OnEnable()
        {
            if (_trailParticle != null)
            {
                _trailParticle.StartMoving();
            }

            _coroutine = StartCoroutine(DisableAfterDelay());
        }

        protected virtual void OnDisable()
        {
            if (_trailParticle != null)
            {
                _trailParticle.StopMoving();
            }

            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public void OnDestroy()
        {
            foreach (var effect in _effects)
            {
                effect.Clear();
            }
        }
        
        public abstract void Shoot(Vector3 startPosition, Vector3 direction);

        public void Init(BulletConfiguration bulletConfiguration)
        {
            _bulletConfiguration = bulletConfiguration;
            _meshRenderer.material.color = bulletConfiguration.GetColor();
            _effects = bulletConfiguration.GetEffects().ToList();
            _particlePool = bulletConfiguration.GetParticlePool();
            _speed = bulletConfiguration.GetSpeed();
            _audioSource.clip = bulletConfiguration.GetClip();
            SpecialInit(bulletConfiguration);
        }

        protected abstract void SpecialInit(BulletConfiguration bulletConfiguration);
        
        protected void DoEffects(List<IEffectProvider> effectProviders, Transform target)
        {
            HitInfo hitInfo = new HitInfo(target, transform.forward, transform.position);
            foreach (var effect in _effects)
            {
                effect.DoEffect(effectProviders, hitInfo);
            }
            effectProviders.Clear();
        }

        public BulletConfiguration GetBulletConfiguration()
        {
            return _bulletConfiguration;
        }

        protected abstract void Shooting(Transform target);

        protected void Notify()
        {
            Shooted?.Invoke(this);
        }

        protected void PlayAudio()
        {
            _audioSource.Play();
        }

        public void SetTrailParticle(TrailParticle trailParticle)
        {
            _trailParticle = trailParticle;
            _trailParticle.SetTarget(transform);
        }

        public Bullet Clone()
        {
            var bullet = Instantiate(this);
            bullet.Init(_bulletConfiguration);
            bullet.gameObject.SetActive(false);
            if (_trailParticle != null)
            {
                var trailParticle = Instantiate(_trailParticle);
                trailParticle.gameObject.SetActive(false);
                bullet.SetTrailParticle(trailParticle);
            }
            return bullet;
        }

        private IEnumerator DisableAfterDelay()
        {
            yield return new WaitForSeconds(_maxTimeForBullet);
            Notify();
            gameObject.SetActive(false);
            _coroutine = null;
        }
    }
}