using System;
using ActivityLevel.Reward;
using Gun;
using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "ShootHandlerCreator", menuName = "ScriptableObjects/ShootHandler/ShootHandlerCreator", order = 1)]

    public class ShootHandlerCreator : ScriptableObject
    {
        [SerializeField] private ShootHandlerByType[] _shootHandlerByTypes;
        [SerializeField] private ShootAudioSo[] _shootAudioSo;

        public ShootHandler GetShootHandler(GunSaveData gunSaveData, ElementalType elementalType, GunModel gunModel,
            EndLevelLisener endLevelLisener)
        {
            var handler =  CreateShootHandler(gunSaveData, elementalType, gunModel);
            handler.SetEndLevelLisener(endLevelLisener);
            foreach (var audioSo in _shootAudioSo)
            {
                if (audioSo.TryAddAudioSource(gunSaveData, handler))
                {
                    break;
                }
            }
            return handler;
        }

        private ShootHandler CreateShootHandler(GunSaveData gunSaveData, ElementalType elementalType, GunModel gunModel)
        {
            foreach (var shootHandler in _shootHandlerByTypes)
            {
                if (shootHandler.TryGetShootHandler(out ShootHandler newShootHandler, gunSaveData, elementalType, gunModel))
                {
                    return newShootHandler;
                }
            }

            throw new NullReferenceException(this.name);
        }
    }
}