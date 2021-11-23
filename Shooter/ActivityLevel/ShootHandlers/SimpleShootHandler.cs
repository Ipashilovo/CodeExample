using System;
using System.Collections;
using BulletData.BulletsType;
using DefaultNamespace.Input;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public class SimpleShootHandler : ShootHandler
    {
        private bool _isShooting;

        public override event Action Shooted;

        protected override void ChildInit(Bullet bullet, GunForShoot gunForShoot)
        {
        }

        protected override void ChildOnEnable()
        {
            _inputFolder.ClickStarted += StartShooting;
            _inputFolder.ClickEnded += EndShoot;
        }

        protected override void ClildOnDisable()
        {
            _inputFolder.ClickStarted -= StartShooting;
            _inputFolder.ClickEnded -= EndShoot;
        }

        protected override void ChildOnDestroy()
        {
            _inputFolder.ClickStarted -= StartShooting;
            _inputFolder.ClickEnded -= EndShoot;
        }

        private void Update()
        {
            _cooldownTime += Time.deltaTime;
            
            if (!_isShooting) return;

            if (_cooldownTime > _gunForShoot.Cooldown)
            {
                Vibrate();
                _cooldownTime = 0;
                Shoot();
            }
        }


        private void EndShoot()
        {
            _isShooting = false;
        }

        private void StartShooting()
        {
            _isShooting = true;
        }

        private void Shoot()
        {
            Shooted?.Invoke();
            var bullet = _bulletPool.GetBullet();
            Vector3 startPosition = Camera.main.transform.position;
            Vector3 forward = Camera.main.transform.forward;
            bullet.Shoot(startPosition + forward, forward);
            PlayShootAnimation(_gunForShoot.Cooldown);
        }
    }
}