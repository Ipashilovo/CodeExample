using System;
using GameSystems;
using UI.Kapcha;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popup
{
    public class PopupBuyButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private PopupScreen _popupScreen;
        [SerializeField] private KapchaScreen _kapchaScreen;

        private void OnEnable()
        {
            _button.onClick.AddListener(Buy);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Buy);
        }

        private void Buy()
        { 
            _popupScreen.gameObject.SetActive(false);
            _kapchaScreen.gameObject.SetActive(true);
        }
    }
}