using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ActionParticle : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    [SerializeField] private float _timeBeforeDestroy;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        _particleSystem.Play();
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeBeforeDestroy);
        Destroy(this);
    }
}
