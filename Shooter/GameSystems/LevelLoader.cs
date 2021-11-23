using System;
using SequentedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystems
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private ScenesSequence _scenesSequence;

        private int _sceneNumber;

        private void Awake()
        {
            _sceneNumber = PlayerPrefs.GetInt(PlayerPrefsName.CurrentScene);
            _scenesSequence.Init(_sceneNumber);
        }

        public void LoadCurrentScene()
        {
            _scenesSequence.LoadScene(_sceneNumber);
        }

        public void LoadNextScene()
        {
            _sceneNumber++;
            PlayerPrefs.SetInt(PlayerPrefsName.CurrentScene, _sceneNumber);
            _scenesSequence.LoadNext();
        }

        public void LoadArmory()
        {
            SceneManager.LoadScene("GunCreateScene");
        }

        public void IncreaseNumber()
        {
            _sceneNumber++;
            PlayerPrefs.SetInt(PlayerPrefsName.CurrentScene, _sceneNumber);
        }
    }
}