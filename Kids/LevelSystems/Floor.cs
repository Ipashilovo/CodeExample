using System;
using Player;
using UnityEngine;

namespace LevelSystems
{
    public class Floor : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IBurdMovementAnimation burdMovementAnimation))
            {
                burdMovementAnimation.Walk();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IBurdMovementAnimation burdMovementAnimation))
            {
                burdMovementAnimation.Fly();
            }
        }
    }
}