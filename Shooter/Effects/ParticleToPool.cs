using System;
using System.Collections;
using UnityEngine;

namespace Effects
{
    public class ParticleToPool : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private float _time;

        public event Action<ParticleToPool> PlayEnded;
        public event Action Destroyed;

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }

        public void Init(ParticleSystem particleSystem)
        {
            _particleSystem = Instantiate(particleSystem, transform);
            _particleSystem.transform.localPosition = Vector3.zero;
            _time = _particleSystem.main.duration;
        }

        public ParticleSystem GetParticleSystem()
        {
            return _particleSystem;
        }

        public void Play()
        {
            _particleSystem.Play();
            StartCoroutine(WaitPlayEnded());
        }

        public void Play(Vector3 position, Vector3 direction)
        {
            transform.position = position;
            transform.LookAt(position + direction);
            _particleSystem.Play();
            StartCoroutine(WaitPlayEnded());
        }

        private IEnumerator WaitPlayEnded()
        {
            yield return new WaitForSeconds(_time);
            PlayEnded?.Invoke(this);
        }
    }
}