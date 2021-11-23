using ActivityLevel.Barrel;
using DefaultNamespace.LevelSystem.Barrel;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.LevelSystem
{
    public class InteractiveInstaller : MonoInstaller
    {
        [SerializeField] private BarrelEffectsPoolFolder _barrelEffectsPoolFolder;

        public override void InstallBindings()
        {
            var barrel = Container.InstantiatePrefabForComponent<BarrelEffectsPoolFolder>(_barrelEffectsPoolFolder);
            Container.Bind<BarrelEffectsPoolFolder>().FromInstance(barrel).AsSingle().NonLazy();
        }
    }
}