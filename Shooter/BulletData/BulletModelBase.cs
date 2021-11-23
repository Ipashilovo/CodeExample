using System.Collections.Generic;
using System.Linq;
using ActivityLevel.ShootHandlers;
using BulletData.BulletEffect;
using BulletData.BulletsType;
using BulletData.View;
using Effects;
using Gun;
using UnityEngine;

namespace BulletData
{
    public abstract class BulletModelBase : ScriptableObject
    {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private TrailParticleSo[] _trailParticle;
        [SerializeField] private ParticleByElementalType[] _particleByElementalTypes;
        [SerializeField] private MaterialColorByElementalType[] _materialsByElementalType;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private BulletType _bulletType;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _damage = 1;

        public float Speed => Random.Range(_minSpeed, _maxSpeed);
        
        public BulletType Type => _bulletType;

        public Bullet CreateBullet(GunSaveData gunSaveData, DamageMultiplicate damageMultiplicate, GunSO gunSo)
        {
            var particleProvider = _particleByElementalTypes.First(p => p.Type == gunSaveData.Elemental).GetParticle();
            var material = _materialsByElementalType.First(m => m.Type == gunSaveData.Elemental).GetColor();
            List<Effect> effects = new BulletEffectSelector().GetEffect(gunSaveData, damageMultiplicate.Multiplicate * _damage);
            SpecialInit(gunSaveData, damageMultiplicate, effects);
            var newBullet = Instantiate(_bullet);
            ParticlePool particlePool = CreateParticlePool(particleProvider);
            BulletConfiguration bulletConfiguration = new BulletConfiguration(material, effects.ToArray(), particlePool, Speed * gunSo.SpeedMultipler, gunSaveData.Elemental, _audioClip);
            newBullet.Init(bulletConfiguration);
            var trail = _trailParticle.First(t => t.Type == gunSaveData.Elemental).GetParticle();
            newBullet.SetTrailParticle(trail);
            return newBullet;
        }
        
        private ParticlePool CreateParticlePool(ParticleSystem particleSystem)
        {
            ParticleToPool particleToPool = new GameObject().AddComponent<ParticleToPool>();
            particleToPool.Init(particleSystem);
            ParticlePool particlePool = new ParticlePool(particleToPool);
            return particlePool;
        }

        protected abstract void SpecialInit(GunSaveData gunSaveData, DamageMultiplicate damageMultiplicate, List<Effect> effects);
    }
}