using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "MachinegunShootHandlerSo", menuName = "ScriptableObjects/ShootHandler/MachinegunShootHandlerSo", order = 1)]

    public class MachinegunShootHandlerSo : ShootHandlerByType
    {
        protected override ShootHandler CreateShootHandler(GunModel gunModel)
        {
            MachinegunShootHandler shootHandler = CreateEmptyGameObject().AddComponent<MachinegunShootHandler>();
            return shootHandler;
        }
    }
}