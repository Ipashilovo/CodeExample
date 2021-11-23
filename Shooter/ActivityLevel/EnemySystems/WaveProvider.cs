using System;
using System.Collections.Generic;
using DefaultNamespace.Stickman;
using UnityEngine;

namespace ActivityLevel.EnemySystems
{
    public class WaveProvider : MonoBehaviour
    {
        [SerializeField] private StickmanSpawner _stickmanSpawner;
        private List<StickmanFacade> _stickmans = new List<StickmanFacade>();
        public event Action<List<StickmanFacade>> WaveCreated;
        private void OnEnable()
        {
            _stickmanSpawner.StickmanSpawned += AddStickman;
            _stickmanSpawner.SpawnComplited += OnSpawnComplited;
        }

        private void OnDisable()
        {
            _stickmanSpawner.StickmanSpawned -= AddStickman;
        }

        public void CreateNewWave()
        {
            _stickmans.Clear();
            _stickmanSpawner.Spawn();
        }

        private void AddStickman(StickmanFacade stickmanFacade)
        {
            _stickmans.Add(stickmanFacade);
        }

        private void OnSpawnComplited()
        {
            WaveCreated?.Invoke(_stickmans);
        }
    }
}