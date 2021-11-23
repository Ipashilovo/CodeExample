using System;
using UnityEngine;
using UnityEngine.Audio;

namespace GameSystems
{
    public class VolumeLisener : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixer;

        public static VolumeLisener _volumeLisener;

        public static bool IsVolumeEnable { get; private set; }

        private void Awake()
        {
            IsVolumeEnable = true;
            _volumeLisener = this;
            DontDestroyOnLoad(gameObject);
        }

        public static void DisableVolume()
        {
            IsVolumeEnable = false;
            _volumeLisener._mixer.audioMixer.SetFloat("MasterVolume", -80);
        }

        public static void EnableVolume()
        {
            IsVolumeEnable = true;
            _volumeLisener._mixer.audioMixer.SetFloat("MasterVolume", 0);
        }
    }
}