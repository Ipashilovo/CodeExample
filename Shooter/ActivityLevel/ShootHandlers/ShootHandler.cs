using System;
using System.Collections;
using ActivityLevel.Reward;
using AndroidNativeCore;
using BulletData.BulletsType;
using DefaultNamespace.Input;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class ShootHandler : MonoBehaviour, IShootable
    {
        protected BulletPool _bulletPool;
        protected GunForShoot _gunForShoot;
        protected ParticleProvider _particleSystem;
        protected float _cooldownTime;
        protected InputFolder _inputFolder;
        private EndLevelLisener _endLevelLisener;
        private long _vibrationTime;
        private Coroutine _vibratorCooldown;

        private void OnDestroy()
        {
            _bulletPool.Clear();
            ChildOnDestroy();
            _endLevelLisener.LevelEnded -= HideGun;
        }

        private void OnEnable()
        {
            ChildOnEnable();
        }

        private void OnDisable()
        {
            ClildOnDisable();
        }

        protected abstract void ChildOnEnable();

        protected abstract void ClildOnDisable();

        protected abstract void ChildOnDestroy();
        
        public void SetParticle(ParticleProvider particleSystem)
        {
            _particleSystem = particleSystem;
        }

        public void Init(Bullet bullet, GunForShoot gunForShoot, InputFolder inputFolder)
        {
            _inputFolder = inputFolder;
            _gunForShoot = gunForShoot;
            _bulletPool = new BulletPool(bullet);
            ChildInit(bullet, gunForShoot);
        }

        protected abstract void ChildInit(Bullet bullet, GunForShoot gunForShoot);

        protected void PlayShootAnimation(float time)
        {
            _particleSystem.Play(_gunForShoot.GetShootPosition(), Vector3.zero);
            _gunForShoot.PlayShoot(time);
        }

        public abstract event Action Shooted;

        public void SetEndLevelLisener(EndLevelLisener endLevelLisener)
        {
            _endLevelLisener = endLevelLisener;
            _endLevelLisener.LevelEnded += HideGun;
        }

        private void HideGun()
        {
            _gunForShoot.gameObject.SetActive(false);
            enabled = false;
        }

        protected void Vibrate()
        {
            if (_vibratorCooldown != null) return;
            _vibratorCooldown = StartCoroutine(VibratorCooldown());
            Vibrator.Vibrate(_vibrationTime);
        }

        public void SetVibratoValue(long vibrateValue)
        {
            _vibrationTime = vibrateValue;
        }

        private IEnumerator VibratorCooldown()
        {
            float time = 0.2f;
            yield return new WaitForSeconds(time);
            _vibratorCooldown = null;
        }
    }
}