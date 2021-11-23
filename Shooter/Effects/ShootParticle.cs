using UnityEngine;

namespace Effects
{
    public class ShootParticle : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _particleSystem;

        public void Play()
        {
            _audioSource.Play();
            _particleSystem.Play();
        }
    }
}