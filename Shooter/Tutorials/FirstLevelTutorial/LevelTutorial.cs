using System;
using ActivityLevel;
using DefaultNamespace.Input;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace.Tutorials.FirstLevelTutorial
{
    public class LevelTutorial : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private FirstInputLisener _firstInputLisener;


        [Inject]
        public void Construct(FirstInputLisener firstInputLisener)
        {
            _firstInputLisener = firstInputLisener;
            _firstInputLisener.Clicked += HideImage;
        }

        private void OnDestroy()
        {
            _firstInputLisener.Clicked -= HideImage;
        }

        private void HideImage()
        {
            _image.gameObject.SetActive(false);
        }

        private void Start()
        {
            _firstInputLisener.StartLisen();
        }
    }
}