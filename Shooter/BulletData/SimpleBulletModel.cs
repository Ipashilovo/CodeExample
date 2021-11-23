using System.Collections.Generic;
using System.Linq;
using ActivityLevel;
using ActivityLevel.ShootHandlers;
using BulletData.BulletEffect;
using BulletData.BulletsType;
using BulletData.View;
using Gun;
using UnityEngine;

namespace BulletData
{
    [CreateAssetMenu(fileName = "SimpleBulletModel", menuName = "ScriptableObjects/Bullet/SimpleBulletModel", order = 1)]
    public class SimpleBulletModel : BulletModelBase
    {
        [SerializeField] private float _baseFireDamage;
        [SerializeField] private float _burningTime;
        [SerializeField] private float _baseColdValue;

        protected override void SpecialInit(GunSaveData gunSaveData, DamageMultiplicate damageMultiplicate, List<Effect> effects)
        { 
            Effect effect = gunSaveData.Elemental switch
            {
                ElementalType.Fire => new FireEffect(_baseFireDamage * damageMultiplicate.Multiplicate, _burningTime),
                ElementalType.Cold => new ColdEffect(_baseColdValue),
                _ => null
            };

            if (effect != null)
            {
                effects.Add(effect);
            }
        }
    }
}