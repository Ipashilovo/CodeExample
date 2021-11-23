using System;
using Input;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CollectiblesCloseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private CollectibleViewScreenButton _collectibleViewScreenButton;
        [SerializeField] private CollectibleViewScreen _collectibleViewScreen;

        private void OnEnable()
        {
            _button.onClick.AddListener(CloseWindow);
        }

        private void OnDisable()
        {
            _button.onClick.AddListener(CloseWindow);
        }

        private void CloseWindow()
        {
            _collectibleViewScreen.gameObject.SetActive(false);
            InputFolder.EnableInfinity();
            _collectibleViewScreenButton.OnJournalClose();
        }
    }
}