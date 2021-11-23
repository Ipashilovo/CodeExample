using System;
using GameSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CityUnlockLocationButtonFolder : MonoBehaviour
    {
        [SerializeField] private LocationExitButton _locationExitButton;
        [SerializeField] private BuyButton _buyButton;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _lockSprite;
        [SerializeField] private Sprite _unlockSprite;

        private void Start()
        {
            if (UnlockLisener.CheckUnlock())
            {
                Unlock();
            }
            else
            {
                _buyButton.enabled = true;
                _image.sprite = _lockSprite;
                UnlockLisener.Unlocked += Unlock;
            }
        }

        private void OnDestroy()
        {
            UnlockLisener.Unlocked -= Unlock;
        }

        private void Unlock()
        {
            _buyButton.enabled = false;
            _locationExitButton.enabled = true;
            _image.sprite = _unlockSprite;
        }
    }
}