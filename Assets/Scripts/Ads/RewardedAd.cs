 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    string adID = "Rewarded_Android";
    [SerializeField] GameObject adButtonObj;
    Button adButton;
    [SerializeField] GameObject rewardEarnedText;
    //public GameObject countDown;
    //Text countdownText;

    void Awake()
    {
        adButton = adButtonObj.GetComponent<Button>();
        adButton.interactable = false;
        //countdownText = countDown.GetComponent<Text>();
    }

    void Start()
    {
        LoadAd();
        //countDown.SetActive(false);
    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad:" + adID);
        Advertisement.Load(adID, this);
    }
    public void ShowAd()
    {
        Debug.Log("Showing Ad:" + adID);
        Advertisement.Show(adID, this);
        adButton.interactable = false;
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + adID);

        if(placementId.Equals(adID))
        {
            adButton.interactable = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {

    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("You got +5 coins");
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 5);
            adButtonObj.SetActive(false);
            rewardEarnedText.SetActive(true);
            //gameOverPanel.SetActive(false);
            //StartCoroutine("CountDown");
        }
    }

    //IEnumerator CountDown()
    //{
    //    countDown.SetActive(true);
    //    Time.timeScale = 1;
    //    countdownText.text = "3";
    //    yield return new WaitForSeconds(1);
    //    countdownText.text = "2";
    //    yield return new WaitForSeconds(1);
    //    countdownText.text = "1";
    //    yield return new WaitForSeconds(1);
    //    countDown.SetActive(false);
    //    yield return new WaitForSeconds(0);
    //}

}