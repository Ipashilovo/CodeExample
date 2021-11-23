using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Kapcha
{
    public class NumberButton : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Button _button;

        private int _value;

        public event Action<int> Clicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void SetValue(int value)
        {
            _value = value;
            _text.text = _value.ToString();
        }

        private void OnButtonClick()
        {
            Clicked?.Invoke(_value);
        }
    }
}