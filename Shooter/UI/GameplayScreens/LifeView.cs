using System;
using LevelSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayScreens
{
    public class LifeView : MonoBehaviour
    {
        [SerializeField] private Image[] _images;
        [SerializeField] private Sprite[] _sprites;
        private int _spriteNumber;
        private PlayerFacade _playerFacade;

        public void Init(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
            _playerFacade.TakedDamage += ShowValue;
        }

        private void OnDestroy()
        {
            if (_playerFacade != null)
            {
                _playerFacade.TakedDamage -= ShowValue;
            }
        }

        private void ShowValue(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            int step = 2;
            var currentImage = _images[(int)Mathf.Floor(value/step)];
            currentImage.sprite = _sprites[_spriteNumber];
            _spriteNumber++;
            _spriteNumber %= _sprites.Length;
        }
    }
}