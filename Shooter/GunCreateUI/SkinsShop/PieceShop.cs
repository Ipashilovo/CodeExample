using System;
using System.Collections.Generic;
using DefaultNamespace.GameSystems;
using GameSystems.GunsInfo;
using Gun;
using GunCreateUI.ScrollViewContent;
using UnityEngine;
using Zenject;

namespace GunCreateUI.SkinsShop
{
    public class PieceShop : MonoBehaviour
    {
        private MoneyFolder _moneyFolder;
        private UnlockElementsFolder _unlockElementsFolder;
        private List<LockGunElementView> _lockGunElements = new List<LockGunElementView>();

        [Inject]
        public void Construct(MoneyFolder moneyFolder, UnlockElementsFolder unlockElementsFolder)
        {
            _unlockElementsFolder = unlockElementsFolder;
            _moneyFolder = moneyFolder;
        }

        private void OnDestroy()
        {
            Unfollow();
        }

        public void AddList(List<LockGunElementView> lockGunElementViews)
        {
            Follow(lockGunElementViews);
            _lockGunElements.AddRange(lockGunElementViews);
            CreateOutlineIfPossible();
        }

        private void Follow(List<LockGunElementView> lockGunElementViews)
        {
            foreach (var lockGun in lockGunElementViews)
            {
                lockGun.Selected += TryToBuy;
                lockGun.Destroing += RemoveElement;
            }
        }

        private void RemoveElement(LockGunElementView gunElementView)
        {
            gunElementView.Destroing -= RemoveElement;
            gunElementView.Selected -= TryToBuy;
            _lockGunElements.Remove(gunElementView);
        }

        private void Unfollow()
        {
            foreach (var lockGun in _lockGunElements)
            {
                lockGun.Selected -= TryToBuy;
                lockGun.Destroing -= RemoveElement;
            }
        }

        private void TryToBuy(LockGunElementView lockGunElementView)
        {
            if (lockGunElementView.Price <= _moneyFolder.Money)
            {
                Buy(lockGunElementView);
            }
        }

        private void Buy(LockGunElementView lockGunElementView)
        {
            RemoveElement(lockGunElementView);
            lockGunElementView.HineOutlineImage();
            _unlockElementsFolder.Unlock(lockGunElementView.Elements);
            _moneyFolder.RemoveMoney(lockGunElementView.Price);
            lockGunElementView.Unlock();
            CreateOutlineIfPossible();
        }

        private void CreateOutlineIfPossible()
        {
            foreach (var element in _lockGunElements)
            {
                if (element.Price <= _moneyFolder.Money)
                {
                    element.ShowOutline();
                }
                else
                {
                    element.HineOutlineImage();
                }
            }
        }
    }
}