using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    public class LaserProvider : ParticleProvider
    {
        private EGA_Laser _egaLaser;

        public LaserProvider(EGA_Laser egaLaser)
        {
            _egaLaser = egaLaser;
        }

        public override void Play(Vector3 startPosition, Vector3 direction)
        {
            _egaLaser.transform.position = startPosition;
            _egaLaser.transform.LookAt(startPosition + direction);
            _egaLaser.gameObject.SetActive(true);
        }

        public override void Stop()
        {
            _egaLaser.gameObject.SetActive(false);
        }

        public override ParticleProvider Copy()
        {
            var laser = Object.Instantiate(_egaLaser);
            ParticleProvider particleProvider = new LaserProvider(laser);
            return particleProvider;
        }

        public override void SetParent(Transform parent)
        {
            _egaLaser.transform.parent = parent;
        }
    }
}