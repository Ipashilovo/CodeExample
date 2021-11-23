using System;
using GameSystems;
using UnityEngine;
using UnityEngine.UI;

namespace UI.EndGame
{
    public class LooseScreen : MonoBehaviour, ILooseScreen
    {
        [SerializeField] private Button _button;
        private LevelLoader _levelLoader;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadScene);
        }

        public void Init(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void LoadScene()
        {
            _levelLoader.LoadCurrentScene();
        }
    }
}