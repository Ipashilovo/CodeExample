using UnityEngine;

namespace Gun
{
    [CreateAssetMenu(fileName = "ShootCooldown", menuName = "ScriptableObjects/GunData/ShootCooldown", order = 1)]
    public class ShootCooldown : ScriptableObject
    {
        [SerializeField] private float _cooldown;

        public float Cooldown => _cooldown;
    }
}