using System;
using UnityEngine;

public class PlayerIconMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _targetY;
    [SerializeField] private float _offsetY;


    private void Update()
    {
        Vector3 endPosition = _target.position;
        endPosition.y = _targetY.position.y + _offsetY;
        transform.position = endPosition;
    }
}
