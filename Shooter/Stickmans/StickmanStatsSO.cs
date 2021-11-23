using UnityEngine;

namespace DefaultNamespace.Stickman
{
    [CreateAssetMenu(fileName = "StickmanStats", menuName = "ScriptableObjects/Stickman/StickmanStats", order = 1)]
    public class StickmanStatsSO : ScriptableObject
    {
        [SerializeField] private float _health;
        [SerializeField] private float _chanceToPlayAnimation;
        [SerializeField] private float _coldMaxValue;
        [SerializeField] private float _coldStep;
        [SerializeField] private float _rateOfFire;
        [SerializeField] private int _damage;

        public StickmanStats GetStats()
        {
            var stats = new StickmanStats(_chanceToPlayAnimation, _health, _coldStep, _coldMaxValue, _rateOfFire, _damage); 
            return stats;
        }
    }
}