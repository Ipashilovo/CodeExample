using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class InputHandler : MonoBehaviour
    {
        public abstract event Action Clicked;
    }
}