using UnityEngine;

namespace DefaultNamespace.Stickman
{
    [CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/MoveSpeed", order = 1)]
    public class MoveSpeed : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}