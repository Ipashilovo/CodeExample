using System;
using System.Collections.Generic;
using BulletData.BulletEffect;
using ShootedObjects;
using UnityEngine;

namespace BulletData.BulletsType
{
    public class LaserBullet : Bullet
    {
        private List<IEffectProvider> _list = new List<IEffectProvider>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEffectProvider effectProvider))
            {
                _list.Add(effectProvider);
            }
            Shooting(other.transform);
        }

        public override void Shoot(Vector3 startPosition, Vector3 direction)
        {
            Debug.Log("Shoot");
            transform.position = startPosition;
            gameObject.SetActive(true);
        }

        protected override void SpecialInit(BulletConfiguration bulletConfiguration)
        {
            
        }

        protected override void Shooting(Transform target)
        {
            DoEffects(_list, target);
            Notify();
            _list.Clear();
            gameObject.SetActive(false);
        }
    }
}