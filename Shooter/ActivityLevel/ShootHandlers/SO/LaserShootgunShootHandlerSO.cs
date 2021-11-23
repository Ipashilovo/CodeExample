using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "LaserShootgunShootHandler", menuName = "ScriptableObjects/ShootHandler/LaserShootgunShootHandler", order = 1)]
    public class LaserShootgunShootHandlerSO : ShootHandlerByType
    {
        [SerializeField] private float _timeToHot;
        [SerializeField] private float _coolTimeMultipler;
        [SerializeField] private float _cooldownMultiplate = 10;
        [SerializeField] private float _maxOffcet;
        [SerializeField] private float _offcetValue;
        protected override ShootHandler CreateShootHandler(GunModel gunModel)
        {
            LaserShootgunShootHandler shootHandler = CreateEmptyGameObject().AddComponent<LaserShootgunShootHandler>();
            shootHandler.SetOffcets(_maxOffcet, _offcetValue);
            shootHandler.SetSpecialInit(_cooldownMultiplate, _timeToHot, _coolTimeMultipler);
            LaserViewMediator laserViewMediator = new LaserViewMediator(shootHandler, gunModel.GetLaserSlider());
            return shootHandler;
        }
    }
}