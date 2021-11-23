using System;
using Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class CollectibleViewScreenButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
    {
        [SerializeField] private Button _button;
        [SerializeField] private CollectibleViewScreen _collectibleViewScreen;

        private bool _isClicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(OpenWindow);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OpenWindow);
        }

        private void OpenWindow()
        {
            _isClicked = true;
            InputFolder.DisableInfinity();
            _collectibleViewScreen.gameObject.SetActive(true);
        }

        public void OnJournalClose()
        {
            _isClicked = false;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            InputFolder.DisableInfinity();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            InputFolder.Enable();
        }
    }
}