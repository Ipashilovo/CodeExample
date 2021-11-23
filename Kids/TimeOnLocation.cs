using GameSystems;
using UnityEngine;

public static class TimeOnLocation
{
        public static float Time
        {
                get => PlayerPrefs.GetFloat(PlayerPrefsName.TimeOnLocation, 0f);
                set => PlayerPrefs.SetFloat(PlayerPrefsName.TimeOnLocation, value);
        }
}