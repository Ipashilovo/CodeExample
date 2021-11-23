using System;
using UnityEngine;

namespace City
{
    public abstract class LockationChangeAnimation : MonoBehaviour
    {
        [SerializeField] private LockationTrigger _lockationTrigger;

        private void OnEnable()
        {
            _lockationTrigger.Coming += OnComing;
            _lockationTrigger.Removed += OnRemoved;
        }

        private void OnDisable()
        {
            _lockationTrigger.Coming -= OnComing;
            _lockationTrigger.Removed -= OnRemoved;
        }

        protected abstract void OnRemoved();

        protected abstract void OnComing();
    }
}