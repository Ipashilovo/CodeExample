using System;
using BulletData;
using Gun;
using Newtonsoft.Json;
using UnityEngine;

namespace GunCreateUI
{
    public class GunConfigurationSaver
    {
        private GunSaveData _configurationSave;

        public void SetNewCurrentGun(GunSaveData gunSaveData)
        {
            if (_configurationSave != null)
            {
                SaveConfiguration();
            }

            _configurationSave = gunSaveData;
        }

        public void SetAim(AimType aimType)
        {
            _configurationSave.Aim = aimType;
        }

        public void SetBullet(BulletType bulletType)
        {
            _configurationSave.Bullet = bulletType;
        }

        public void SetElemental(ElementalType elementalType)
        {
            _configurationSave.Elemental = elementalType;
        }

        public void SetSkin(ColorType skin)
        {
            _configurationSave.Skin = skin;
        }

        public void SaveConfiguration()
        {
            if (_configurationSave != null)
            {
                string jsonName = JsonConvert.SerializeObject(_configurationSave.Gun);
                PlayerPrefs.SetString(PlayerPrefsName.CurrentGun, jsonName);
                string json = JsonConvert.SerializeObject(_configurationSave);
                PlayerPrefs.SetString(_configurationSave.Gun.ToString() + typeof(GunSaveData), json);
            }
        }
    }
}