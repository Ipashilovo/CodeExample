using System;
using UI.Popup;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PopupScreen _popupScreen;

        private void OnEnable()
        {
            _button.onClick.AddListener(ShowBuyScreen);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowBuyScreen);
        }

        private void ShowBuyScreen()
        {
            _popupScreen.gameObject.SetActive(true);
        }
    }
}