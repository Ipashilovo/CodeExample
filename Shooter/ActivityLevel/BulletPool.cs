using System;
using System.Collections.Generic;
using BulletData;
using BulletData.BulletsType;
using Effects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ActivityLevel
{
    public class BulletPool
    {
        private Bullet _bullet;
        private List<Bullet> _bullets;
        private List<Bullet> _activityBuller;

        public BulletPool(Bullet bullet)
        {
            _bullet = bullet;
            _activityBuller = new List<Bullet>();
            _bullets = new List<Bullet>();
        }

        public void Clear()
        {
            foreach (var aBullet in _activityBuller)
            {
                aBullet.Shooted -= AddBullet;
            }
        }

        public Bullet GetBullet()
        {
            Bullet bullet;
            if (_bullets.Count <= 0)
            {
                bullet = _bullet.Clone();
            }
            else
            {
                bullet = _bullets[0];
                _bullets.Remove(bullet);
            }
            _activityBuller.Add(bullet);
            bullet.Shooted += AddBullet;
            return bullet;

        }

        private void AddBullet(Bullet bullet)
        {
            bullet.Shooted -= AddBullet;
            _activityBuller.Remove(bullet);
            _bullets.Add(bullet);
        }
    }
}