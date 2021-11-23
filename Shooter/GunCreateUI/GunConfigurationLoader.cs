using System;
using System.Collections.Generic;
using System.Linq;
using BulletData;
using Gun;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace.GunCreateUI
{
    public class GunConfigurationLoader
    {
        public GunSaveData Load(GunBase gunBase)
        {
            if (PlayerPrefs.HasKey(gunBase.ToString() + typeof(GunSaveData)))
            {
                string json = PlayerPrefs.GetString(gunBase.ToString() + typeof(GunSaveData));
                GunSaveData gunSaveData = JsonConvert.DeserializeObject<GunSaveData>(json);
                return gunSaveData;
            }

            GunSaveData newSaveData = new GunSaveData();
            newSaveData.Gun = gunBase;
            return newSaveData;
        }

        public void UnlockAll(GunModel gunModel)
        {
            GunElementsByBase gunElementsByBase = gunModel.GetGunInfo();
            string json = JsonConvert.SerializeObject(gunElementsByBase);
            PlayerPrefs.SetString(gunModel.Type.ToString() + typeof(GunElementsByBase), json);
        }
    }
}