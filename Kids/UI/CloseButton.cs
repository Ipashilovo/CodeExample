using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _gameObject;

        private void OnEnable()
        {
            _button.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _gameObject.SetActive(false);
        }
    }
}