using System;
using Gun;
using ModestTree;
using UnityEngine;

namespace GunCreateUI.ScrollViewContent
{
    public class ButtonConteinerLisener : MonoBehaviour
    {
        [SerializeField] private ButtonConteiner[] _buttonConteiners;
        private ButtonConteiner _current;

        public event Action Selected;
        
        private void Awake()
        {
            _current = _buttonConteiners[0];
        }

        private void OnEnable()
        {
            foreach (var button in _buttonConteiners)
            {
                button.Selected += OnSelect;
                button.Choosed += OnChoosed;
            }
        }

        private void OnDisable()
        {
            foreach (var button in _buttonConteiners)
            {
                button.Selected -= OnSelect;
                button.Choosed -= OnChoosed;
            }
        }

        private void OnChoosed(ButtonConteiner buttonConteiner)
        {
            int index = _buttonConteiners.IndexOf(_current);
            index++;
            index %= _buttonConteiners.Length;
            _current = _buttonConteiners[index];
            _current.Select();
        }

        private void OnSelect(ButtonConteiner buttonConteiner)
        {
            Selected?.Invoke();
            _current = buttonConteiner;
            foreach (var button in _buttonConteiners)
            {
                if (button != buttonConteiner)
                {
                    button.Hide();
                }
            }
        }

        public void ShowSelected()
        {
            _current.Show();
        }
    }
}