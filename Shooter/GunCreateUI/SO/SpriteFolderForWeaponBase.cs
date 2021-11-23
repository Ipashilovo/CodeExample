using Gun;
using UnityEngine;

namespace GunCreateUI.SO
{
    [CreateAssetMenu(fileName = "SpriteFolderForWeaponBase", menuName = "ScriptableObjects/MenuUI/SpriteFolderForWeaponBase", order = 1)]
    public class SpriteFolderForWeaponBase : ScriptableObject
    {
        [SerializeField] private GunBase _gunBase;
        [SerializeField] private ElementalTypeSpriteFolder _elementalTypeSpriteFolder;
        [SerializeField] private BulletTypeSpriteFolder _bulletTypeSpriteFolder;
        [SerializeField] private AimTypeSpriteFolder _aimTypeSpriteFolder;
        [SerializeField] private SkinTypeSpriteFolder _skinTypeSpriteFolder;

        public GunBase Gun => _gunBase;

        public SkinTypeSpriteFolder GetSkinFolder()
        {
            return _skinTypeSpriteFolder;
        }

        public ElementalTypeSpriteFolder GetElementalFolder()
        {
            return _elementalTypeSpriteFolder;
        }
        
        public BulletTypeSpriteFolder GetBulletFolder()
        {
            return _bulletTypeSpriteFolder;
        }

        public AimTypeSpriteFolder GetAimFolder()
        {
            return _aimTypeSpriteFolder;
        }

    }
}