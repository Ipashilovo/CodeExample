using UnityEngine;

namespace Move
{
    [CreateAssetMenu(fileName = "MoveSpeed", menuName = "ScriptableObjects/Move/MoveSpeed", order = 1)]
    public class MoveSpeed : ScriptableObject
    {
        [SerializeField, Min(0f)] private float _speed;

        public float Speed => _speed;
    }
}