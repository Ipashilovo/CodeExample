using System;
using System.Collections;
using GameSystems;
using Newtonsoft.Json;
using UI.Kapcha;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popup.StarRate
{
    public class StarButtonLisener : MonoBehaviour
    {
        [SerializeField] private string _PlayMarketPageUrl;
        [SerializeField] private Button _rateUsButton;
        [SerializeField] private Image _image;
        [SerializeField] private StarButton[] _starButtons;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private KapchaScreen _kapchaScreen;
        private int _value;

        private void Awake()
        {
            ShowRateScreenIfNeeded();
        }

        private void ShowRateScreenIfNeeded()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsName.IsRate))
            {
                gameObject.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.HasKey(PlayerPrefsName.LastRateScreenShowDate))
                {
                    string json = PlayerPrefs.GetString(PlayerPrefsName.LastRateScreenShowDate);
                    DateTime dateTime = JsonConvert.DeserializeObject<DateTime>(json);
                    TimeSpan value = DateTime.Now - dateTime;
                    if (value.Hours < 24)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }

        private void OnEnable()
        {
            foreach (var star in _starButtons)
            {
                star.Selected += OnStarSelected;
            }
            _rateUsButton.onClick.AddListener(OnRateButtonClick);
        }

        private void OnDisable()
        {
            _kapchaScreen.FilledCorrect -= Rate;
        }

        private void OnStarSelected(StarButton star)
        {
            int number = Array.IndexOf(_starButtons, star);
            _value = number;
            ClearStart();

            for (int i = 0; i <= number; i++)
            {
                _starButtons[i].SetSprite(_selectedSprite);
            }

        }

        private void OnRateButtonClick()
        {
            if (_value < 4)
            {
                gameObject.SetActive(false);
                string json = JsonConvert.SerializeObject(DateTime.Now);
                PlayerPrefs.SetString(PlayerPrefsName.LastRateScreenShowDate, json);
            }
            else
            {
                _kapchaScreen.gameObject.SetActive(true);
                _kapchaScreen.FilledCorrect += Rate;
            }
        }

        private void ClearStart()
        {
            foreach (var starButton in _starButtons)
            {
                starButton.SetDefultSprite();
            }
        }

        private void Rate()
        {
            Application.OpenURL(_PlayMarketPageUrl);
        }
    }
}