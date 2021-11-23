using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Gun.Skin
{
    [CreateAssetMenu(fileName = "SkinFolderSo", menuName = "ScriptableObjects/Skins/SkinFolderSo", order = 1)]
    public class SkinFolderSo : ScriptableObject
    {
        [SerializeField] private ColorBySkinType[] _colorBySkinTypes;
        private int index;
        
        public Color GetColor(ColorType skin)
        {
            if (_colorBySkinTypes[index].Type == skin)
            {
                return _colorBySkinTypes[index].Color;
            }
            else
            {
                if (_colorBySkinTypes.Any(m => m.Type == skin))
                {
                    index = _colorBySkinTypes.IndexOf(_colorBySkinTypes.First(m => m.Type == skin));
                    return _colorBySkinTypes[index].Color;
                }

                return _colorBySkinTypes[0].Color;
            }
        }

        public List<ColorType> GetTypes()
        {
            List<ColorType> types = new List<ColorType>();
            foreach (var color in _colorBySkinTypes)
            {
                types.Add(color.Type);
            }

            return types;
        }
    }

    [System.Serializable]
    public class ColorBySkinType
    {
        public Color Color;
        public ColorType Type;
    }
}