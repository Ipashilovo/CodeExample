using System;
using GameSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace GunCreateUI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private LevelLoader _levelLoader;

        [Inject]
        public void SetLevelLoader(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
        private void OnEnable()
        {
            _button.onClick.AddListener(LoadScene);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadScene);
        }

        private void LoadScene()
        {
            _levelLoader.LoadCurrentScene();
        }
    }
}