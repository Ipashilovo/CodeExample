using Gun;
using UnityEngine;

namespace BulletData.View
{
    [CreateAssetMenu(fileName = "MaterialByElementalType", menuName = "ScriptableObjects/Bullet/MaterialByElementalType", order = 1)]
    public class MaterialColorByElementalType : ScriptableObject
    {
        [SerializeField] private ElementalType _elementalType;
        [SerializeField] private Color _material;

        public ElementalType Type => _elementalType;

        public Color GetColor()
        {
            return _material;
        }
    }
}