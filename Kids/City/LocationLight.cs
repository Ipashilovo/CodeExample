using System;
using UnityEngine;

namespace City
{
    public class LocationLight : MonoBehaviour
    {
        [SerializeField] private LockationTrigger _lockationTrigger;

        private void Awake()
        {
            _lockationTrigger.Coming += Show;
            _lockationTrigger.Removed += Hide;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _lockationTrigger.Coming -= Show;
            _lockationTrigger.Removed -= Hide;
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void Show()
        {
            gameObject.SetActive(true);
        }
    }
}