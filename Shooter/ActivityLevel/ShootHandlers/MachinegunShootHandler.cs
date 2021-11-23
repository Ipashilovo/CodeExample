using System;
using System.Collections;
using BulletData.BulletsType;
using DefaultNamespace.Input;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public class MachinegunShootHandler : ShootHandler
    {
        private float _queueCount;
        private float _delayBetweenShoot;
        private bool _isShooting;

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
        }

        protected override void ChildOnDestroy()
        {
            _inputFolder.ClickEnded -= EndShoot;
            _inputFolder.ClickStarted -= StartShoot;
        }

        protected override void ChildInit(Bullet bullet, GunForShoot gunForShoot)
        {
        }

        private void Update()
        {
            if (!_isShooting) return;
            
            _cooldownTime += Time.deltaTime;
            if (_cooldownTime > _gunForShoot.Cooldown)
            {
                Vibrate();
                _cooldownTime = 0;
                Shoot();
            }
        }

        private void Shoot()
        {
            Shooted?.Invoke();
            _particleSystem.Play(_gunForShoot.GetShootPosition(), _gunForShoot.GetShootForwardDirection());
            var bullet = _bulletPool.GetBullet();
            Vector3 startPosition = Camera.main.transform.position;
            Vector3 forward = Camera.main.transform.forward;
            bullet.Shoot(startPosition + 3 * forward, forward);
            PlayShootAnimation(_gunForShoot.Cooldown);
        }

        private void StartShoot()
        {
            _cooldownTime = 0;
            Shoot();
            _isShooting = true;
        }

        private void EndShoot()
        {
            _isShooting = false;
        }
    }
}