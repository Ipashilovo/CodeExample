using System;
using Player;
using UnityEngine;

namespace LevelSystems
{
    public class TeleportCityCellTrigger : MonoBehaviour
    {
        [SerializeField] private TeleportableObject _currentObject;
        [SerializeField] private TeleportableObject _nextObject;
        [SerializeField, Range(-1,1)] private int _scale = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                Vector3 position = _currentObject.transform.position;
                position.y = _nextObject.transform.position.y;
                position.x += (_nextObject.Lenght - 0.1f + _currentObject.Lenght - 0.1f) / 2 * _scale;
                _nextObject.transform.position = position;
            }
        }
    }
}