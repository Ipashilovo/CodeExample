using System;
using System.Collections;
using System.Collections.Generic;
using Analytics;
using DefaultNamespace;
using Input;
using Interactive;
using Interactive.DropInputInteractive;
using LevelSystems;
using Monetization;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace City
{
    public class LocationExit : MonoBehaviour, IInteractive
    {
        [SerializeField] private float _time;
        [SerializeField] private float _animationTime = 0.6f;
        [SerializeField] private ChangeLevelAnimation _changeLevelAnimation;
        [SerializeField] private InputHandler _inputHandler;

        public event Action Interacting;
        public event Action EndInteracting;

        private void OnEnable()
        {
            _inputHandler.Clicked += ChangeLevel;
        }

        private void OnDisable()
        {
            _inputHandler.Clicked -= ChangeLevel;
        }

        private void ChangeLevel()
        {
            Interacting?.Invoke();
            _changeLevelAnimation.Animate(_animationTime);
            StartCoroutine(ExitAfterDelay());
        }

        private IEnumerator ExitAfterDelay()
        {
            yield return new WaitForSeconds(_time);
            EndInteracting?.Invoke();
            InputFolder.Disable();
            
            if (Time.timeSinceLevelLoad > 60f)
            {
                Advertisment.Instance.ShowInterstitial();
            }
            
            new EventSender().SendLevelFinish();
            SceneManager.LoadScene("City");
        }
    }
}