using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tutorials.ArmoryTutorial
{
    public class TutorialExitButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private Tutorial _tutorial;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        [Inject]
        public void Construct(Tutorial tutorial)
        {
            _tutorial = tutorial;
        }

        private void OnButtonClick()
        {
            _tutorial.EndTutorial();
        }
    }
}