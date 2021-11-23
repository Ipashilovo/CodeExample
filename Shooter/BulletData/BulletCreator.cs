using System.Collections.Generic;
using System.Linq;
using BulletData.BulletEffect;
using BulletData.BulletsType;
using Effects;
using Gun;
using UnityEngine;

namespace BulletData
{
    public class BulletCreator : MonoBehaviour
    {
        [SerializeField] private BulletModelBase[] _bulletModels;
        
        public Bullet CreateBullet(GunSaveData gunSaveData, DamageMultiplicate damageMultiplicate, GunSO gunSo)
        {
            var bulletModel = _bulletModels.First(m => m.Type == gunSaveData.Bullet);
            var bullet = bulletModel.CreateBullet(gunSaveData, damageMultiplicate, gunSo);
            return bullet;
        }
    }
}