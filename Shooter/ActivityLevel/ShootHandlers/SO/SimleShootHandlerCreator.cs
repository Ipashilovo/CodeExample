using UnityEngine;

namespace ActivityLevel.ShootHandlers
{
    [CreateAssetMenu(fileName = "SimleShootHandlerCreator", menuName = "ScriptableObjects/ShootHandler/SimleShootHandlerCreator", order = 1)]
    public class SimleShootHandlerCreator : ShootHandlerByType
    {
        protected override ShootHandler CreateShootHandler(GunModel gunModel)
        {
            ShootHandler shootHandler = CreateEmptyGameObject().AddComponent<SimpleShootHandler>();
            return shootHandler;
        }
    }
}