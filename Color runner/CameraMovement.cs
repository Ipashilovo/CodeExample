using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offset;

    private void Update()
    {
        Move();   
    }

    private void Move()
    {
        transform.position = new Vector3(_target.position.x, transform.position.y, _target.position.z - _offset);
    }
}
