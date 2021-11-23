using System.Collections;
using UnityEngine;

namespace CameraSystems
{
    public class CameraFixatorX : CameraFixator
    {
        [SerializeField] protected float _targetOffcet;

        protected override IEnumerator SetingCameraOffcet(Transform target)
        {
            while (true)
            {
                float lerpValue = Mathf.Abs(_startPosition.position.x - target.position.x) /
                                  Mathf.Abs(_startPosition.position.x - _endPosition.position.x);
                float endPosition = Mathf.Lerp(_startOffcet.x, _targetOffcet, lerpValue);
                _cinemachineFramingTransposer.m_ScreenX = endPosition;
                yield return null;
            }
        }
    }
}