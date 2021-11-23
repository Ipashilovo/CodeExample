using GameSystems;
using Tutorials;
using UnityEngine;
using Zenject;

namespace InitScene
{
    public class InitSceneLoader : MonoBehaviour
    {
        private LevelLoader _levelLoader;
        private Tutorial _tutorial;

        [Inject]
        public void Init(LevelLoader levelLoader, Tutorial tutorial)
        {
            _levelLoader = levelLoader;
            _tutorial = tutorial;
        }

        private void Start()
        {
            if (_tutorial.IsEnded)
            {
                _levelLoader.LoadCurrentScene();
            }
            else
            {
                _tutorial.LoadFirstLevel();
            }
        }
    }
}