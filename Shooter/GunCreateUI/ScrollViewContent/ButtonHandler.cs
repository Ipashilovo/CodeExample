using System;
using UnityEngine;
using UnityEngine.UI;

namespace GunCreateUI.ScrollViewContent
{
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action<bool> Clicked;

        public bool IsColorTab;
        
        private void OnEnable()
        {
            _button.onClick.AddListener(Notify);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Notify);
        }

        public void Notify()
        {
            Clicked?.Invoke(IsColorTab);
        }

    }
}