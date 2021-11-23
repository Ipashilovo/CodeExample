using System;
using DefaultNamespace.Input;
using UnityEngine;
using Zenject;

namespace ActivityLevel
{
    public class FirstInputLisener : MonoBehaviour
    {
        private InputFolder _inputFolder;
        public event Action Clicked;

        [Inject]
        public void Construct(InputFolder inputFolder)
        {
            _inputFolder = inputFolder;
        }

        public void OnDestroy()
        {
            _inputFolder.Touching -= Notify;
        }

        public void StartLisen()
        {
            _inputFolder.Touching += Notify;
        }

        private void Notify()
        {
            _inputFolder.Touching -= Notify;
            Clicked?.Invoke();
        }
    }
}