using UnityEngine;

namespace BulletData.View
{
    [CreateAssetMenu(fileName = "ParticleByBulletType", menuName = "ScriptableObjects/Bullet/ParticleByBulletType", order = 1)]
    public class ParticleByBulletType : ScriptableObject
    {
        [SerializeField] private BulletType _bulletType;
        [SerializeField] private ParticleByElementalType[] _particleByElementalTypes;

        public BulletType Type => _bulletType;
    }
}