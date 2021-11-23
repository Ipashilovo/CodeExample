using System;
using Interactive;
using UnityEngine;

namespace LevelSystems
{
    public class DestroybleFallItems : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractive interactive))
            {
                Destroy(other.gameObject);
            }
        }
    }
}