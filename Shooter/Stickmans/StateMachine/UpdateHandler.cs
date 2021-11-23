using System;
using UnityEngine;

namespace Stickmans.StateMachine
{
    public class UpdateHandler : MonoBehaviour
    {
        public event Action Updating;

        private void Update()
        {
            Updating?.Invoke();
        }
    }
}