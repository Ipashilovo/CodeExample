using UnityEngine;

namespace City
{
    [CreateAssetMenu(fileName = "StartAnimationState", menuName = "ScriptableObjects/City/StartAnimationState", order = 1)]
    public class StartAnimationState : ScriptableObject
    {
        public bool IsPlayed
        {
            get => PlayerPrefs.GetInt(nameof(IsPlayed)) == 1;
            set => PlayerPrefs.SetInt(nameof(IsPlayed), value ? 1 : 0);
        }

    }
}