using UnityEngine;

namespace Analytics
{
    public static class GlobalData
    {
        public static int LevelCount
        {
            get => PlayerPrefs.GetInt("LevelCount",1);
            private set => PlayerPrefs.SetInt("LevelCount", value);
        }

        public static void IncreaseLevelCount()
        {
            LevelCount++;
        }

        public static bool IsGDPRAccepted()
        {
            return PlayerPrefs.GetInt("IsGDPRAccepted") == 1;
        }

        public static void AcceptGDPR()
        {
            PlayerPrefs.SetInt("IsGDPRAccepted",1);
            MaxSdk.SetHasUserConsent(true);
        }

    }
}
