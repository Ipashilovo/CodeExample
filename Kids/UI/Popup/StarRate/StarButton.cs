using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popup.StarRate
{
    public class StarButton : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private Sprite _defultSprite;

        public event Action<StarButton> Selected;

        private void Awake()
        {
            _defultSprite = _image.sprite;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(NotifyClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(NotifyClick);
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void SetDefultSprite()
        {
            _image.sprite = _defultSprite;
        }

        private void NotifyClick()
        {
            Selected?.Invoke(this);
        }
    }
}