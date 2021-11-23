using UnityEngine;

namespace ActivityLevel.Reward
{
    [CreateAssetMenu(fileName = "MoneyReward", menuName = "ScriptableObjects/Reward/MoneyReward", order = 1)]
    public class MoneyReward : ScriptableObject
    {
        [SerializeField] private int _money;
        public int Money => _money;
    }
}