using System;
using UnityEngine;

namespace Interactive
{
    public interface IInteractive
    {
        public event Action Interacting;
        public event Action EndInteracting;
    }
}