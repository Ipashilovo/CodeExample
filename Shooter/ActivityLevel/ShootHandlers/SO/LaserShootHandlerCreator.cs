using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "LaserShootHandlerCreator", menuName = "ScriptableObjects/ShootHandler/LaserShootHandlerCreator", order = 1)]
    public class LaserShootHandlerCreator : ShootHandlerByType
    {
        [SerializeField] private float _timeToHot;
        [SerializeField] private float _cooldownMultiplate = 10;
        [SerializeField] private float _coolTimeMultipler;

        protected override ShootHandler CreateShootHandler(GunModel gunModel)
        {
            LaserShootHandler shootHandler = CreateEmptyGameObject().AddComponent<LaserShootHandler>();
            shootHandler.SetSpecialInit(_cooldownMultiplate, _timeToHot, _coolTimeMultipler);
            LaserViewMediator laserViewMediator = new LaserViewMediator(shootHandler, gunModel.GetLaserSlider());
            return shootHandler;
        }
    }
}