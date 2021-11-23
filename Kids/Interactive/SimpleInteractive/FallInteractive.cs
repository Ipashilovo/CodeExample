using System;
using LevelSystems;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Interactive
{
    public class FallInteractive : SimpleOneTimeInteractive
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Parallax _parallax;
        [SerializeField] private float _rotateValue = 3f;
        [SerializeField] private float _startForcePower = 2f;
        private bool _isFall;

        public override event Action Interacting;
        public override event Action EndInteracting;

        private void Update()
        {
            transform.Rotate(0,0,_rotateValue * Time.deltaTime);
        }

        public override void Interact(ISkeletonHandler skeletonHandler)
        {
            if (_isFall) return;

            if (_parallax != null)
            {
                _parallax.enabled = false;
            }

            _rotateValue = Random.Range(-_rotateValue, _rotateValue);
            Interacting?.Invoke();
            _isFall = true;
            _rigidbody.gravityScale = 1;
            enabled = true;
            _rigidbody.AddForce(Vector2.down * _startForcePower, ForceMode2D.Impulse);
        }
    }
}