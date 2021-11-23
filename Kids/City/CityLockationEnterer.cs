using System;
using System.Collections;
using System.Collections.Generic;
using Analytics;
using DefaultNamespace;
using Input;
using Interactive.DropInputInteractive;
using LevelSystems;
using Move.Animation;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace City
{
    public class CityLockationEnterer : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _animationTime = 2f;
        [SerializeField] private ChangeLevelAnimation _changeLevelAnimation;
        [SerializeField] private CurrentLocation _currentLocation;
        [SerializeField] private Locations _locations;
        private ISkeletonHandler _skeletonHandler;

        private readonly Dictionary<Locations, string> _lockationName = new Dictionary<Locations, string>
        {
            {Locations.Park, "Park"},
            {Locations.Museum, "Museum"},
            {Locations.Cafe, "Cafe"},
            {Locations.Playground, "Playground"},
            {Locations.Room, "Room"},
            {Locations.KidGarden, "KidGarden"},
            {Locations.ToyShop, "ToyShop"}
        };

        public Locations Location => _locations;

        private Coroutine _coroutine;

        public Vector2 GetSpawnPosition()
        {
            if (_spawnPosition == null)
            {
                return transform.position;
            }
            else
            {
                return _spawnPosition.position;
            }
        }

        public void Enter()
        {
            if (_coroutine != null) return;
            
            _coroutine = StartCoroutine(ExitScene());
        }

        private IEnumerator ExitScene()
        {
            _changeLevelAnimation.Animate(_animationTime);
            yield return new WaitForSeconds(_animationTime);
            LoadScene();
        }

        private void LoadScene()
        {
            InputFolder.Disable();
            _currentLocation.SetLocation(_locations);
            
            new EventSender().SendLevelFinish("hub");
            
            SceneManager.LoadScene(_lockationName[_locations]);
        }
    }
}