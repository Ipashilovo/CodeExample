using ActivityLevel;
using LevelSystem;
using UnityEngine;

namespace Stickmans
{
    public class StickmanShootHandler
    {
        private readonly BulletPool _bulletPool;
        private readonly Transform _shootPosition;
        private readonly int _damage;
        private readonly float _offcet;

        public StickmanShootHandler(BulletPool bulletPool, Transform shootPosition, int damage, float offcet)
        {
            _bulletPool = bulletPool;
            _shootPosition = shootPosition;
            _damage = damage;
            _offcet = offcet;
        }

        public void Shoot(PlayerFacade damageTaker)
        {
            var bullet = _bulletPool.GetBullet();
            Vector3 endPosition = damageTaker.transform.position;
            endPosition += new Vector3(Random.Range(-_offcet, _offcet), Random.Range(-_offcet, _offcet), 0);
            Vector3 direction = (endPosition - _shootPosition.position).normalized;
            bullet.Shoot(_shootPosition.position, direction);
            damageTaker.TakeDamageAfterDelay(_damage, 0.5f);
        }
    }
}