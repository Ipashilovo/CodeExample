using UnityEngine;

namespace Gun
{
    [CreateAssetMenu(fileName = "DamageMultiplicate", menuName = "ScriptableObjects/GunData/DamageMultiplicate", order = 1)]

    public class DamageMultiplicate : ScriptableObject
    {
        [SerializeField] private float _multiplicate;

        public float Multiplicate => _multiplicate;
    }
}