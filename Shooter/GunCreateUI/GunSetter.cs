using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameSystems.GunsInfo;
using Gun;
using GunCreateUI.Shop;
using ModestTree;
using UnityEngine;

namespace GunCreateUI
{
    public class GunSetter : MonoBehaviour
    {
        [SerializeField] private GunPieceMediator _gunPieceMediator;
        [SerializeField] private GunModelViewMover[] _gunModelViewMovers;
        [SerializeField] private GunShop _gunShop;
        private UnlockElementsFolder _unlockElementsFolder;
        private List<GunBase> _unlockedGun;
        private Coroutine _coroutine;

        private GunModelViewMover _currentGunModelViewMover;

        private int _currentNumber;

        private void OnEnable()
        {
            _gunShop.Selled += AddGun;
        }

        private void OnDisable()
        {
            _gunShop.Selled -= AddGun;
        }

        public void SetUnlockElementsFolder(UnlockElementsFolder unlockElementsFolder)
        {
            _unlockElementsFolder = unlockElementsFolder;
        }

        private void Start()
        {
            SetUnlockedModels(_unlockElementsFolder.GetUnlockedGunBases());
        }

        private void SetUnlockedModels(GunBase[] gunBases)
        {
            _unlockedGun = gunBases.ToList();
            GunBase gunBase = _unlockElementsFolder.GetGunSaveData().Gun;
            _currentNumber = _gunModelViewMovers.IndexOf(
                _gunModelViewMovers
                    .First(g => g.Type == gunBase));
            
            _currentGunModelViewMover = _gunModelViewMovers[_currentNumber];
            _currentGunModelViewMover.MoveToCenterByLeftSide();
            _gunPieceMediator.SetNewModel(_currentGunModelViewMover.GetGunModel());
        }

        public void OnRightClick()
        {
            if (_coroutine != null) return;

            _currentNumber--;
            if (_currentNumber < 0)
            {
                _currentNumber = _gunModelViewMovers.Length - 1;
            }
            _currentGunModelViewMover.MoveRight();
            _currentGunModelViewMover = _gunModelViewMovers[_currentNumber];
            _currentGunModelViewMover.MoveToCenterByLeftSide();
            ChangeModel();
        }

        public void OnLeftClick()
        {
            if (_coroutine != null) return;
            
            _currentNumber++;
            _currentNumber %= _gunModelViewMovers.Length;
            _currentGunModelViewMover.MoveLeft();
            _currentGunModelViewMover = _gunModelViewMovers[_currentNumber];
            _currentGunModelViewMover.MoveToCenterByRightSide();
            ChangeModel();
        }

        private void ChangeModel()
        {
            SetModelByLockType();
            _coroutine = StartCoroutine(Cooldown());
        }

        private void SetNewModel(GunBase gunBase)
        {
            _gunPieceMediator.SetNewModel(_currentGunModelViewMover.GetGunModel());
        }

        private void AddGun(GunBase gunBase)
        {
            _unlockedGun.Add(gunBase);
            _gunShop.Hide();
            SetNewModel(gunBase);
        }

        private void SetModelByLockType()
        {
            if (_unlockedGun.Contains(_currentGunModelViewMover.Type))
            {
                _gunShop.Hide();
                SetNewModel(_currentGunModelViewMover.Type);
            }
            else
            {
                _gunPieceMediator.SetLockedModel();
            }
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(1);
            _coroutine = null;
        }
    }
}