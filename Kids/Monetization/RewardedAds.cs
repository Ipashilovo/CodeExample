using System.Collections.Generic;
using UnityEngine;

namespace Monetization
{
    public class RewardedAds : MonoBehaviour
    {
        private const string rewardedAdUnitId = "";
        private int retryAttempt;
        private bool isClicked = true;
        private bool isWatched = true;
        private bool isCanceled = true;
        private IRewardable currentRewardable;

        private Dictionary<string, object> AdsAvailable;
        private Dictionary<string, object> AdsStarted;
        private Dictionary<string, object> AdsClicked;
        private Dictionary<string, object> AdsCanceled;
        private Dictionary<string, object> AdsWatched;

        private bool TriggeredOnce { get; set; } = true;
        public bool IsReady => MaxSdk.IsRewardedAdReady(rewardedAdUnitId);

        public void SetAnalyticsData(
            Dictionary<string, object> adsAvailable, 
            Dictionary<string, object> adsStarted,
            Dictionary<string, object> adsClicked,
            Dictionary<string, object> adsCanceled,
            Dictionary<string, object> adsWatched
        )
        {
            AdsAvailable = adsAvailable;
            AdsStarted = adsStarted;
            AdsClicked = adsClicked;
            AdsCanceled = adsCanceled;
            AdsWatched = adsWatched;
        }

        public void Initialize()
        {
            MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedAdLoadedEvent;
            MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedAdFailedEvent;
            MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedAdFailedToDisplayEvent;
            MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedAdDisplayedEvent;
            MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedAdClickedEvent;
            MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedAdDismissedEvent;
            MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedAdReceivedRewardEvent;
            LoadRewardedAd();
        }

        public void Show(IRewardable rewardable)
        {
            currentRewardable = rewardable;
        
            var metrica = AppMetrica.Instance;
            if (AdsAvailable != null)
            {
                metrica.ReportEvent("video_ads_available", AdsAvailable);
            }
            if(!MaxSdk.IsRewardedAdReady(rewardedAdUnitId) || Application.internetReachability == NetworkReachability.NotReachable) return;

            if(AdsStarted != null)
                metrica.ReportEvent("video_ads_started", AdsStarted);
        
            isClicked = false;
            isWatched = false;
            isCanceled = false;
            TriggeredOnce = false;
            MaxSdk.ShowRewardedAd(rewardedAdUnitId);
        }
    
        private void LoadRewardedAd()
        {
            MaxSdk.LoadRewardedAd(rewardedAdUnitId);
        }
        private void OnRewardedAdLoadedEvent(string adUnitId,MaxSdkBase.AdInfo adInfo)
        {
            retryAttempt = 0;
        }
        private void OnRewardedAdFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
        {
            retryAttempt++;
            double retryDelay = Mathf.Pow(2, Mathf.Min(6, retryAttempt));
            Invoke(nameof(LoadRewardedAd), (float)retryDelay);
        }
        private void OnRewardedAdFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
        {
            LoadRewardedAd();
        }
        private void OnRewardedAdDisplayedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {

        }
        private void OnRewardedAdClickedEvent(string adUnitId ,MaxSdkBase.AdInfo adInfo) 
        {
            var metrica = AppMetrica.Instance;
            if (!isWatched && !isClicked)
            {
                metrica.ReportEvent("video_ads_watch", AdsClicked);
            }
            isClicked = true;
        }

        private void OnRewardedAdDismissedEvent(string adUnitId, MaxSdkBase.AdInfo adInfo)
        {
            if (!TriggeredOnce)
            {
                currentRewardable.DismissReward();
                var metrica = AppMetrica.Instance;
                if (!isWatched && !isCanceled)
                {
                    metrica.ReportEvent("video_ads_watch", AdsCanceled);
                }
                isCanceled = true;
            }
            LoadRewardedAd();
        }

        private void OnRewardedAdReceivedRewardEvent(string adUnitId, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo adInfo)
        {
            if (TriggeredOnce) return;
        
            currentRewardable.GrantReward();
            var metrica = AppMetrica.Instance;
            if (!isClicked)
            {
                metrica.ReportEvent("video_ads_watch", AdsWatched);
            }
            isWatched = true;
            TriggeredOnce = true;

        }
    }
}
