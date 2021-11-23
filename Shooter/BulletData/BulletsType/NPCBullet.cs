using UnityEngine;

namespace BulletData.BulletsType
{
    public class NPCBullet : Bullet
    {
        private void Update()
        {
            transform.position += transform.forward * (_speed * Time.deltaTime);
        }
        
        public override void Shoot(Vector3 startPosition, Vector3 direction)
        {
            transform.position = startPosition;
            transform.LookAt(startPosition + direction);
            gameObject.SetActive(true);
        }

        protected override void SpecialInit(BulletConfiguration bulletConfiguration)
        {
        }

        protected override void Shooting(Transform target)
        {
        }
    }
}