using BulletData;
using GunView;

namespace Gun
{
    [System.Serializable]
    public class GunSaveData
    {
        public ColorType Skin;
        public GunBase Gun;
        public ElementalType Elemental;
        public BulletType Bullet;
        public AimType Aim;
    }
}