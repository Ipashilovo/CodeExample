using System;
using UnityEngine;

namespace ActivityLevel.Environments
{
    public class TeleportWall : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        
        private void OnTriggerEnter(Collider other)
        {
            other.transform.position = _point.position;
        }
    }
}