using UnityEngine;

namespace InitScene
{
    [CreateAssetMenu(fileName = "FirstSceneName", menuName = "ScriptableObjects/City/FirstSceneName", order = 1)]

    public class FirstSceneName : ScriptableObject
    {
        public string Name;
    }
}