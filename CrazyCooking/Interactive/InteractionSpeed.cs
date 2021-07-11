using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class InteractionSpeed : MonoBehaviour
{
    [SerializeField] private InteractionSystem _interactionSystem;
    [SerializeField, Range(0f, 5f)] private float _speed;

    public float Speed => _speed;

    private void Awake()
    {
        _interactionSystem.speed = _speed;
    }
}
