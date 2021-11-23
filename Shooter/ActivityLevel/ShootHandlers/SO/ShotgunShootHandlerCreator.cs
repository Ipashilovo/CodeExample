using UnityEngine;

namespace ActivityLevel.ShootHandlers.SO
{
    [CreateAssetMenu(fileName = "ShotgunShootHandlerCreator", menuName = "ScriptableObjects/ShootHandler/ShotgunShootHandlerCreator", order = 1)]
    public class ShotgunShootHandlerCreator : ShootHandlerByType
    {
        [SerializeField] private int _count;
        [SerializeField, Range(0f, 0.2f)] private float _rotate;
        protected override ShootHandler CreateShootHandler(GunModel gunModel)
        {
            ShootgunShootHandler shootHandler = CreateEmptyGameObject().AddComponent<ShootgunShootHandler>();
            shootHandler.SetCount(_count);
            shootHandler.SetRotate(_rotate);
            return shootHandler;
        }
    }
}