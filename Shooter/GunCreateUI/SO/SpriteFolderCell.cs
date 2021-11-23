using UnityEngine;

namespace GunCreateUI.SO
{
    public abstract class SpriteFolderCell<T> : ScriptableObject
    {
        [SerializeField] private T _type;
        [SerializeField] private Sprite _sprite;

        public T Type => _type;

        public Sprite GetSprite()
        {
            return _sprite;
        }
    }
}