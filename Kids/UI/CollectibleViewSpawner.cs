using System;
using System.Collections.Generic;
using GameSystems.Collectibles;
using UnityEngine;

namespace UI
{
    public class CollectibleViewSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        [SerializeField] private CollectibleFolder _collectibleFolder;
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private CollectibleViewCell _collectibleViewCell;
        
        public List<CollectibleViewCell> Spawn()
        {
            List<CollectibleViewCell> collectibleViewCells = new List<CollectibleViewCell>();
            foreach (var collectible in _collectibleFolder.GetCollectibles())
            {
                var newCollectible = Instantiate(_collectibleViewCell, _content);
                newCollectible.Init(collectible, _audioSource);
                collectibleViewCells.Add(newCollectible);
            }

            return collectibleViewCells;
        }
    }
}