using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace LevelSystems
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private float _animationTime;
        private static CameraZoom _cameraZoom;
        private LensSettings _lensSettings;
        private static float _startLenght;

        private void Awake()
        {
            _cameraZoom = this;
            _lensSettings = _cinemachineVirtualCamera.m_Lens;
            _startLenght = _lensSettings.OrthographicSize;
        }

        public static void Zoom(float value)
        {
            _cameraZoom.Animate(value);
        }

        public static void Zoom(float value, float time)
        {
            _cameraZoom.Animate(value, time);
        }

        public static void Rezoome()
        {
            _cameraZoom.Animate(_startLenght);
        }

        private void Animate(float targetValue)
        {
            StartCoroutine(Zooming(targetValue, _animationTime));
        }

        private void Animate(float targetValue, float time)
        {
            StartCoroutine(Zooming(targetValue, time));
        }

        private IEnumerator Zooming(float targetValue, float maxTime)
        {
            float startZoom = _lensSettings.OrthographicSize;
            float time = 0;
            while (time <= 1)
            {
                time += Time.deltaTime / maxTime;
                _lensSettings.OrthographicSize = Mathf.Lerp(startZoom, targetValue, time);
                _cinemachineVirtualCamera.m_Lens = _lensSettings;
                yield return null;
            }
        }
    }
}