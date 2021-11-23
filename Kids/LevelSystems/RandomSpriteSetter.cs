using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelSystems
{
    public class RandomSpriteSetter : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];
        }
    }
}