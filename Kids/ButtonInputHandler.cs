using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonInputHandler : InputHandler
    {
        [SerializeField] private Button _button;
        public override event Action Clicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(Notify);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Notify);
        }

        private void Notify()
        {
            Clicked?.Invoke();
        }
    }
}