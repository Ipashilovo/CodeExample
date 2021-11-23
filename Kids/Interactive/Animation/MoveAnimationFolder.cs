using System;
using DG.Tweening;
using Move.Animation;
using Player;
using UnityEngine;

namespace Interactive.Animation
{
    public class MoveAnimationFolder : AnimationFolder
    {
        [SerializeField] private float _time;
        [SerializeField] private float _speed;
        [SerializeField] private float[] _timeScale;
        private int _currentScaleNumber;
        private int _scale = 1;
        private float _currentTime;

        public override void Animate(ISkeletonHandler skeletonHandler)
        {
            _currentTime = 0;
            enabled = true;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            _currentTime += deltaTime;

            transform.position += Vector3.right * (_scale * deltaTime * _speed * _timeScale[_currentScaleNumber]);
            if (_currentTime >= _time / _timeScale[_currentScaleNumber])
            {
                _currentScaleNumber++;
                _currentScaleNumber %= _timeScale.Length;
                enabled = false;
                Rotate();
                Notify();
            }
        }

        public void Rotate()
        {
            _scale *= -1;
        }
    }
}