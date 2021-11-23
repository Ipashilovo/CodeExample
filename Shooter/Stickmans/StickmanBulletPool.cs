using System;
using ActivityLevel;
using BulletData;
using BulletData.BulletsType;
using BulletData.NPCBullets;
using UnityEngine;

namespace Stickmans
{
    public class StickmanBulletPool : MonoBehaviour
    {
        [SerializeField] private NPCBulletCreatorSO _bulletModelBase;
        private BulletPool _bulletPool;

        private void Awake()
        {
            var bullet = _bulletModelBase.CreateBullet();
            _bulletPool = new BulletPool(bullet);
        }

        private void OnDestroy()
        {
            _bulletPool.Clear();
        }

        public BulletPool GetBulletPool()
        {
            return _bulletPool;
        }
    }
}