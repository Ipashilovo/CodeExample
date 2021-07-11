using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particles;

    public void PlayAllParticles()
    {
        foreach (var particle in _particles)
        {
            particle.Play();
        }
    }
}
