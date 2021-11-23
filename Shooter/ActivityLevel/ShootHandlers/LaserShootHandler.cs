using System;
using System.Collections;
using BulletData.BulletsType;
using DefaultNamespace.Input;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public class LaserShootHandler : ShootHandler, IValueCanger
    {
        private float _currentCooldown;
        private float _timeToHot;
        private float _coolTimeMultipler;
        private float _cooldownMultiplate;

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
        }

        private void Update()
        {
            if (_isShooting)
            {
                TryToShoot();
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

        private void StopShootingIfNeeded()
        {
            if (_currentHotTime >= _timeToHot)
            {
                EndShoot();
            }
        }

        private void TryToShoot()
        {
            _particleSystem.Play(_gunForShoot.GetShootPosition(), _gunForShoot.GetShootForwardDirection());
            _cooldownTime += Time.deltaTime;
            if (_cooldownTime > _currentCooldown)
            {
                Vibrate();
                Shooted?.Invoke();
                _cooldownTime = 0;
                Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    var bullet = _bulletPool.GetBullet();
                    bullet.transform.position = hit.transform.position;
                    bullet.gameObject.SetActive(true);
                }
            }
        }

        public void SetSpecialInit(float multiplate, float timeToHot, float coolMultipler)
        {
            _timeToHot = timeToHot;
            _coolTimeMultipler = coolMultipler;
            _cooldownMultiplate = multiplate;
        }

        public float GetMaxValue()
        {
            return _timeToHot;
        }

        private void StartShoot()
        {
            _isShooting = true;
            _particleSystem.Play(_gunForShoot.GetShootPosition(), _gunForShoot.GetFowardDirection());
            _cooldownTime = 0;
        }

        private void EndShoot()
        {
            _isShooting = false;
            _particleSystem.Stop();
        }
    }
}