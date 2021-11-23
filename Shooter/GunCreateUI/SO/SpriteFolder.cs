using UnityEngine;

namespace GunCreateUI.SO
{
    public abstract class SpriteFolder<T> : ScriptableObject
    {
        [SerializeField] private SpriteFolderCell<T>[] _spriteFolders;

        public SpriteFolderCell<T>[] GetSprites()
        {
            return _spriteFolders;
        }
    }
}