using System;
using UnityEngine;

namespace LevelSystems
{
    public class TeleportableObject : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public float Lenght { get; private set; }

        private void Awake()
        {
            Lenght = _spriteRenderer.bounds.size.x;
        }
    }
}