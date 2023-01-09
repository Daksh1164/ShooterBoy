using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Shop_Reward : MonoBehaviour
{
    public RewardedAd rewardedAd;
    public string adUnitId;
    public GameObject Sure;
    public static Shop_Reward instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        adUnitId = FireBaseData.instance.Reward;
    }

    public void RequestRewerd()
    {
        this.rewardedAd = new RewardedAd(adUnitId);

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

    public void RewaredReady()
    {
        GameObject MassagePanel = Bazooka.Boy.UIManager.instance.Panels[11];
        MassagePanel.GetComponent<AdPermission>().Loader_Object.SetActive(false);
        //MassagePanel.GetComponent<AdPermission>().Yes_button.SetActive(true);
        Sure.GetComponent<Image>().enabled = true;
        Sure.GetComponent<Button>().enabled = true;
        Sure.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
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
        Bazooka.Boy.UIManager.instance.Panels[11].SetActive(false);
        StartCoroutine(Bazooka.Boy.UIManager.instance.OffAd());
        
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Reward();
        //ShopItem.instance.Change_Text(StaticData.GunClickedNo);

        Shop.Instance.PlayerData();
        if (ShopManager.instance.PlayerDataNo[StaticData.PlayerClickedNo - 1] == 0)
        {
            ShopManager.instance.Player_Objects[StaticData.PlayerClickedNo - 1].GetComponent<PlayerShop>().AdNoButton.SetActive(false);
            ShopManager.instance.Player_Objects[StaticData.PlayerClickedNo - 1].GetComponent<PlayerShop>().SelecteButton.SetActive(true);
            ShopManager.instance.Player_Objects[StaticData.PlayerClickedNo - 1].GetComponent<PlayerShop>().SelectedButton.SetActive(false);

        }
        PlayerShop.instance.Button_Change();
    }

    public void UserChoseToWatchAd()
    {
        if (FireBaseData.instance.IsAds)
        {
            Bazooka.Boy.UIManager.instance.AppOpenObject.SetActive(false);
            if (this.rewardedAd.IsLoaded())
            {
                this.rewardedAd.Show();
            }
        }
    }


    #region PlayPref
    public int No()
    {
        if (StaticData.PlayerClickedNo == 1)
        {
            return Shop.PLayer_1;
        }
        else if (StaticData.PlayerClickedNo == 2)
        {
            return Shop.PLayer_2;
        }
        else if (StaticData.PlayerClickedNo == 3)
        {
            return Shop.PLayer_3;
        }
        else if (StaticData.PlayerClickedNo == 4)
        {
            return Shop.PLayer_4;
        }
        else if (StaticData.PlayerClickedNo == 5)
        {
            return Shop.PLayer_5;
        }
        else if (StaticData.PlayerClickedNo == 6)
        {
            return Shop.PLayer_6;
        }
        else
        {
            return 0;
        }
    }

    #endregion

    #region Reward Function
    public void Reward()
    {
        if (StaticData.PlayerClickedNo == 1)
        {
            Shop.PLayer_1--;
        }
        else if (StaticData.PlayerClickedNo == 2)
        {
            Shop.PLayer_2--;

        }
        else if (StaticData.PlayerClickedNo == 3)
        {
            Shop.PLayer_3--;

        }
        else if (StaticData.PlayerClickedNo == 4)
        {
            Shop.PLayer_4--;

        }
        else if (StaticData.PlayerClickedNo == 5)
        {
            Shop.PLayer_5--;

        }
        else if (StaticData.PlayerClickedNo == 6)
        {
            Shop.PLayer_6--;

        }
    }

    #endregion
}
