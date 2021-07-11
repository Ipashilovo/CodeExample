using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParticle : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private ActionParticle _particle;

    private void OnEnable()
    {
        _unit.MaterialChanged += Play;
    }

    private void OnDisable()
    {
        _unit.MaterialChanged -= Play;
    }

    private void Play()
    {
        Vector3 particlePosition = transform.position;
        float positionY = 1f;
        particlePosition.y += positionY;
        Instantiate(_particle, particlePosition, Quaternion.identity);
    }
}
