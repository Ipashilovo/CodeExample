using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasoningParticle : MonoBehaviour
{
    [SerializeField] private Transform _particlePositon;
    [SerializeField] private ParticleSystem _particle;

    private void Start()
    {
        _particle = Instantiate(_particle);
    }

    public void Play()
    {
        _particle.transform.position = _particlePositon.position;
        _particle.Play();
    }
}
