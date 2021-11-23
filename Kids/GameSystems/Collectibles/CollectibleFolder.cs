using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace GameSystems.Collectibles
{
    [CreateAssetMenu(fileName = "CollectibleFolder", menuName = "ScriptableObjects/Collectibles/CollectibleFolder", order = 1)]
    public class CollectibleFolder : ScriptableObject
    {
        [SerializeField] private Collectible[] _collectibles;

        public Collectible[] GetCollectibles()
        {
            return _collectibles;
        }
    }
}