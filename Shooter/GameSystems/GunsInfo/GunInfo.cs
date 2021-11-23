using System.Collections.Generic;
using System.Linq;
using BulletData;
using Gun;
using ModestTree;
using Newtonsoft.Json;
using UnityEngine;

namespace GameSystems.GunsInfo
{
    public class GunInfo
    {
        public readonly GunBase Type;
        private GunElementsByBase _unlockedElements;
        private GunElementsByBase _allElements;
        private GunSaveData _gunSaveData;

        public GunInfo(GunBase type, GunElementsByBase allElements)
        {
            Type = type;
            _allElements = allElements;
            LoadGunSaveData();
            LoadUnlockedElements();
        }

        private void LoadUnlockedElements()
        {
            if (PlayerPrefs.HasKey(Type.ToString() + typeof(GunElementsByBase)))
            {
                string json = PlayerPrefs.GetString(Type.ToString() + typeof(GunElementsByBase));
                _unlockedElements = JsonConvert.DeserializeObject<GunElementsByBase>(json);
            }
            else
            {
                _unlockedElements = new GunElementsByBase
                {
                    Gun = Type,
                    Elementals = new List<ElementalType> {ElementalType.None},
                    Bullets = new List<BulletType> {BulletType.SimpleBullet},
                    Aim = new List<AimType> {AimType.None},
                    Colors = new List<ColorType> {ColorType.White}
                };
            }
        }

        public void Save()
        {
            SaveConfiguration();
            SaveUnlockedElements();
        }

        private void SaveConfiguration()
        {
            string gunSaveDatajson = JsonConvert.SerializeObject(_gunSaveData);
            PlayerPrefs.SetString(Type.ToString() + typeof(GunSaveData), gunSaveDatajson);
        }

        private void SaveUnlockedElements()
        {
            string unlockedElementsJson = JsonConvert.SerializeObject(_unlockedElements);
            PlayerPrefs.SetString(Type.ToString() + typeof(GunElementsByBase), unlockedElementsJson);
        }

        private void LoadGunSaveData()
        {
            if (PlayerPrefs.HasKey(Type.ToString() + typeof(GunSaveData)))
            {
                string json = PlayerPrefs.GetString(Type.ToString() + typeof(GunSaveData));
                _gunSaveData = JsonConvert.DeserializeObject<GunSaveData>(json);
            }
            else
            {
                GunSaveData newSaveData = new GunSaveData()
                {
                    Gun = Type,
                    Elemental = ElementalType.None,
                    Bullet = BulletType.SimpleBullet,
                    Aim = AimType.None,
                    Skin = ColorType.White
                };
                newSaveData.Gun = Type;
                _gunSaveData = newSaveData;
            }
        }

        public GunElementsByBase GetUnlockedElements()
        {
            return _unlockedElements;
        }

        public GunSaveData GetGunSaveData()
        {
            return _gunSaveData;
        }

        public GunElementsByBase GetLockedElements()
        {
            GunElementsByBase gunElementsByBase = new GunElementsByBase()
            {
                Gun = Type,
                Elementals = _allElements.Elementals.Except(_unlockedElements.Elementals).ToList(),
                Bullets = _allElements.Bullets.Except(_unlockedElements.Bullets).ToList(),
                Aim = _allElements.Aim.Except(_unlockedElements.Aim).ToList(),
                Colors = _allElements.Colors.Except(_unlockedElements.Colors).ToList()
            };
            return gunElementsByBase;
        }

        public void SetAim(AimType aimType)
        {
            _gunSaveData.Aim = aimType;
            SaveConfiguration();
        }

        public void SetBullet(BulletType bullet)
        {
            _gunSaveData.Bullet = bullet;
            SaveConfiguration();
        }

        public void SetElement(ElementalType elementalType)
        {
            _gunSaveData.Elemental = elementalType;
            SaveConfiguration();
        }

        public void SetColor(ColorType colorType)
        {
            _gunSaveData.Skin = colorType;
            SaveConfiguration();
        }

        public void Unlock(GunElementsByBase gunElementsByBase)
        {
            _unlockedElements.Aim.AddRange(gunElementsByBase.Aim);
            _unlockedElements.Aim = _unlockedElements.Aim.Distinct().ToList();
            _unlockedElements.Bullets.AddRange(gunElementsByBase.Bullets);
            _unlockedElements.Bullets = _unlockedElements.Bullets.Distinct().ToList();
            _unlockedElements.Elementals.AddRange(gunElementsByBase.Elementals);
            _unlockedElements.Elementals = _unlockedElements.Elementals.Distinct().ToList();
            _unlockedElements.Colors.AddRange(gunElementsByBase.Colors);
            _unlockedElements.Colors = _unlockedElements.Colors.Distinct().ToList();
            SaveUnlockedElements();
        }
    }
}