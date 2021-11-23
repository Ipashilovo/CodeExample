using System.Collections.Generic;
using UnityEngine;

public class InterstitialAds : MonoBehaviour
{
    private const string interstitialAdUnitId = "8c50966595a0b053";
    private int retryAttempt;
    private bool _sent;

    public bool IsReady => MaxSdk.IsInterstitialReady(interstitialAdUnitId);

    public void Initialize()
    {
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialFailedToDisplayEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialDismissedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        LoadInterstitial();
    }

    public void Show()
    {
        _sent = false;
        var parametrs = new Dictionary<string, object>
        {
            {"ad_type", "interstitial"},
            {"placement", "location_exit"},
            {"result", IsReady ? "success":"not_available"},
            {"connection", Application.internetReachability != NetworkReachability.NotReachable}
        };
        AppMetrica.Instance.ReportEvent("video_ads_available", parametrs);
        
        if(!IsReady || Application.internetReachability == NetworkReachability.NotReachable) return;
        
        var metrica = AppMetrica.Instance;
        var parametrs1 = new Dictionary<string, object>
        {
            {"ad_type", "interstitial"},
            {"placement", "location_exit"},
            {"result", "start"},
            {"connection", Application.internetReachability != NetworkReachability.NotReachable}
        };
        metrica.ReportEvent("video_ads_start", parametrs1);
        
        MaxSdk.ShowInterstitial(interstitialAdUnitId);
    }
    private void OnInterstitialLoadedEvent(string adUnitId ,MaxSdkBase.AdInfo adInfo)
    {
        retryAttempt = 0;
    }
    private void OnInterstitialFailedEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
        retryAttempt++;
        var retryDelay = Mathf.Pow(2, Mathf.Min(6, retryAttempt));
        Invoke(nameof(LoadInterstitial), retryDelay);
    }
    private void OnInterstitialFailedToDisplayEvent(string adUnitId, MaxSdkBase.ErrorInfo errorInfo , MaxSdkBase.AdInfo adInfo)
    {
        LoadInterstitial();
    }
    private void OnInterstitialDismissedEvent(string adUnitId ,MaxSdkBase.AdInfo adInfo)
    {
        var metrica = AppMetrica.Instance;
        var parametrs = new Dictionary<string, object>
        {
            {"ad_type", "interstitial"},
            {"placement", "location_exit"},
            {"result", "watched"},
            {"connection", Application.internetReachability != NetworkReachability.NotReachable}
        };
        if (!_sent)
        {
            _sent = true;
            metrica.ReportEvent("video_ads_watch", parametrs);
        }
        LoadInterstitial();
    }
    private void OnInterstitialClickedEvent(string adUnitId ,MaxSdkBase.AdInfo adInfo)
    {
        var metrica = AppMetrica.Instance;
        var parametrs = new Dictionary<string, object>
            {
            {"ad_type", "interstitial"},
            {"placement", "location_exit"},
            {"result", "clicked"},
            {"connection", Application.internetReachability != NetworkReachability.NotReachable}
            };
        if (!_sent)
        {
            _sent = true;
            metrica.ReportEvent("video_ads_watch", parametrs);
        }
    }
    private void OnInterstitialDisplayedEvent(string adUnitId , MaxSdkBase.AdInfo adInfo)
    {
        
    }
    
    private void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial(interstitialAdUnitId);
    }
}
