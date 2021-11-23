using UnityEngine;

namespace LevelSystems
{
    [CreateAssetMenu(fileName = "ParallaxEffect", menuName = "ScriptableObjects/Level/ParallaxEffect", order = 1)]
    public class ParallaxEffect : ScriptableObject
    {
        [SerializeField] private float _effect;

        public float Effect => _effect;
    }
}