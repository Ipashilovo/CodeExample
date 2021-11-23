using DefaultNamespace.UI;
using UnityEngine;
using Zenject;

namespace ActivityLevel.Injections
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private StateUIFolder _stateUIFolder;
        public override void InstallBindings()
        {
            Container.Bind<StateUIFolder>().FromInstance(_stateUIFolder).AsSingle();
        }
    }
}