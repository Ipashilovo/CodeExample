using System.Collections.Generic;
using BulletData;

namespace Gun
{
    [System.Serializable]
    public class GunElementsByBase
    {
        public List<ColorType> Colors;
        public GunBase Gun;
        public List<AimType> Aim;
        public List<BulletType> Bullets;
        public List<ElementalType> Elementals;
    }
}