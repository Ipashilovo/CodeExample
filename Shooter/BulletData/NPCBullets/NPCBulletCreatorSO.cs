using System.Collections.Generic;
using BulletData.BulletEffect;
using BulletData.BulletsType;
using BulletData.View;
using Effects;
using Gun;
using UnityEngine;

namespace BulletData.NPCBullets
{
    [CreateAssetMenu(fileName = "NPCBulletCreatorSO", menuName = "ScriptableObjects/Bullet/NPCBulletCreatorSO", order = 1)]
    public class NPCBulletCreatorSO : ScriptableObject
    {
        [SerializeField] private TrailParticleSo _trailParticleSo;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private float _speed;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Color _color;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private DamageMultiplicate _damage;

        public Bullet CreateBullet()
        {
            Effect[] effectsList = {new SimpleDamage(_damage.Multiplicate)};
            var particle = new GameObject().AddComponent<ParticleToPool>();
            particle.Init(_particleSystem);
            ParticlePool particlePool = new ParticlePool(particle);
            BulletConfiguration configuration =
                new BulletConfiguration(_color, effectsList, particlePool, _speed, ElementalType.None, _audioClip);
            var bullet = Instantiate(_bullet);
            bullet.Init(configuration);
            bullet.SetTrailParticle(_trailParticleSo.GetParticle());
            return bullet;
        }
    }
}