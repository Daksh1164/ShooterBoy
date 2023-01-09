using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;


public class RewaredAd : MonoBehaviour
{
    [HideInInspector]public RewardedAd rewardedAd;
    public string adUnitId;
    public GameObject Sure;

    public static RewaredAd instance;

    private void Awake()
    {
        instance = this;
        adUnitId = FireBaseData.instance.Reward;

    }

    public void Start()
    {
        this.rewardedAd = new RewardedAd(adUnitId);

    }

    public void requestrewared()
    {
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        RewaredReady();
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: ");
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        StartCoroutine(Bazooka.Boy.UIManager.instance.OffAd());
        Bazooka.Boy.UIManager.instance.Panels[11].SetActive(false);
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Bazooka.Boy.UIManager.instance.AddOneBullet();

    }

    public void UserChoseToWatchAd()
    {
        Bazooka.Boy.UIManager.instance.RewerdGive = Bazooka.Boy.UIManager.WhichRewerd.Bullet;
        GameObject MassagePanel = Bazooka.Boy.UIManager.instance.Panels[11];
        MassagePanel.GetComponent<AdPermission>().Massagt_Type.text = "Are  you saure you want to watch “30 Second video Ad” to Add 1 Bullet?";
        MassagePanel.SetActive(true);
        requestrewared();
    }

    public void RewaredReady()
    {
        GameObject MassagePanel = Bazooka.Boy.UIManager.instance.Panels[11];
        MassagePanel.GetComponent<AdPermission>().Loader_Object.SetActive(false);
        //MassagePanel.GetComponent<AdPermission>().Yes_button.SetActive(true);
        Sure.GetComponent<Image>().enabled = true;
        Sure.GetComponent<Button>().enabled = true;
        Sure.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
    }
    public void ShowAds()
    {
        Bazooka.Boy.UIManager.instance.AppOpenObject.SetActive(false);
        if (FireBaseData.instance.IsAds)
        {
            if (this.rewardedAd.IsLoaded())
            {
                Bazooka.Boy.UIManager.instance.FillCircle.fillAmount = 1;
                if (StaticData.AdShowCounter > 3)
                {

                }
                else
                {
                    this.rewardedAd.Show();
                }
                StaticData.AdShowCounter++;
            }
        }
    }
}
