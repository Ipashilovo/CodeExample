using System;
using DG.Tweening;
using UnityEngine;

namespace Move
{
    public class MainMenuCameraMover : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private float _speed;
        private int _pointNumber = 0;
        private Vector3 _targetPosition;

        private void Start()
        {
            _targetPosition = _points[0].transform.position;
            _targetPosition.z = transform.position.z;
        }

        private void Update()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, _targetPosition) <= _speed * Time.deltaTime)
            {
                _pointNumber++;
                _pointNumber %= _points.Length;
                _targetPosition = _points[_pointNumber].position;
                _targetPosition.z = transform.position.z;
            }
        }
    }
}