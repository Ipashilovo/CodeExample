using System;
using System.Collections.Generic;
using System.Linq;
using ActivityLevel.Reward;
using BulletData;
using Gun;
using Newtonsoft.Json;
using UnityEngine;

namespace GameSystems.GunsInfo
{
    public class UnlockElementsFolder : MonoBehaviour
    {
        [SerializeField] private GunSO[] _gunsSo;
        private List<GunInfo> _gunInfos;
        private GunInfo _currentInfo;
        private List<GunBase> _unlockedGunBases;


        private void Awake()
        {
            InitGunInfo();
            GunBase gunBase = LoadCurrentGunBase();
            _currentInfo = _gunInfos.First(g => g.Type == gunBase);
        }

        public bool TryGetLockedGunBase(out GunBase gunBase)
        {
            var lockedGun = _gunsSo.Where(g => !_unlockedGunBases.Contains(g.Type)).ToArray();
            if (lockedGun.Length > 0)
            {
                gunBase = lockedGun[0].Type;
                return true;
            }

            gunBase = default;
            return false;
        }

        public GunElementsByBase GetUnlockedElements(GunBase gunModelType)
        {
            return _currentInfo.GetUnlockedElements();
        }

        public void SetAim(AimType aimType)
        {
            _currentInfo.SetAim(aimType);
        }

        public GunSaveData GetGunSaveData()
        {
            return _currentInfo.GetGunSaveData();
        }

        public List<GunElementsByBase> GetLockedElements()
        {
            List<GunElementsByBase> lockedElements = new List<GunElementsByBase>();
            foreach (var gunInfo in _gunInfos)
            {
                lockedElements.Add(gunInfo.GetLockedElements());
            }

            return lockedElements;
        }

        public GunElementsByBase GetLockedElementsByBase(GunBase gunBase)
        {
            var gunInfo = _gunInfos.First(g => g.Type == gunBase);
            return gunInfo.GetLockedElements();
        }

        public void SetNewCurrentGun(GunBase gunBase)
        {
            _currentInfo = _gunInfos.First(g => g.Type == gunBase);
            string json = JsonConvert.SerializeObject(_currentInfo.Type);
            PlayerPrefs.SetString(PlayerPrefsName.CurrentGun, json);
        }

        public GunBase[] GetUnlockedGunBases()
        {
            return _unlockedGunBases.ToArray();
        }

        public void SetElemental(ElementalType elementalType)
        {
            _currentInfo.SetElement(elementalType);
            _currentInfo.Save();
        }

        public void SetSkin(ColorType skin)
        {
            _currentInfo.SetColor(skin);
            _currentInfo.Save();
        }

        public void SetBullet(BulletType bulletType)
        {
            _currentInfo.SetBullet(bulletType);
            _currentInfo.Save();
        }

        public void Unlock(GunElementsByBase gunElementsByBase)
        {
            var info = _gunInfos.First(i => i.Type == gunElementsByBase.Gun);
            info.Unlock(gunElementsByBase);
        }

        public void UnlockGun(GunBase gunBase)
        {
            _unlockedGunBases.Add(gunBase);
            AddGunInfo(gunBase);
            string json = JsonConvert.SerializeObject(_unlockedGunBases);
            PlayerPrefs.SetString(PlayerPrefsName.UnlockedGun, json);
        }

        private GunBase LoadCurrentGunBase()
        {
            if (PlayerPrefs.HasKey(PlayerPrefsName.CurrentGun))
            {
                string json = PlayerPrefs.GetString(PlayerPrefsName.CurrentGun);
                GunBase gunBase = JsonConvert.DeserializeObject<GunBase>(json);
                return gunBase;
            }
            else
            {
                return _gunInfos[0].Type;
            }
        }

        private void InitGunInfo()
        {
            _unlockedGunBases = InitUnlockedGunBase();
            _gunInfos = new List<GunInfo>(_unlockedGunBases.Count);
            foreach (var gunBase in _unlockedGunBases)
            {
                AddGunInfo(gunBase);
            }
        }

        private void AddGunInfo(GunBase gunBase)
        {
            GunElementsByBase allElements = GetGunElements(gunBase);
            GunInfo gunInfo = new GunInfo(gunBase, allElements);
            _gunInfos.Add(gunInfo);
        }

        private GunElementsByBase GetGunElements(GunBase gunBase)
        {
            return _gunsSo.First(g => g.Type == gunBase).GetAllGunComponents();
        }

        private List<GunBase> InitUnlockedGunBase()
        {
            List<GunBase> unlockedGunBases;
            if (PlayerPrefs.HasKey(PlayerPrefsName.UnlockedGun))
            {
                string json = PlayerPrefs.GetString(PlayerPrefsName.UnlockedGun);
                unlockedGunBases = JsonConvert.DeserializeObject<List<GunBase>>(json);
            }
            else
            {
                unlockedGunBases = new List<GunBase>{GunBase.Pistol};
                string json = JsonConvert.SerializeObject(unlockedGunBases);
                PlayerPrefs.SetString(PlayerPrefsName.UnlockedGun, json);
            }
            return unlockedGunBases;
        }
    }
}