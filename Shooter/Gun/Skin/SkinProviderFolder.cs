using System;
using System.Collections.Generic;
using System.Linq;
using GunModelView;
using GunView;
using UnityEngine;

namespace Gun.Skin
{
    public class SkinProviderFolder : MonoBehaviour
    {
        [SerializeField] private SkinProvider[] _skinProviders;
        [SerializeField] private SkinFolderSo _skinFolderSo;
        [SerializeField] private GameObject _gunsSkinNameFolder;
        private GunSkinName[] _gunSkinNames;
        private ColorType _currentSkin;

        public string Name => _gunSkinNames.First(g => g.Type == _currentSkin).Name;
        private void Awake()
        {
            _gunSkinNames = _gunsSkinNameFolder.GetComponents<GunSkinName>();
            foreach (var skin in _skinProviders)
            {
                skin.Init(_skinFolderSo);
            }
        }

        public void SetSkin(ColorType skin)
        {
            _currentSkin = skin;
            foreach (var skinProvider in _skinProviders)
            {
                skinProvider.SetSkin(skin);
            }
        }

        public List<ColorType> GetTypes()
        {
            return _skinFolderSo.GetTypes();
        }
    }
}