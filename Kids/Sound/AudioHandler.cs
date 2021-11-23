using UnityEngine;

namespace Sound
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audio;

        public void Play()
        {
            _audioSource.clip = _audio;
            _audioSource.Play();
        }
    }
}