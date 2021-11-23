using System;
using UnityEngine;

namespace Interactive.SimpleInteractive
{
    public class InfinityRotation : MonoBehaviour, ISimpleInteractive
    {
        [SerializeField] private float _rotateSpeed;

        private void Update()
        {
            transform.Rotate(0,0, _rotateSpeed * Time.deltaTime);
        }

        public void Interact()
        {
            enabled = true;
        }

        public void StopInteract()
        { 
            enabled = false;
        }
    }
}