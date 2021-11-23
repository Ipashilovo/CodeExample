using System;
using ActivityLevel.Barrel;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.LevelSystem.Barrel
{
    public class BarrelInjection : MonoBehaviour
    {
        [SerializeField] private Barrel _barrel;
        private BarrelEffectsPoolFolder _barrelEffectsPoolFolder;

        [Inject]
        public void Construct(BarrelEffectsPoolFolder barrelEffectsPoolFolder)
        {
            _barrelEffectsPoolFolder = barrelEffectsPoolFolder;
        }

        private void Start()
        {
            _barrel.Init(_barrelEffectsPoolFolder.GetForcePool(), _barrelEffectsPoolFolder.GetDamagePool());
        }
    }
}