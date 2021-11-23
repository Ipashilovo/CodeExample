using UnityEngine;

namespace UI.Popup
{
    public class PopupOpener : MonoBehaviour
    {
        [SerializeField] private PopupScreen _popupScreen;
        [SerializeField] private float _minTimeToOpen = 60;

        private void Start()
        {
            if (TimeOnLocation.Time > _minTimeToOpen)
            {
                _popupScreen.gameObject.SetActive(true);
            }
        }
    }
}