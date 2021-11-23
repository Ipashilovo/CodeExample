using System;
using System.Collections.Generic;
using BulletData.BulletEffect;
using Gun;

namespace BulletData
{
    public class BulletEffectSelector
    {
        private Dictionary<BulletType, Type> _effectsByBulletType = new Dictionary<BulletType, Type>
        {
            {BulletType.Nail, typeof(NailEffect)}
        };
        
        public List<Effect> GetEffect(GunSaveData gunSaveData, float damageMultiplicate)
        {
            List<Effect> effects = new List<Effect>();
            SimpleDamage simpleDamage = new SimpleDamage(damageMultiplicate);
            effects.Add(simpleDamage);
            if (_effectsByBulletType.ContainsKey(gunSaveData.Bullet))
            {
                Type type = _effectsByBulletType[gunSaveData.Bullet];
                var bulletEffect = (Effect)Activator.CreateInstance(type);
                effects.Add(bulletEffect);
            }

            return effects;
        }
    }
}