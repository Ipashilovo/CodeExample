using System;
using DefaultNamespace.GameSystems;
using Gun;
using UnityEngine;
using UnityEngine.UI;

namespace GunCreateUI.ScrollViewContent
{
    public class GunElementView : MonoBehaviour
    {
        [SerializeField] private Image _selectImage;
        [SerializeField] private ButtonHandler _buttonHandler;
        [SerializeField] private Image _image;
        [SerializeField] private AudioClip _selectAudio;
        protected AudioSource _audioSource;
        
        public ButtonHandler GetButtonHandler()
        {
            return _buttonHandler;
        }

        protected virtual void OnEnable()
        {
            _buttonHandler.Clicked += PlaySelectAudio;
        }

        protected virtual void OnDisable()
        {
            _buttonHandler.Clicked -= PlaySelectAudio;
        }

        private void PlaySelectAudio(bool isColorTab)
        {
            _audioSource.PlayOneShot(_selectAudio);
        }

        public void Init(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        protected void EnableButtonHandler()
        {
            _buttonHandler.enabled = true;
        }

        public void Select()
        {
            _selectImage.gameObject.SetActive(true);
        }

        public void Deselect()
        {
            _selectImage.gameObject.SetActive(false);
        }

        protected void NotifyButtonHandler()
        {
            _buttonHandler.Notify();
        }
        
        protected void DisableButtonHandler()
        {
            _buttonHandler.enabled = false;
        }

        public void SetAudioSource(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void TryToSelect(GunSaveData gunSaveData)
        {
            throw new NotImplementedException();
        }
    }
}