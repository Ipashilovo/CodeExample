using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "MovePower", menuName = "ScriptableObjects/Move/MovePower", order = 1)]
    public class MovePower : ScriptableObject
    {
        [SerializeField] private float _power;
        [SerializeField] private float _time;
        public float Power => _power;
        public float Time => _time;
    }
}