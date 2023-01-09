using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class InterAd : MonoBehaviour
{

    public InterstitialAd interstitial;
    public string Interid;
    public bool IsLoaded;

    public static InterAd instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //RequestInterstitial();
        IsLoaded = false;
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            interstitial.Show();
        }
    }


    public void RequestInterstitial()
    {


        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interid);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        IsLoaded = true;
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: ");
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpening event received");
        IsLoaded = false;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
       // RequestInterstitial();
        StartCoroutine(Bazooka.Boy.UIManager.instance.OffAd());
        Bazooka.Boy.UIManager.instance.Panels[10].SetActive(false);
        //StartCoroutine(Bazooka.Boy.UIManager.instance.ButtonCode(Bazooka.Boy.UIManager.instance.CurBtn)) ;

    }

    public void ShowInter()
    {
        //if (Bazooka.Boy.GameManager.Instance.isInterShow)
        //{
            interstitial.Show();
        //}
    }
}
