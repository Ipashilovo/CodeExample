using Gun;
using GunModelView;
using UnityEngine;

namespace GunView
{
    public class GunPieceElementalName : GunPieceName
    {
        [SerializeField] private ElementalType _elementalType;

        public ElementalType Type => _elementalType;
    }
}