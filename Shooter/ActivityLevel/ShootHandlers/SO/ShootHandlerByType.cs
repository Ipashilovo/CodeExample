using System.Linq;
using ActivityLevel.ShootHandlers.SO;
using BulletData;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public abstract class ShootHandlerByType : ScriptableObject
    {
        [SerializeField] private long _vibrateValue;
        [SerializeField] private GunBase[] _gunBase;
        [SerializeField] private BulletType[] _bulletTypes;
        [SerializeField] protected ParticleByElementalType[] _particleByElementalType;

        public bool TryGetShootHandler(out ShootHandler shootHandler, GunSaveData gunSaveData, ElementalType effectType,
            GunModel gunModel)
        {
            shootHandler = null;
            if (_gunBase.Any(g => g == gunSaveData.Gun))
            {
                if (_bulletTypes.Any(b => b == gunSaveData.Bullet))
                {
                    shootHandler = CreateShootHandler(gunModel);
                    var particle = _particleByElementalType.First(p => p.Type == effectType).GetParticle();
                    shootHandler.SetVibratoValue(_vibrateValue);
                    shootHandler.SetParticle(particle);
                    return true;
                }
            }

            return false;
        }

        protected GameObject CreateEmptyGameObject()
        {
            var gameObject = new GameObject();
            gameObject.SetActive(false);
            return gameObject;
        }

        protected abstract ShootHandler CreateShootHandler(GunModel gunModel);
    }
}