using System;
using ActivityLevel;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StartGame
{
    public class TapToStartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private StateUIFolder _stateUIFolder;
        private FirstInputLisener _firstInputLisener;

        public void Init(FirstInputLisener firstInputLisener)
        {
            _firstInputLisener = firstInputLisener;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(StartGame);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            _button.onClick.RemoveListener(StartGame);
            _stateUIFolder.CloseStartGameUI();
            _firstInputLisener.StartLisen();
        }
    }
}