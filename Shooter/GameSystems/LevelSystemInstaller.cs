using ActivityLevel;
using DefaultNamespace.UI.Rewards;
using LevelSystem;
using UnityEngine;
using Zenject;

namespace GameSystems
{
    public class LevelSystemInstaller : MonoInstaller
    {
        [SerializeField] private RewardView _rewardView;
        [SerializeField] private CameraHandler _cameraHandler;
        private FirstInputLisener _firstInputLisener;
        
        public override void InstallBindings()
        {
            _firstInputLisener = Container.InstantiateComponent<FirstInputLisener>(new GameObject());
            Container.Bind<FirstInputLisener>().FromInstance(_firstInputLisener).AsSingle().NonLazy();
            Container.Bind<RewardView>().FromInstance(_rewardView).AsSingle();
            Container.Bind<CameraHandler>().FromInstance(_cameraHandler).AsSingle();
        }
    }
}