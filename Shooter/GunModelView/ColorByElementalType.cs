using Gun;
using UnityEngine;

namespace GunView
{
    [CreateAssetMenu(fileName = "ColorByElementalType", menuName = "ScriptableObjects/GunView/ColorByElementalType", order = 1)]
    public class ColorByElementalType : ScriptableObject
    {
        [SerializeField] private ElementalType _elementalType;
        [SerializeField] private Color _color;
        [SerializeField] private Material _material;
        
        public ElementalType ElementalType => _elementalType;

        public Color GetColor()
        {
            return _color;
        }

        public Material GetMaterial()
        {
            return _material;
        }
    }
}