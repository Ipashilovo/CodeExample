using System;
using GameSystems.GunsInfo;
using Gun;
using UnityEngine;
using UnityEngine.UI;

namespace UI.StartGame
{
    public class GunNameView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GunSoFolder _gunSoFolder;
        private UnlockElementsFolder _unlockElementsFolder;

        public void Init(UnlockElementsFolder unlockElementsFolder)
        {
            _unlockElementsFolder = unlockElementsFolder;
        }

        private void Start()
        {
            var gunSaveData = _unlockElementsFolder.GetGunSaveData();
            var currentSo = _gunSoFolder.GetGun(gunSaveData.Gun);
            _text.text = currentSo.GetName(gunSaveData);
        }
    }
}