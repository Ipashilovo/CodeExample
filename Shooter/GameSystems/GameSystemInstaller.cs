using DefaultNamespace.Input;
using GameSystems;
using GameSystems.GunsInfo;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.GameSystems
{
    public class GameSystemInstaller : MonoInstaller
    {
        [SerializeField] private UnlockElementsFolder _unlockElementsFolder;
        [SerializeField] private RewardLooker _rewardLooker;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private MoneyFolder _moneyFolder;
        [SerializeField] private InputFolder _inputFolder;
        
        public override void InstallBindings()
        {
            var folder = Container.InstantiatePrefabForComponent<UnlockElementsFolder>(_unlockElementsFolder, transform);
            Container.Bind<UnlockElementsFolder>().FromInstance(folder).AsSingle().NonLazy();
            var money = Container.InstantiatePrefabForComponent<MoneyFolder>(_moneyFolder, transform);
            Container.Bind<MoneyFolder>().FromInstance(money).AsSingle().NonLazy();
            var input = Container.InstantiatePrefabForComponent<InputFolder>(_inputFolder, transform);
            Container.Bind<InputFolder>().FromInstance(input).AsSingle().NonLazy();
            var levelLoader = Container.InstantiatePrefabForComponent<LevelLoader>(_levelLoader, transform);
            Container.Bind<LevelLoader>().FromInstance(levelLoader).AsSingle().NonLazy();
            var rewardLooker = Container.InstantiatePrefabForComponent<RewardLooker>(_rewardLooker, transform);
            rewardLooker.Init(levelLoader, folder);
            Container.Bind<RewardLooker>().FromInstance(rewardLooker).AsSingle().NonLazy();
        }
    }
}