using System.Linq;
using Gun;
using UnityEngine;

namespace GunCreateUI.SO
{
    [CreateAssetMenu(fileName = "GunsSpriteFolder", menuName = "ScriptableObjects/MenuUI/GunsSpriteFolder", order = 1)]

    public class GunsSpriteFolder : ScriptableObject
    {
        [SerializeField] private SpriteFolderForWeaponBase[] _spriteFolderForWeaponBases;

        public SpriteFolderForWeaponBase GetSpriteFolder(GunBase gunBase)
        {
            var currentFolder = _spriteFolderForWeaponBases.First(g => g.Gun == gunBase);
            return currentFolder;
        }
    }
}