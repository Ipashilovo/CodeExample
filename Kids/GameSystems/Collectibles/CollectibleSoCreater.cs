#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace GameSystems.Collectibles
{
    [CreateAssetMenu(fileName = "CollectibleSoCreater", menuName = "ScriptableObjects/Collectibles/CollectibleSoCreater", order = 1)]
    public class CollectibleSoCreater : ScriptableObject
    {
        [SerializeField] private Collectible[] _collectibles;
        [SerializeField] private Sprite[] _sprites;

        [ContextMenu("SetSprites")]
        public void SetSprites()
        {
            for (int i = 0; i < _collectibles.Length; i++)
            {
                _collectibles[i].SetSprite(_sprites[i]);
            }
        }
        
        private void OnValidate()
        {
            for (int i = 0; i < _collectibles.Length; i++)
            {
                _collectibles[i].SetSprite(_sprites[i]);
            }
        }
        
        [ContextMenu("ClearCount")]
        public void Clear()
        {
            foreach (var collectible in _collectibles)
            {
                collectible.ClearCount();
            }
        }
    }
}
#endif