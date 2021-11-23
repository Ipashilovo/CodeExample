using System;
using System.Collections;
using UnityEngine;

namespace CameraSystems
{
    public class CameraFixatorY : CameraFixator
    {
        [SerializeField] protected float _targetOffcet;
        protected override IEnumerator SetingCameraOffcet(Transform target)
        {
            while (true)
            {
                float lerpValue = Mathf.Abs(_startPosition.position.y - target.position.y) /
                                  Mathf.Abs(_startPosition.position.y - _endPosition.position.y);
                float endPosition = Mathf.Lerp(_startOffcet.x, _targetOffcet, lerpValue);
                _cinemachineFramingTransposer.m_ScreenY = endPosition;
                yield return null;
            }
        }
    }
}