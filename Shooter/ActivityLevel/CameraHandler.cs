using System;
using System.Collections;
using UnityEngine;

namespace ActivityLevel
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private float _timeScale;
        [SerializeField] private float _duration;
        [SerializeField] private float _distanceMultiplayer = 0.5f;
        public event Action AnimationEnd;
        public void LookAtLastStickman(Transform target)
        {
            Vector3 direction = (transform.position - target.position.normalized).normalized;
            transform.position = target.position + direction * _distanceMultiplayer;
            transform.LookAt(target.position);
            StartCoroutine(Animate());
        }

        private IEnumerator Animate()
        {
            Time.timeScale = _timeScale;
            yield return new WaitForSecondsRealtime(_duration);
            Time.timeScale = 1;
            AnimationEnd?.Invoke();
        }
    }
}