using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Gun_Rewards : MonoBehaviour
{

    public RewardedAd rewardedAd;
    public string adUnitId;
    public bool isRewaredAvaiable = false;
    public GameObject Sure;
    public static Gun_Rewards instance;

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
            isRewaredAvaiable = false;
        

    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
        isRewaredAvaiable = true;
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

        Shop.Instance.GunData();
        if (ShopManager.instance.GunDataNo[StaticData.GunClickedNo - 1] <= 0)
        {
            ShopItem Obj = ShopManager.instance.Guns_Objects[StaticData.GunClickedNo - 1].GetComponent<ShopItem>();
            Obj.AdNoButton.SetActive(false);
            Obj.SelecteButton.SetActive(true);
            Obj.SelectedButton.SetActive(false);

        }
        ShopItem.instance.Button_Change();
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
        if (StaticData.GunClickedNo == 1)
        {
            return Shop.GunNo1;
        }
        else if (StaticData.GunClickedNo == 2)
        {
            return Shop.GunNo2;
        }
        else if (StaticData.GunClickedNo == 3)
        {
            return Shop.GunNo3;
        }
        else if (StaticData.GunClickedNo == 4)
        {
            return Shop.GunNo4;
        }
        else if (StaticData.GunClickedNo == 5)
        {
            return Shop.GunNo5;
        }
        else if (StaticData.GunClickedNo == 6)
        {
            return Shop.GunNo6;
        }
        else if (StaticData.GunClickedNo == 7)
        {
            return Shop.GunNo7;
        }
        else if (StaticData.GunClickedNo == 8)
        {
            return Shop.GunNo8;
        }
        else if (StaticData.GunClickedNo == 9)
        {
            return Shop.GunNo9;
        }
        else if (StaticData.GunClickedNo == 10)
        {
            return Shop.GunNo10;
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
        Debug.Log("Hello ");
        if (StaticData.GunClickedNo == 1)
        {
            Shop.GunNo1--;
        }
        else if (StaticData.GunClickedNo == 2)
        {
            Shop.GunNo2--;

        }
        else if (StaticData.GunClickedNo == 3)
        {
            Shop.GunNo3--;

        }
        else if (StaticData.GunClickedNo == 4)
        {
            Shop.GunNo4--;

        }
        else if (StaticData.GunClickedNo == 5)
        {
            Shop.GunNo5--;

        }
        else if (StaticData.GunClickedNo == 6)
        {
            Shop.GunNo6--;

        }
        else if (StaticData.GunClickedNo == 7)
        {
            Shop.GunNo7--;

        }
        else if (StaticData.GunClickedNo == 8)
        {
            Shop.GunNo8--;

        }
        else if (StaticData.GunClickedNo == 9)
        {
            Shop.GunNo9--;

        }
        else if (StaticData.GunClickedNo == 10)
        {
            Shop.GunNo10--;
        }
    }

    #endregion
}
