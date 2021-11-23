using System.Linq;
using BulletData;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "ShootAudioSo", menuName = "ScriptableObjects/Audio/ShootAudioSo", order = 1)]
    public class ShootAudioSo : ScriptableObject
    {
        [SerializeField] private bool _isPlaySoundEveryShoot;
        [SerializeField] private ShootAudioHandler _shootAudioSource;
        [SerializeField] private GunBase[] _gunBases;
        [SerializeField] private BulletType[] _bulletTypes;
        [SerializeField] private AudioClip _audioClip;

        public bool TryAddAudioSource(GunSaveData gunSaveData, ShootHandler shootHandler)
        {
            if (_gunBases.Contains(gunSaveData.Gun) && _bulletTypes.Contains(gunSaveData.Bullet))
            {
                var newAudioHandler = Instantiate(_shootAudioSource, shootHandler.transform);
                newAudioHandler.Init(_audioClip, shootHandler, _isPlaySoundEveryShoot);
                return true;
            }

            return false;
        }
    }
}