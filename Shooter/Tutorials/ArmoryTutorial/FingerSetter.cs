using System;
using GunCreateUI.ScrollViewContent;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials.ArmoryTutorial
{
    public class FingerSetter : MonoBehaviour
    {
        [SerializeField] private Image[] _fingers;
        [SerializeField] private ButtonConteinerLisener _buttonConteinerLisener;
        [SerializeField] private TutorialExitButton _tutorialExitButton;
        private int _currentFingerNumber;

        private void OnEnable()
        {
            _buttonConteinerLisener.Selected += TryShowNextFinger;
        }

        private void OnDisable()
        {
            _buttonConteinerLisener.Selected -= TryShowNextFinger;
        }

        private void Start()
        {
            _fingers[_currentFingerNumber].gameObject.SetActive(true);
        }

        private void TryShowNextFinger()
        {
            _fingers[_currentFingerNumber].gameObject.SetActive(false);
            _currentFingerNumber++;
            _fingers[_currentFingerNumber].gameObject.SetActive(true);
            if (_currentFingerNumber >= _fingers.Length - 1)
            {
                _buttonConteinerLisener.Selected -= TryShowNextFinger;
                _tutorialExitButton.gameObject.SetActive(true);
            }
        }
    }
}