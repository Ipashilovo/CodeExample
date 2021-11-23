using System;
using ActivityLevel.ShootHandlers;
using UnityEngine;

namespace ActivityLevel
{
    public class ShootAudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        private IShootable _shootable;
        private AudioClip _audioClip;
        

        public void Init(AudioClip audioClip, IShootable ishootable, bool isEveryShootPlay)
        {
            _audioClip = audioClip;
            _shootable = ishootable;
            if (isEveryShootPlay)
            {
                _shootable.Shooted += PlayOneShoot;
            }
            else
            {
                _audioSource.clip = _audioClip;
                _shootable.Shooted += PlaySound;
            }
        }

        private void OnDestroy()
        {
            _shootable.Shooted -= PlaySound;
            _shootable.Shooted -= PlayOneShoot;
        }

        private void PlayOneShoot()
        {
            _audioSource.PlayOneShot(_audioClip);
        }

        private void PlaySound()
        {
            _audioSource.Play();
        }
    }
}