using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelSystems.BackGround
{
    public class CloudTrigger : MonoBehaviour
    {
        [SerializeField] private Transform _teleportPoint;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Vector3 position = other.transform.position;
            position.x = _teleportPoint.position.x;
            other.transform.position = position;

            int value = Random.Range(0, 2);
            other.transform.Rotate(0,0, 180 * value);
        }
    }
}