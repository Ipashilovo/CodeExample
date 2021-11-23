using System;
using DG.Tweening;
using Gun.GunShootAnimations;
using UnityEngine;

namespace Gun
{
    public class GunForShoot : MonoBehaviour
    {
        [SerializeField] private ShootCooldown _shootCooldown;
        [SerializeField] private Transform _shootPosition;
        [SerializeField, Min(1f)] private float _shootAnimationScale;
        [SerializeField, Min(1f)] private float _firstAnimationScale;
        [SerializeField, Min(1f)] private float _moveScale;
        [SerializeField] private GunShootAnimation[] _gunShootAnimations; 

        public float Cooldown => _shootCooldown.Cooldown;

        public Vector3 GetShootPosition()
        {
            return _shootPosition.position;
        }

        public Vector3 GetShootForwardDirection()
        {
            return _shootPosition.forward;
        }

        public void PlayShoot(float time)
        {
            time /= _shootAnimationScale;
            foreach (var gunShootAnimation in _gunShootAnimations)
            {
                gunShootAnimation.Animate(time);
            }
            float fistTime = time / _firstAnimationScale;
            Vector3 currentPosition = transform.localPosition;
            DOTween.Sequence().Append(transform.DOMove(transform.position - transform.forward/_moveScale, fistTime))
                .Append(transform.DOLocalMove(currentPosition, time - fistTime));
        }

        public void SetLookAt(Vector3 position)
        {
            transform.LookAt(position);
        }

        public Vector3 GetFowardDirection()
        {
            return transform.forward;
        }
    }
}