using System;
using GameSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Tutorials
{
    public class Tutorial : MonoBehaviour
    {
        private LevelLoader _levelLoader;
        public bool IsEnded { get; private set; }

        private void Awake()
        {
            IsEnded = PlayerPrefs.GetInt(PlayerPrefsName.TutorialComplited) > 0;
        }

        [Inject]
        public void Construct(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }
        
        public void LoadArmory()
        {
            SceneManager.LoadScene("TutorialArmory");
        }

        public void LoadFirstLevel()
        {
            SceneManager.LoadScene("TutorialLevel");
        }

        public void EndTutorial()
        {
            IsEnded = true;
            PlayerPrefs.SetInt(PlayerPrefsName.TutorialComplited, 1);
            _levelLoader.LoadCurrentScene();
        }
    }
}