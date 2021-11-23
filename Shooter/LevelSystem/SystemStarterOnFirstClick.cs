using System;
using ActivityLevel;
using UnityEngine;

namespace LevelSystem
{
    public class SystemStarterOnFirstClick : MonoBehaviour
    {
        [SerializeField] private GunRotatable _gunRotatable;
        [SerializeField] private GunSetter _gunSetter;
        private FirstInputLisener _firstInputLisener;

        public void Init(FirstInputLisener firstInputLisener)
        {
            _firstInputLisener = firstInputLisener;
            _firstInputLisener.Clicked += OnClick;
        }

        private void OnDestroy()
        {
            _firstInputLisener.Clicked -= OnClick;
        }

        private void OnClick()
        {
            _firstInputLisener.Clicked -= OnClick;
            _gunRotatable.enabled = true;
            _gunSetter.EnableShootHandler();
        }
    }
}