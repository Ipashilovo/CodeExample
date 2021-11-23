using System.Collections;
using UnityEngine;
using Cinemachine;

namespace CameraSystems
{
    public abstract class CameraFixator : MonoBehaviour
    {
        [SerializeField] protected Transform _startPosition;
        [SerializeField] protected Transform _endPosition;
        [SerializeField] protected CameraTriggerHandler _cameraTriggerHandler;
        protected Vector2 _startOffcet;

        private CinemachineVirtualCamera _cinemachineVirtualCamera;
        protected CinemachineFramingTransposer _cinemachineFramingTransposer;
        private Coroutine _coroutine;

        private void OnDestroy()
        {
            _cameraTriggerHandler.Entered -= OnPlayerEnter;
            _cameraTriggerHandler.Exited -= OnPlayerExit;
        }

        public void Init(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _cinemachineVirtualCamera = cinemachineVirtualCamera;
            _cinemachineFramingTransposer = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            _startOffcet.x = _cinemachineFramingTransposer.m_ScreenX;
            _startOffcet.y = _cinemachineFramingTransposer.m_ScreenY;
            _cameraTriggerHandler.Entered += OnPlayerEnter;
            _cameraTriggerHandler.Exited += OnPlayerExit;
        }

        private void OnPlayerEnter(Transform target)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(SetingCameraOffcet(target));
            }
        }

        private void OnPlayerExit()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        protected abstract IEnumerator SetingCameraOffcet(Transform target);
    }
}