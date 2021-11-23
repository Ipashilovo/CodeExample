using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "MachinegunRocketShootHandlerSo", menuName = "ScriptableObjects/ShootHandler/MachinegunRocketShootHandlerSo", order = 1)]

    public class MachinegunRocketShootHandlerSo : ShootHandlerByType
    {
        [SerializeField] private int _queueCount = 3;
        [SerializeField, Range(0, 0.5f)] private float _delayBetweenShoot;
        [SerializeField, Min(2f)] private float _cooldownMultipler;

        protected override ShootHandler CreateShootHandler(GunModel gunModel)
        {
            MachinegunRocketShootHandler shootHandler = CreateEmptyGameObject().AddComponent<MachinegunRocketShootHandler>();
            shootHandler.SetQueueData(_queueCount, _delayBetweenShoot, _cooldownMultipler);
            return shootHandler;
        }
    }
}