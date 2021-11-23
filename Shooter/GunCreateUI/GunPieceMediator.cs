using System;
using BulletData;
using DefaultNamespace;
using DefaultNamespace.GunCreateUI;
using GameSystems;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;
using Zenject;

namespace GunCreateUI
{
    public class GunPieceMediator : MonoBehaviour
    {
        [SerializeField] private GunSelector _gunSelector;
        private GunModel _gunModel;
        private UnlockElementsFolder _unlockElementsFolder;
        public event Action<string> NameChanged;
        
        public void SetUnlockElementsFolder(UnlockElementsFolder unlockElementsFolder)
        {
            _unlockElementsFolder = unlockElementsFolder;
        }

        public void SetAim(AimType aimType)
        {
            _gunModel.SetAimModel(aimType);
            _unlockElementsFolder.SetAim(aimType);
            NameChanged?.Invoke(_gunModel.Name);
        }

        public void SetBullet(BulletType bulletType)
        {
            _gunModel.SetBulletType(bulletType);
            _unlockElementsFolder.SetBullet(bulletType);
            NameChanged?.Invoke(_gunModel.Name);
        }

        public void SetElemental(ElementalType elementalType)
        {
            _gunModel.SetElement(elementalType);
            _unlockElementsFolder.SetElemental(elementalType);
            NameChanged?.Invoke(_gunModel.Name);
        }

        public void SetColor(ColorType skin)
        {
            _gunModel.SetSkin(skin);
            _unlockElementsFolder.SetSkin(skin);
            NameChanged?.Invoke(_gunModel.Name);
        }

        public void SetNewModel(GunModel gunModel)
        {
            _gunModel = gunModel;
            _unlockElementsFolder.SetNewCurrentGun(gunModel.Type);
            GunSaveData gunSaveData = _unlockElementsFolder.GetGunSaveData();
            _gunModel.SetSaveData(gunSaveData);
            _gunSelector.SetNewSaveData(_unlockElementsFolder.GetUnlockedElements(gunModel.Type), _unlockElementsFolder.GetLockedElementsByBase(gunModel.Type), gunSaveData);
            NameChanged?.Invoke(_gunModel.Name);
        }

        public void SetLockedModel()
        {
            _gunSelector.Hide();
        }
    }
}