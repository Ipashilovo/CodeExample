using System;
using DefaultNamespace.GameSystems;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;
using Zenject;

namespace GunCreateUI.Shop
{
    public class GunShop : MonoBehaviour
    {
        [SerializeField] private GunSoFolder _gunSoFolder;
        [SerializeField] private ShopView _shopView;
        private UnlockElementsFolder _unlockElementsFolder;
        private GunSO _currentGun;
        private GunBase _currentGunBase;
        private MoneyFolder _moneyFolder;

        public event Action<GunBase> Selled;

        [Inject]
        public void Init(MoneyFolder moneyFolder, UnlockElementsFolder unlockElementsFolder)
        {
            _unlockElementsFolder = unlockElementsFolder;
            _moneyFolder = moneyFolder;
        }

        private void OnEnable()
        {
            _shopView.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            _shopView.Clicked -= OnClicked;
        }

        public void SetLockedModel(GunBase gunBase)
        {
            _currentGunBase = gunBase;
            _currentGun = _gunSoFolder.GetGun(gunBase);
            if (_currentGun.Price <= _moneyFolder.Money)
            {
                _shopView.SetBuyOpportunity(_currentGun.Price);
            }
            else
            {
                _shopView.SetLockPrice(_currentGun.Price);
            }
        }

        public void Hide()
        {
            _shopView.Hide();
        }

        private void OnClicked()
        {
            if (_moneyFolder.Money >= _currentGun.Price)
            {
                _moneyFolder.RemoveMoney(_currentGun.Price);
                _unlockElementsFolder.UnlockGun(_currentGunBase);
                Selled?.Invoke(_currentGunBase);
            }
        }
    }
}