using System;
using System.Collections;
using BulletData.BulletsType;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public class MachinegunRocketShootHandler : ShootHandler
    {
        private int _queueCount;
        private float _cooldownMultiple;
        private float _delayBetweenShoot;
        private Coroutine _coroutine;

        private bool _isShooting;

        public override event Action Shooted;

        protected override void ChildInit(Bullet bullet, GunForShoot gunForShoot)
        {
        }

        protected override void ChildOnEnable()
        {
            _inputFolder.ClickStarted += StartShoot;
            _inputFolder.ClickEnded += EndShoot;
        }

        protected override void ClildOnDisable()
        {
            _inputFolder.ClickStarted -= StartShoot;
            _inputFolder.ClickEnded -= EndShoot;
        }

        protected override void ChildOnDestroy()
        {
            _inputFolder.ClickStarted -= StartShoot;
            _inputFolder.ClickEnded -= EndShoot;
        }

        public void SetQueueData(int count, float delay, float cooldownMultipler)
        {
            _cooldownMultiple = cooldownMultipler;
            _queueCount = count;
            _delayBetweenShoot = delay;
        }

        private void EndShoot()
        {
            _isShooting = false;
        }

        private void StartShoot()
        {
            _isShooting = true;
        }

        private void Update()
        {
            _cooldownTime += Time.deltaTime;
            
            if (!_isShooting) return;

            if (_cooldownTime > _gunForShoot.Cooldown * _cooldownMultiple)
            {
                _cooldownTime = 0;
                StartCoroutine(Shooting());
            }
        }

        private IEnumerator Shooting()
        {
            for (int i = 0; i < _queueCount; i++)
            {
                Vibrate();
                Shooted?.Invoke();
                var bullet = _bulletPool.GetBullet();
                Vector3 startPosition = Camera.main.transform.position;
                Vector3 forward = Camera.main.transform.forward;
                bullet.Shoot(startPosition + 2 * forward, forward);
                yield return new WaitForSeconds(_delayBetweenShoot);
                PlayShootAnimation(_gunForShoot.Cooldown);
            }
        }
    }
}