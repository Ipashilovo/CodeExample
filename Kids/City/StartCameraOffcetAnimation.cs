using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace City
{
    public class StartCameraOffcetAnimation : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private float _offcetY;
        private float _startOffcet;
        private CinemachineFramingTransposer _cinemachineFramingTransposer;

        private void Awake()
        {
            _cinemachineFramingTransposer = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            _startOffcet = _cinemachineFramingTransposer.m_ScreenY;
        }

        public void SetOffcet()
        {
            Debug.Log("SetOffcet");
            _cinemachineFramingTransposer.m_ScreenY = _offcetY;
        }

        public void Remove()
        {
            _cinemachineFramingTransposer.m_ScreenY = _startOffcet;
        }
    }
}