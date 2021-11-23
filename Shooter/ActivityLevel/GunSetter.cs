using System;
using ActivityLevel.Reward;
using ActivityLevel.ShootHandlers;
using ActivityLevel.ShootHandlers.SO;
using BulletData;
using BulletData.BulletsType;
using DefaultNamespace;
using DefaultNamespace.GunCreateUI;
using DefaultNamespace.Input;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;
using Zenject;

namespace ActivityLevel
{
    public class GunSetter : MonoBehaviour
    {
        [SerializeField] private ShootHandlerCreator _shootHandlerCreator;
        [SerializeField] private GunSoFolder _gunSoFolder;
        [SerializeField] private BulletCreator _bulletCreator;
        [SerializeField] private Transform _gunPosition;
        [SerializeField] private EndLevelLisener _endLevelLisener;
        private InputFolder _inputFolder;
        private ShootHandler _shootHandler;
        

        private UnlockElementsFolder _unlockElementsFolder;
        public event Action<GunModel> GunCreated;

        public void Init(UnlockElementsFolder unlockElementsFolder, InputFolder inputFolder)
        {
            _inputFolder = inputFolder;
            _unlockElementsFolder = unlockElementsFolder;
        }

        private void Start()
        {
            GunSaveData gunSaveData = _unlockElementsFolder.GetGunSaveData();
            GunSO gunSo = _gunSoFolder.GetGun(gunSaveData.Gun);
            GunModel gunModel = CreateGun(gunSaveData.Gun, gunSaveData, gunSo);
            CreateShootHandler(gunSaveData, gunModel, gunSo);
            GunCreated?.Invoke(gunModel);
        }

        private void CreateShootHandler(GunSaveData gunSaveData, GunModel gunModel, GunSO gunSo)
        {
            Bullet bullet = _bulletCreator.CreateBullet(gunSaveData, gunModel.GetDamageMultiplicate(), gunSo);
            _shootHandler = _shootHandlerCreator.GetShootHandler(gunSaveData, gunSaveData.Elemental, gunModel, _endLevelLisener);
            _shootHandler.Init(bullet, gunModel.GetGun(), _inputFolder);
        }

        public void EnableShootHandler()
        {
            _shootHandler.gameObject.SetActive(true);
        }

        private GunModel CreateGun(GunBase gunBase, GunSaveData gunSaveData, GunSO gunSo)
        {
            GunModel gunModel = gunSo.GetGunModel();
            var gun = Instantiate(gunModel, _gunPosition);
            gun.SetSaveData(gunSaveData);
            return gun;
        }
    }
}