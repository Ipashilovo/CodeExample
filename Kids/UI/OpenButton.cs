using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class OpenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Button _button;

        
        private void OnEnable()
        {
            _button.onClick.AddListener(Open);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Open);
        }

        private void Open()
        {
            _gameObject.SetActive(true);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            InputFolder.Disable();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputFolder.Enable();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            InputFolder.Enable();
        }
    }
}