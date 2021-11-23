using System;
using System.Collections;
using BulletData.BulletsType;
using DefaultNamespace.Input;
using DG.Tweening;
using Gun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ActivityLevel.ShootHandlers
{
    public class LaserShootgunShootHandler : ShootHandler, IValueCanger
    {
        private ParticleProvider[] _particleProviders = new ParticleProvider[4];
        private float _offcet;
        private float _maxOffcet;

        private Vector3[] _currentOffcets;
        private float _cooldownMultiplate;
        private float _currentCooldown;

        private float _timeToHot;
        private float _coolTimeMultipler;

        private float _currentHotTime;

        private bool _isOverheat;
        private bool _isShooting;

        public event Action<float> ValueChanged;
        public override event Action Shooted;


        protected override void ChildOnEnable()
        {
            _inputFolder.ClickEnded += EndShoot;
            _inputFolder.ClickStarted += StartShoot;
        }

        protected override void ClildOnDisable()
        {
            _inputFolder.ClickEnded -= EndShoot;
            _inputFolder.ClickStarted -= StartShoot;
            EndShoot();
        }

        protected override void ChildOnDestroy()
        {
            _inputFolder.ClickEnded -= EndShoot;
            _inputFolder.ClickStarted -= StartShoot;
        }

        protected override void ChildInit(Bullet bullet, GunForShoot gunForShoot)
        {
            _currentCooldown = _gunForShoot.Cooldown / _cooldownMultiplate;
            _particleProviders[0] = _particleSystem;
            for (int i = 1; i < _particleProviders.Length; i++)
            {
                _particleProviders[i] = _particleSystem.Copy();
            }
        }

        private void Update()
        {
            if (_isShooting)
            {
                LaserShooting();
                _currentHotTime += Time.deltaTime;
                StopShootingIfNeeded();
            }
            else
            { 
                _currentHotTime -= Time.deltaTime * _coolTimeMultipler; 
                _currentHotTime = _currentHotTime < 0 ? 0 : _currentHotTime;
            }
            ValueChanged?.Invoke(_currentHotTime);
        }

        private void LaserShooting()
        {
            _cooldownTime += Time.deltaTime;
            for (int i = 0; i < _particleProviders.Length; i++)
            {
                _currentOffcets[i] = SetOffcet(_currentOffcets[i]);
                PlayProvider(_particleProviders[i], _gunForShoot.GetShootForwardDirection() +_currentOffcets[i]);
            }
            
            if (_cooldownTime > _currentCooldown)
            {
                Vibrate();
                Shooted?.Invoke();
                for (int i = 0; i < _particleProviders.Length; i++)
                {
                    CreateBullet(_gunForShoot.GetShootForwardDirection() +_currentOffcets[i]);
                }
                _cooldownTime = 0;
            }
        }

        public void SetSpecialInit(float multiplate, float timeToHot, float coolMultipler)
        {
            _timeToHot = timeToHot;
            _coolTimeMultipler = coolMultipler;
            _cooldownMultiplate = multiplate;
        }
        
        private void StopShootingIfNeeded()
        {
            if (_currentHotTime >= _timeToHot)
            {
                EndShoot();
            }
        }

        private void PlayProvider(ParticleProvider particleProvider, Vector3 offcet)
        {
            particleProvider.Play(_gunForShoot.GetShootPosition(), offcet);
        }

        private void CreateBullet(Vector3 offcet)
        {
            Ray ray = new Ray(_gunForShoot.GetShootPosition(), offcet); 
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var bullet = _bulletPool.GetBullet();
                bullet.transform.position = hit.transform.position;
                bullet.gameObject.SetActive(true);
            }
        }

        private Vector3 SetOffcet(Vector3 offcet)
        {
            Vector3 startDitaction = _gunForShoot.GetShootForwardDirection();
            Vector3 currentOffcet =
                offcet + new Vector3(Random.Range(-_offcet, _offcet) * Time.deltaTime, Random.Range(-_offcet, _offcet) * Time.deltaTime, Random.Range(-_offcet, _offcet) * Time.deltaTime);
            float distance = Vector3.Distance(startDitaction, currentOffcet);
            if (distance <= _maxOffcet)
            {
                offcet = currentOffcet;
            }

            return offcet;
        }

        public void SetOffcets(float maxOffcet, float offcet)
        {
            _maxOffcet = maxOffcet;
            _offcet = offcet;
        }

        public float GetMaxValue()
        {
            return _timeToHot;
        }

        private void StartShoot()
        {
            _particleSystem.Play(_gunForShoot.GetShootPosition(), _gunForShoot.GetShootForwardDirection());
            _cooldownTime = 0;
            _currentOffcets = new Vector3[_particleProviders.Length];
            for (int i = 0; i < _currentOffcets.Length; i++)
            {
                _currentOffcets[i] = Vector3.zero;
            }

            _isShooting = true;
        }

        private void EndShoot()
        {
            foreach (var particleProvider in _particleProviders)
            {
                particleProvider.Stop();
            }

            _isShooting = false;
        }
    }
}