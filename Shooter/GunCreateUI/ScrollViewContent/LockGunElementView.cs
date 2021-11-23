using System;
using System.Collections;
using System.Collections.Generic;
using BulletData.BulletsType;
using Gun;
using UnityEngine;
using UnityEngine.UI;

namespace GunCreateUI.ScrollViewContent
{
    public class LockGunElementView : GunElementView
    {
        [SerializeField] private Image _outlineImage;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Text _text;
        [SerializeField] private Button _selectButton;
        [SerializeField] private AudioClip _buyAudio;

        private Coroutine _coroutine;
        public int Price { get; private set; }
        public GunElementsByBase Elements { get; private set; }

        public event Action<LockGunElementView> Selected;
        public event Action<LockGunElementView> Destroing;

        protected override void OnEnable()
        {
            base.OnEnable();
            _selectButton.onClick.AddListener(ShowBuyButton);
            _buyButton.onClick.AddListener(OnClick);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _selectButton.onClick.RemoveListener(ShowBuyButton);
            _buyButton.onClick.RemoveListener(OnClick);
        }

        private void ShowBuyButton()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            _buyButton.gameObject.SetActive(true);
            _coroutine = StartCoroutine(DisableBuyButton());
        }

        private IEnumerator DisableBuyButton()
        {
            yield return new WaitForSeconds(2);
            _buyButton.gameObject.SetActive(false);
            _coroutine = null;
        }

        private void OnClick()
        {
            Selected?.Invoke(this);
        }

        private void OnDestroy()
        {
            Destroing?.Invoke(this);
        }

        public void SpecialInit(int price, GunElementsByBase elements)
        {
            Elements = elements;
            Price = price;
            _text.text = $"{Price}$";
        }
        private void Awake()
        {
            DisableButtonHandler();
        }

        public void Unlock()
        {
            _audioSource.PlayOneShot(_buyAudio);
            Debug.Log("Unlock");
            _selectButton.gameObject.SetActive(false);
            NotifyButtonHandler();
            EnableButtonHandler();
        }

        public void ShowOutline()
        {
            _outlineImage.gameObject.SetActive(true);
        }

        public void HineOutlineImage()
        {
            _outlineImage.gameObject.SetActive(false);
        }
    }
}