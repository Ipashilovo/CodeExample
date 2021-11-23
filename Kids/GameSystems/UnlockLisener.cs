using System;
using UnityEngine;

namespace GameSystems
{
    public class UnlockLisener : MonoBehaviour
    {
        private bool _unlockState;
        public static event Action Unlocked;

        private static UnlockLisener _unlockLisener;
        
        private void Awake()
        {
            _unlockLisener = this;
            _unlockState = PlayerPrefs.GetInt(PlayerPrefsName.UnlockState) == 1;
            DontDestroyOnLoad(gameObject);
        }

        public static bool CheckUnlock()
        {
            return _unlockLisener._unlockState;
        }

        public static void Unlock()
        {
            _unlockLisener._unlockState = true;
            PlayerPrefs.SetInt(PlayerPrefsName.UnlockState, 1);
            Unlocked?.Invoke();
        }
    }
}