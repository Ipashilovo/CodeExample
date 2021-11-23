using System;
using City;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class LocationExitButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private CityLockationEnterer _cityLockationEnterer;
        [SerializeField] private CityExitButtonBounce _cityExitButtonBounce;

        private void OnEnable()
        {
            _button.onClick.AddListener(NotyfyClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(NotyfyClick);
        }

        public void Show()
        {
            _cityExitButtonBounce.Show();
        }

        public void Hide()
        {
            _cityExitButtonBounce.Hide();
        }

        private void NotyfyClick()
        {
            _cityLockationEnterer.Enter();
        }
    }
}