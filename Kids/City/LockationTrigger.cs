using System;
using Interactive;
using Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace City
{
    public class LockationTrigger : MonoBehaviour
    {
        [SerializeField] private LocationExitButton _locationExitButton;
        public event Action Coming;
        public event Action Removed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                _locationExitButton.Show();
                Coming?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerFacade playerFacade))
            {
                _locationExitButton.Hide();
                Removed?.Invoke();
            }
        }
    }
}