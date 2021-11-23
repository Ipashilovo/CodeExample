using System;
using UnityEngine;

namespace Effects
{
    public class ParticleAudio : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }
    }
}