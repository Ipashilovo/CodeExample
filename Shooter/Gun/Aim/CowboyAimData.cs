using UnityEngine;

namespace Gun.Aim
{
    [CreateAssetMenu(fileName = "CowboyAimData", menuName = "ScriptableObjects/Aim/CowboyAimData", order = 1)]

    public class CowboyAimData : ScriptableObject
    {
        [SerializeField] private float _time;
        [SerializeField] private float _timeSacle;
        public float Time => _time;
        public float Scale => _timeSacle;
    }
}