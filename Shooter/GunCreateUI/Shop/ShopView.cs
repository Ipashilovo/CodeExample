using System;
using UnityEngine;
using UnityEngine.UI;

namespace GunCreateUI.Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Button _button;
        [SerializeField] private Color _lockColor;
        private Color _startColor;

        public event Action Clicked;

        private void Awake()
        {
            _startColor = _button.image.color;
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Notify);
        }

        private void Notify()
        {
            Clicked?.Invoke();
        }

        public void SetBuyOpportunity(int price)
        {
            _text.text = price + " $";
            UnlockButton();
            gameObject.SetActive(true);
        }

        public void SetLockPrice(int price)
        {
            _text.text = price + " $";
            LockButton();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void UnlockButton()
        {
            _button.image.color = _startColor;
            _button.onClick.AddListener(Notify);
        }

        private void LockButton()
        {
            _button.image.color = _lockColor;
            _button.onClick.RemoveListener(Notify);
        }
    }
}