using System;
using Gun;
using UnityEngine;

namespace GunModelView
{
    public class GunSkinName : GunPieceName
    {
        [SerializeField] private ColorType _colorType;

        public ColorType Type => _colorType;
    }
}