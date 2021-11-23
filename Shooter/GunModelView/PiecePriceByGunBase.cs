using System;
using Gun;
using UnityEngine;

namespace GunModelView
{
    public class PiecePriceByGunBase<T> : ScriptableObject
    {
        [SerializeField] private GunBase _gunBase;
        [SerializeField] private SkinPrice<T>[] _skinPrices;

        public GunBase Type => _gunBase;

        public SkinPrice<T>[] GetSkinPrices()
        {
            return _skinPrices;
        }
    }

    [Serializable]
    public class SkinPrice<T>
    {
        public T Type;
        public int Price;
    }
}