using Zenject;

namespace Tutorials
{
    public class TutorialInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.InstantiateComponent(typeof(Tutorial), gameObject);
            Container.Bind<Tutorial>().FromComponentOn(gameObject).AsSingle().NonLazy();
        }
    }
}