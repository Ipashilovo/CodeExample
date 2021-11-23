using System;
using System.Linq;
using Player;
using UnityEngine;

namespace City
{
    public class CitySpawnPosition : MonoBehaviour
    {
        [SerializeField] private PlayerFacade _playerFacade;
        [SerializeField] private CurrentLocation _currentLocation;
        [SerializeField] private CityLockationEnterer[] _cityLockationEnterers;

        private void Start()
        {
            if (_cityLockationEnterers.Any(c => c.Location == _currentLocation.GetLocation()))
            {
                _playerFacade.transform.position = _cityLockationEnterers
                    .First(c => c.Location == _currentLocation.GetLocation()).GetSpawnPosition();
                _playerFacade.PlayIdle();
            }
        }
    }
}