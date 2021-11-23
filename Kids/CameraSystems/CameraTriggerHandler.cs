using System;
using Player;
using UnityEngine;

namespace CameraSystems
{
    public class CameraTriggerHandler : MonoBehaviour
    {
        public event Action<Transform> Entered;
        public event Action Exited;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                Entered?.Invoke(playerFacade.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                Exited?.Invoke();
            }
        }
    }
}