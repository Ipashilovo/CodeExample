using LevelSystem;
using UnityEngine;
using Zenject;

namespace Stickmans
{
    public class StickmanInstaller : MonoInstaller
    {
        [SerializeField] private StickmanBulletPool _stickmanBulletPool;
        [SerializeField] private PlayerFacade _playerFacade;

        public override void InstallBindings()
        {
            var pool = Container.InstantiatePrefabForComponent<StickmanBulletPool>(_stickmanBulletPool);
            Container.Bind<StickmanBulletPool>().FromInstance(pool).AsSingle().NonLazy();
            Container.Bind<PlayerFacade>().FromInstance(_playerFacade).AsSingle().NonLazy();
        }
    }
}