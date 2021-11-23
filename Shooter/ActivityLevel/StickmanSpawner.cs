using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Stickman;
using LevelSystem;
using Stickmans;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace ActivityLevel
{
    public class StickmanSpawner : MonoBehaviour
    {
        [SerializeField] private SpawnInfo[] _spawnInfos;
        [SerializeField] private StickmanFacade _stickmanFacade;
        private FirstInputLisener _firstInputLisener;
        private PlayerFacade _playerFacade;
        private StickmanBulletPool _stickmanBulletPool;

        private Coroutine _spawnCoroutine;

        public event Action<StickmanFacade> StickmanSpawned;
        public event Action SpawnComplited;

        [Inject]
        public void Construct(PlayerFacade playerFacade, StickmanBulletPool stickmanBulletPool, FirstInputLisener firstInputLisener)
        {
            _firstInputLisener = firstInputLisener;
            _playerFacade = playerFacade;
            _stickmanBulletPool = stickmanBulletPool;
        }
        private void OnDestroy()
        {
            if (_spawnCoroutine != null)
            {
                StopCoroutine(_spawnCoroutine);
            }
        }

        public void Spawn()
        {
            _spawnCoroutine = StartCoroutine(Spawning());
        }

        private IEnumerator Spawning()
        {
            foreach (var spawnInfo in _spawnInfos)
            {
                var newStickman = Instantiate(_stickmanFacade, spawnInfo.SpawnPosition.position, Quaternion.identity);
                newStickman.SetMovePoint(spawnInfo.EndPosition);
                newStickman.SetOutSystems(_playerFacade, _stickmanBulletPool, _firstInputLisener);
                StickmanSpawned?.Invoke(newStickman);
                yield return null;
            }
            
            SpawnComplited?.Invoke();
        }
    }

    [Serializable]
    public class SpawnInfo
    {
        public Transform SpawnPosition;
        public Transform EndPosition;
    }
}