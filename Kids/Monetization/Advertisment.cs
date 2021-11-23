using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monetization
{
    public class Advertisment : MonoBehaviour
    {
        private const string SDK_KEY =
            "f-X7uBGAWuV50xDSn7aPtqhJmI5R8IQGfnTZ3meTFl9c2fCMMKrTdGE8Umyop_9ImHNA1E9Dad4dtRxEgMb3KB";
        [SerializeField] private InterstitialAds _interstitialAd;
        public RewardedAds RewardedAd;

        public bool IsInterstitialReady => _interstitialAd.IsReady;
        public bool IsRewardedReady => RewardedAd.IsReady;

        public static Advertisment Instance
        {
            get;
            private set;
        }

        private void Awake()
        {
            MaxSdkCallbacks.OnSdkInitializedEvent += OnInitialized;
        }

        private void OnDestroy()
        {
            MaxSdkCallbacks.OnSdkInitializedEvent -= OnInitialized;
        }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                
                MaxSdk.SetSdkKey(SDK_KEY);
                MaxSdk.InitializeSdk();
            }
            else
            {
                if (Instance != this)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void OnInitialized(MaxSdkBase.SdkConfiguration sdkConfiguration)
        {
            MaxSdk.SetIsAgeRestrictedUser(true);
            _interstitialAd.Initialize();
            //RewardedAd.Initialize();
            
            switch (sdkConfiguration.ConsentDialogState)
            {
                case MaxSdkBase.ConsentDialogState.Applies:
                    break;
                case MaxSdkBase.ConsentDialogState.DoesNotApply:
                    SceneManager.LoadScene("City");
                    break;
                default:
                    Debug.LogError("Consent dialog state is unknown. " +
                                   "Proceed with initialization, but check if the consent dialog " +
                                   "should be shown on the next application initialization");
                    break;
            }
        }

        public void ShowRewarded(IRewardable rewardable)
        {
            try
            {
                RewardedAd.Show(rewardable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        
        }

        public void ShowInterstitial()
        {
            try
            {
                _interstitialAd.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
