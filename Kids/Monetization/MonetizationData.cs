using GameSystems;
using UnityEngine;

namespace Monetization
{
    public static class MonetizationData
    {
        public const string NoAdsProductID = "no_ads";
        public static bool isNoAdsBought
        {
            get => PlayerPrefs.GetInt("isNoAdsBought") == 1;
            private set => PlayerPrefs.SetInt("isNoAdsBought", value ? 1 : 0);
        }

        public static void SetNoAdsBought()
        {
            isNoAdsBought = true;
            UnlockLisener.Unlock();
            Debug.Log("No ads bought");
        }
    }
}
