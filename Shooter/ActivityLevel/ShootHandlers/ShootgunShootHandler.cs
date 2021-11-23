using System;
using System.Collections;
using BulletData.BulletsType;
using DefaultNamespace.Input;
using Gun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ActivityLevel.ShootHandlers
{
    public class ShootgunShootHandler : ShootHandler
    {
        private int _bulletCount;
        private float _maxRotatePower;

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

        public void SetCount(int count)
        {
            _bulletCount = count;
        }

        public void SetRotate(float rotate)
        {
            _maxRotatePower = rotate;
        }

        private void Shoot()
        {
            for (int i = 0; i < _bulletCount; i++)
            {
                Shooted?.Invoke();
                var bullet = _bulletPool.GetBullet();
                Vector3 startPosition = Camera.main.transform.position;
                Vector3 forward = Camera.main.transform.forward;
                Vector3 rotatePower = new Vector3(Random.Range(-_maxRotatePower, _maxRotatePower),
                    Random.Range(-_maxRotatePower, _maxRotatePower), Random.Range(-_maxRotatePower, _maxRotatePower));
                forward = (forward + rotatePower).normalized;
                bullet.Shoot(startPosition + forward * 2, forward);
            }
            
            PlayShootAnimation(_gunForShoot.Cooldown);
        }
    }
}