using System;
using BulletData.BulletsType;
using UnityEngine;

namespace Effects
{
    public class TrailParticle : MonoBehaviour
    {
        private Transform _target;


        private void Update()
        {
            transform.position = _target.position;
        }
        
        public void StopMoving()
        {
            gameObject.SetActive(false);
        }

        public void StartMoving()
        {
            transform.position = _target.position;
            gameObject.SetActive(true);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}