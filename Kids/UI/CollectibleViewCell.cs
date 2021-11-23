using System;
using DG.Tweening;
using GameSystems.Collectibles;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CollectibleViewCell : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private Image _lightImage;
        private AudioSource _audioSource;
        private AudioClip _audioClip;
        private Collectible _collectible;

        private Tween _tween;

        public void Init(Collectible collectible, AudioSource audioSource)
        {
            _audioSource = audioSource;
            _collectible = collectible;
            _image.sprite = collectible.GetSprite();
            _audioClip = collectible.GetAudioClip();
            ChangeColorIfNeeded();
        }

        private void OnEnable()
        {
            _lightImage.gameObject.SetActive(false);
            ChangeColorIfNeeded();
            ShowLightIfNeeded();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Bounce);
        }

        private void Bounce()
        {
            if (_tween != null)
            {
                return;
            }

            _audioSource.clip = _audioClip;
            _audioSource.Play();
            _tween = transform.DOPunchScale(new Vector3(0.2f, 0.2f,0.2f), 0.3f, 4).OnComplete(() => _tween = null);
        }
        

        private void ChangeColorIfNeeded()
        {
            Color color = _image.color;
            if (_collectible.Count < 1)
            {
                color.a = 0.1f;
            }
            else
            {
                _button.onClick.AddListener(Bounce);
                color.a = 1;
            }

            _image.color = color;
        }

        private void ShowLightIfNeeded()
        {
            if (_collectible.IsShowing) return;
            _lightImage.gameObject.SetActive(true);
            _collectible.Show();
        }
    }
}