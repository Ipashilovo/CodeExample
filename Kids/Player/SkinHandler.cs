using System;
using System.Linq;
using GameSystems;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class SkinHandler : MonoBehaviour, ISkinHandler
    {
        [SerializeField] private SkeletonAnimation _skeletonAnimation;

        private string[] _skinNames =
        {
            "Classic",
            "Dress_1",
            "Dress_2"
        };

        private string _currentSkin;

        private void Start()
        {
            LoadSkin();
            SetSkin();
        }

        public void SetRandomSkin()
        {
            var skins = _skinNames.Where(s => s != _currentSkin).ToArray();
            _currentSkin = skins[Random.Range(0, skins.Length)];
            SetSkin();
            SaveSkin();
        }

        private void SaveSkin()
        {
            PlayerPrefs.SetString(PlayerPrefsName.SkinName, _currentSkin);
        }

        private void LoadSkin()
        {
            _currentSkin = PlayerPrefs.GetString(PlayerPrefsName.SkinName, _skinNames[0]);
        }

        private void SetSkin()
        {
            _skeletonAnimation.Skeleton.SetSkin(_currentSkin);
            _skeletonAnimation.Skeleton.SetSlotsToSetupPose();
            _skeletonAnimation.LateUpdate();
        }
    }
}