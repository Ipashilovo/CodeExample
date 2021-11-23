using System;
using Interactive;
using UnityEngine;

namespace Sound
{
    public class InteractiveAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audio;
        [SerializeField] private MonoBehaviour _monoBehaviour;
        private IInteractive _interactive;
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_monoBehaviour is IInteractive monoBehaviour)
            {
                _interactive = monoBehaviour;
            }
            else
            {
                _monoBehaviour = null;
                throw new ArgumentException();
            }
        }
#endif

        private void Awake()
        {
            _interactive = (IInteractive) _monoBehaviour;
        }

        private void OnEnable()
        {
            if (_audio != null)
            {
                _interactive.Interacting += PlaySound;
            }
        }

        private void OnDisable()
        {
            _interactive.Interacting -= PlaySound;
        }

        private void PlaySound()
        {
            if (_audioSource.isPlaying) return;
            _audioSource.clip = _audio;
            _audioSource.Play();
        }
    }
}