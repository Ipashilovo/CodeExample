using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTrigger : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;

    private void Update()
    {
        transform.position = _targetPosition.position;
    }
}
