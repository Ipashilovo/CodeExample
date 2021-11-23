using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Input
{
    public class InputFolder : MonoBehaviour
    {
        private MainInput _mainInput;
        private static MainInput Input;

        public event Action ClickStarted;
        public event Action Touching;
        public event Action ClickEnded;

        public static bool IsShooting { get; private set; }

        private void Awake()
        {
            Input = new MainInput();
            Input.Gameplay.Click.started += context => StartCoroutine(NotifyClick()); 
            Input.Gameplay.Click.canceled += context => StartCoroutine(NotifyEndClick()); 
            
            Input.Enable();
        }

        private void OnDestroy()
        {
            Input.Disable();
        }

        public void Enable()
        {
            Input.Enable();
        }

        public void Disable()
        {
            Input.Disable();
        }

        public Vector2 GetPosition()
        {
            return Input.Gameplay.Position.ReadValue<Vector2>();
        }

        private IEnumerator NotifyClick()
        {
            Touching?.Invoke();
            IsShooting = true;
            yield return null;
            ClickStarted?.Invoke();
        }

        private IEnumerator NotifyEndClick()
        {
            IsShooting = false;
            yield return null;
            yield return null;
            ClickEnded?.Invoke();
        }
    }
}