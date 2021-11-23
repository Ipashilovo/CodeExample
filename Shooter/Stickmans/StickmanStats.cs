using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Stickman
{
    public class StickmanStats
    {
        public readonly float ChanceToPlayAnimation; 
        public float Health;
        public readonly float ColdMaxValue;
        public readonly float ColdStep;
        public readonly float RateOfFire;
        public readonly int Damage;


        public StickmanStats(float chanceToPlayAnimation, float health, float coldStep, float coldMaxValue, float rateOfFire, int damage)
        {
            Health = health;
            ColdStep = coldStep;
            ColdMaxValue = coldMaxValue;
            RateOfFire = rateOfFire;
            Damage = damage;
            ChanceToPlayAnimation = chanceToPlayAnimation;
        }
    }
}