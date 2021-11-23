using System;
using GunCreateUI.ScrollViewContent;
using UnityEngine;

namespace GunCreateUI
{
    public class ArrowLisener : MonoBehaviour
    {
        [SerializeField] private ButtonHandler _rightButtonHandler;
        [SerializeField] private ButtonHandler _leftButtonHandler;
        [SerializeField] private GunSetter _gunSetter;

        private void OnEnable()
        {
            _leftButtonHandler.Clicked += OnLeft;
            _rightButtonHandler.Clicked += OnRight;
        }

        private void OnDisable()
        {
            _leftButtonHandler.Clicked -= OnLeft;
            _rightButtonHandler.Clicked -= OnRight;
        }

        private void OnRight(bool isColorTab)
        {
            _gunSetter.OnRightClick();
        }

        private void OnLeft(bool isColorTab)
        {
            _gunSetter.OnLeftClick();
        }
    }
}