using UnityEngine;

namespace ActivityLevel
{
    [CreateAssetMenu(fileName = "RotatePower", menuName = "ScriptableObjects/ActivityLevel/RotatePower")]

    public class RotatePower : ScriptableObject
    {
        [SerializeField] private float _power;
        public float Power => _power;
    }
}