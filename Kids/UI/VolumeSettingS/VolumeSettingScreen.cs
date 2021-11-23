using System;
using DefaultNamespace;
using GameSystems;
using Input;
using Player;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class VolumeSettingScreen : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Sprite _enableVolume;
        [SerializeField] private Sprite _disableVolume;

        private void OnEnable()
        {
            InputFolder.DisableInfinity();
        }

        private void OnDisable()
        {
            InputFolder.EnableInfinity();
        }

        private void Start()
        {
            if (VolumeLisener.IsVolumeEnable)
            {
                ChangeButtonToEnable();
            }
            else
            {
                ChangeButtonToDisable();
            }
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(DisableVolume);
            _button.onClick.RemoveListener(EnableVolume);
        }

        private void ChangeButtonToEnable()
        {
            _button.image.sprite = _enableVolume;
            _button.onClick.AddListener(DisableVolume);
        }

        private void ChangeButtonToDisable()
        {
            _button.image.sprite = _disableVolume;
            _button.onClick.AddListener(EnableVolume);
        }

        private void DisableVolume()
        {
            VolumeLisener.DisableVolume();
            ChangeButtonToDisable();
        }

        private void EnableVolume()
        {
            VolumeLisener.EnableVolume();
            ChangeButtonToEnable();
        }
    }
}