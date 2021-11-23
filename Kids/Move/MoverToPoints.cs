using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Move
{
    public class MoverToPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;
        [SerializeField] private MoveSpeed _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        private int _pointNumber;

        private void Start()
        {
            foreach (var point in _points)
            {
                point.parent = null;
            }
            Rotate();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_pointNumber].position,
                _moveSpeed.Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _points[_pointNumber].position) <
                _moveSpeed.Speed * Time.deltaTime)
            {
                enabled = false;
            }
        }

        private void Rotate()
        {
            Quaternion startRotation = transform.rotation;
            transform.up = _points[_pointNumber].position - transform.position;
            Quaternion endRotation = transform.rotation;
            transform.rotation = startRotation;
            transform.DORotateQuaternion(endRotation, _rotationSpeed);
        }
    }
}