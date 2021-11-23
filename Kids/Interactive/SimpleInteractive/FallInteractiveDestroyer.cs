using System;
using UnityEngine;

namespace Interactive.SimpleInteractive
{
    public class FallInteractiveDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out FallInteractive fallInteractive))
            {
                Destroy(fallInteractive.gameObject);
            }
        }
    }
}