using System;
using GameSystems;
using UI.EndGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tutorials.FirstLevelTutorial.UI
{
    public class TutorialLooseScreen : MonoBehaviour, ILooseScreen
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void Init(LevelLoader levelLoader){ }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        private void OnButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}