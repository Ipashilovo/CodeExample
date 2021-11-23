using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputFolder : MonoBehaviour
    {
        private MainInput _mainInput;
        private static InputFolder _inputFolder;

        private bool _isTouching;
        private static bool _isMainDisable;
        
        public static event Action Clicked;
        public static event Action ClickEnded;
        public static bool IsEnable { get; private set; }

        private Coroutine _clickCooldown;

        private void Awake()
        {
            _mainInput = new MainInput();
            _inputFolder = this;
            _mainInput.GameplayInput.Click.started += context => StartClick();
            _mainInput.GameplayInput.Click.canceled += context => NotifyEndClick();
            Enable();
            DontDestroyOnLoad(this);
        }

        private void OnDestroy()
        {
            _mainInput = null;
        }

        public static void Disable()
        {
            _inputFolder.DisableInput();
            IsEnable = false;
        }

        public static void DisableInfinity()
        {
            _isMainDisable = true;
            Disable();
        }

        public static void EnableInfinity()
        {
            _isMainDisable = false;
            Enable();
        }

        private void DisableInput()
        {
            ClickEnded?.Invoke();
            _mainInput.GameplayInput.Disable();
        }

        public static void Enable()
        {
            if (_isMainDisable) return;
            _inputFolder.EnableInput();
            IsEnable = true;
        }

        private void EnableInput()
        {
            _mainInput.GameplayInput.Enable();
        }

        public static Vector2 GetInputPosition()
        {
            return _inputFolder.GetPosition();
        }

        public static bool GetToucheState()
        {
            return _inputFolder.GetTouch();
        }

        private bool GetTouch()
        {
            return _isTouching;
        }

        private Vector2 GetPosition()
        {
            return _mainInput.GameplayInput.Position.ReadValue<Vector2>();
        }

        private void StartClick()
        {
            if (_clickCooldown != null) return;
            if (_isTouching) return;
            _clickCooldown = StartCoroutine(Cooldown());
            StartCoroutine(NotifyClick());
        }

        public IEnumerator Cooldown()
        {
            yield return null;
            yield return null;
            yield return null;
            _clickCooldown = null;
        }

        private IEnumerator NotifyClick()
        {
            _isTouching = true;
            yield return null;
            if (!_isTouching) yield break;
            Clicked?.Invoke();
        }

        private void NotifyEndClick()
        {
            if (!_isTouching) return;
            
            _isTouching = false;
            ClickEnded?.Invoke();
        }
    }
}