using UnityEngine;
using UnityEngine.UI;

namespace UI.Popup
{
    public class PopupCloseButton : MonoBehaviour
    {
        [SerializeField] private PopupScreen _popupScreen;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(CloseScreen);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CloseScreen);
        }

        private void CloseScreen()
        {
            _popupScreen.gameObject.SetActive(false);
        }
    }
}