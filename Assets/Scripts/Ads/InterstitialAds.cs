using UnityEngine;
using UnityEngine.Advertisements;


public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    string adID = "Interstitial_Android";

    private void Awake()
    {
        LoadAd();
    }

    private void LoadAd()
    {
        Debug.Log("Loading ad: " + adID);
        Advertisement.Load(adID, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing ad: " + adID);
        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad loaded successfully: " + adID);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        LoadAd();
    }

}
