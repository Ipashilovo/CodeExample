using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.GameSystems;
using DefaultNamespace.Stickman;
using UnityEngine;

namespace ActivityLevel.EnemySystems
{
    public class StickmanLooker : MonoBehaviour
    {
        [SerializeField] private WaveProvider _waveProvider;
        private List<StickmanFacade> _stickmans = new List<StickmanFacade>();
        private MoneyFolder _moneyFolder;

        public int StickmanCount { get; private set; }

        public event Action<Transform> LastStickmanDead;

        private void OnEnable()
        {
            _waveProvider.WaveCreated += AddNewStickmans;
        }

        private void OnDisable()
        {
            _waveProvider.WaveCreated -= AddNewStickmans;
        }

        public void SetMoneyFolder(MoneyFolder moneyFolder)
        {
            _moneyFolder = moneyFolder;
        }

        private void Start()
        {
            _moneyFolder.StartLisen();
            _waveProvider.CreateNewWave();
        }

        private void OnDestroy()
        {
            foreach (var stickmanFacade in _stickmans)
            {
                stickmanFacade.Destroing -= OnStickmanDestroy;
            }
        }

        private void AddNewStickmans(List<StickmanFacade> stickmans)
        { 
            _stickmans.AddRange(stickmans);
            foreach (var stickmanFacade in _stickmans)
            {
                stickmanFacade.Destroing += OnStickmanDestroy;
            }
        }

        private void OnStickmanDestroy(StickmanFacade stickmanFacade)
        {
            _moneyFolder.AddMoney();
            StickmanCount++;
            stickmanFacade.Destroing -= OnStickmanDestroy;
            _stickmans.Remove(stickmanFacade);
            if (_stickmans.Count <= 0)
            {
                LastStickmanDead?.Invoke(stickmanFacade.transform);
            }
        }
    }
}