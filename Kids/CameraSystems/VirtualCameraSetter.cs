using System;
using Cinemachine;
using UnityEngine;

namespace CameraSystems
{
    public class VirtualCameraSetter : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        [SerializeField] private CameraFixator[] _cameraFixators;

        private void Start()
        {
            foreach (var camera in _cameraFixators)
            {
                camera.Init(_cinemachineVirtualCamera);
            }
        }
    }
}