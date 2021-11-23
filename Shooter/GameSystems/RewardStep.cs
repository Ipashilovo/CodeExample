using UnityEngine;

namespace GameSystems
{
    [CreateAssetMenu(fileName = "RewardStep", menuName = "ScriptableObjects/Reward/RewardStep", order = 1)]
    public class RewardStep : ScriptableObject
    {
        [SerializeField] private int[] _steps;

        public int GetCurrentStepValue(int value)
        {
            if (value >= _steps.Length)
            {
                value = _steps.Length - 1;
            }

            return _steps[value];
        }
    }
}