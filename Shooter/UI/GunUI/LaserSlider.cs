using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.GunUI
{
    public class LaserSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        public event Action Destroying;

        private void OnDestroy()
        {
            Destroying?.Invoke();
        }

        public void SetMaxValue(float _value)
        {
            _slider.maxValue = _value;
            _slider.value = 0;
        }

        public void SetValue(float value)
        {
            _slider.value = value;
        }
    }
}