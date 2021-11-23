using System;
using DefaultNamespace;
using Input;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Kapcha
{
    public class KapchaScreen : MonoBehaviour
    {
        [SerializeField] private int _maxValue = 2005;
        [SerializeField] private int _minValue = 1905;
        [SerializeField] private ButtonSetter _buttonSetter;
        [SerializeField] private InputHandler _clearButton;
        [SerializeField] private Image[] _images;
        [SerializeField] private Sprite _selected;
        [SerializeField] private Sprite _defult;
        private NumberButton[] _numberButtons;

        private int _valueNumber;
        private int[] _values;

        public event Action FilledCorrect;
        
        private void OnEnable()
        {
            InputFolder.DisableInfinity();
            DropValue();
        }

        private void OnDisable()
        {
            InputFolder.EnableInfinity();
        }

        private void Start()
        {
            _numberButtons = _buttonSetter.CreateButtons();
            foreach (var number in _numberButtons)
            {
                number.Clicked += OnNumberButtonClick;
            }

            _clearButton.Clicked += OnClrearButtonClick;
        }

        private void OnDestroy()
        {
            _clearButton.Clicked -= OnClrearButtonClick;
            foreach (var number in _numberButtons)
            {
                number.Clicked -= OnNumberButtonClick;
            }
        }

        private void OnNumberButtonClick(int value)
        {
            _values[_valueNumber] = value;
            _images[_valueNumber].sprite = _selected;
            _valueNumber++;
            if (_valueNumber >= _images.Length)
            {
                CheckRezult();
            }
        }

        private void OnClrearButtonClick()
        {
            _valueNumber = _valueNumber - 1 < 0 ? 0 : _valueNumber - 1;
            _images[_valueNumber].sprite = _defult;
        }

        private void CheckRezult()
        {
            int rezult = 0;
            for (int i = 0; i < _values.Length; i++)
            {
                rezult += _values[i] * (int)Math.Pow(10, 3 - i);
            }

            if (rezult > _minValue && rezult < _maxValue)
            {
                FilledCorrect?.Invoke();
                gameObject.SetActive(false);
            }
            else
            {
                DropValue();
            }
        }

        private void DropValue()
        {
            _valueNumber = 0;
            foreach (var image in _images)
            {
                image.sprite = _defult;
            }

            _values = new int[4];
        }
    }
}