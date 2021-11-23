using System.Collections.Generic;
using BulletData;

namespace Gun
{
    public static class GunElementsByBaseDefultCreater
    {
        public static GunElementsByBase CreateEmpty(GunBase gunBase)
        {
            GunElementsByBase gunElementsByBase = new GunElementsByBase()
            {
                Gun = gunBase,
                Bullets = new List<BulletType>(),
                Elementals = new List<ElementalType>(),
                Aim = new List<AimType>(),
                Colors =  new List<ColorType>()
            };
            return gunElementsByBase;
        }
    }
}