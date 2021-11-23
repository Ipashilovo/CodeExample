using System;
using System.Collections.Generic;
using BulletData;
using Gun;
using GunCreateUI;
using GunCreateUI.ScrollViewContent;
using GunCreateUI.SO;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.GunCreateUI
{
    public class GunSelector : MonoBehaviour
    {
        [SerializeField] private GunsSpriteFolder _gunsSpriteFolder;
        [SerializeField] private GunPieceMediator _gunPieceMediator;
        [SerializeField] private SkinTypeViewUI _skinTypeViewUI;
        [SerializeField] private AimTypeViewUI _aimTypeViewUI;
        [SerializeField] private BulletTypeViewUI _bulletTypeViewUI;
        [SerializeField] private ElementTypeViewUI _elementTypeViewUI;
        [SerializeField] private Text _text;
        [SerializeField] private ButtonConteinerLisener _buttonConteinerLisener;

        private void OnEnable()
        {
            _gunPieceMediator.NameChanged += SetNewName; 
            _aimTypeViewUI.SelectPiece += OnSelectAim;
            _bulletTypeViewUI.SelectPiece += OnSelectBullet;
            _elementTypeViewUI.SelectPiece += OnSelectElemental;
            _skinTypeViewUI.SelectPiece += OnSelectSkin;
        }

        private void OnDisable()
        {
            _gunPieceMediator.NameChanged -= SetNewName;
            _aimTypeViewUI.SelectPiece -= OnSelectAim;
            _bulletTypeViewUI.SelectPiece -= OnSelectBullet;
            _elementTypeViewUI.SelectPiece -= OnSelectElemental;
            _skinTypeViewUI.SelectPiece -= OnSelectSkin;
        }

        public void SetNewSaveData(GunElementsByBase unlockedElements, GunElementsByBase lockedElement, GunSaveData gunSaveData)
        {
            var gunFolder = _gunsSpriteFolder.GetSpriteFolder(unlockedElements.Gun);
            _aimTypeViewUI.CreateView(unlockedElements.Aim, lockedElement.Aim, gunFolder.GetAimFolder(), unlockedElements.Gun);
            _bulletTypeViewUI.CreateView(unlockedElements.Bullets, lockedElement.Bullets, gunFolder.GetBulletFolder(), unlockedElements.Gun);
            _elementTypeViewUI.CreateView(unlockedElements.Elementals, lockedElement.Elementals, gunFolder.GetElementalFolder(), unlockedElements.Gun);
            
            _skinTypeViewUI.CreateView(unlockedElements.Colors, lockedElement.Colors, gunFolder.GetSkinFolder(), unlockedElements.Gun, true); 
            
            _buttonConteinerLisener.ShowSelected();
        }

        public void Hide()
        {
            _aimTypeViewUI.CreateEmpty();
            _bulletTypeViewUI.CreateEmpty();
            _elementTypeViewUI.CreateEmpty();
            _skinTypeViewUI.CreateEmpty();
            _text.text = "";
        }

        private void SetNewView()
        {
            
        }

        private void SetNewName(string text)
        {
            _text.text = text;
        }

        private void OnSelectAim(AimType aimType)
        {
            _gunPieceMediator.SetAim(aimType);
        }

        private void OnSelectSkin(ColorType skin)
        {
            _gunPieceMediator.SetColor(skin);
        }

        private void OnSelectBullet(BulletType bulletType)
        {
            _gunPieceMediator.SetBullet(bulletType);
        }

        private void OnSelectElemental(ElementalType elementalType)
        {
            _gunPieceMediator.SetElemental(elementalType);
        }
    }
}