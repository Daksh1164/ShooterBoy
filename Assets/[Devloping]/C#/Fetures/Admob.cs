using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using UnityEngine.UI;
using UnityEditor;

public class Admob : MonoBehaviour
{
	private BannerView adBanner;
	public InterstitialAd adInterstitial;

	public string idApp, idBanner, idInterstitial;
	public bool IsIdGot;

	public static Admob instance;

    private void Awake()
    {
		IsIdGot = false;
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}


	void Start ()
	{
		MobileAds.Initialize(initStatus => { });

		idInterstitial = "ca-app-pub-3940256099942544/1033173712";
	}

    #region Banner Methods --------------------------------------------------

    public void RequestBannerAd ()
	{
		/*if (FireBaseData.instance.IsAds)
		{
			adBanner = new BannerView(idBanner, AdSize.SmartBanner, AdPosition.Bottom);
			AdRequest request = AdRequestBuild();
			adBanner.LoadAd(request);
			Debug.Log("Banner Loaded");
		}*/
	}

	public void DestroyBannerAd ()
	{
       /* if (adBanner != null)
            adBanner.Destroy ();

		Debug.Log("Destroyed");*/
	}

	#endregion

	AdRequest AdRequestBuild ()
	{
		return new AdRequest.Builder ().Build ();
	}

	void OnDestroy ()
	{
		DestroyBannerAd ();
		//dettach event
	}

	public void BannerAd_Show()
    {
		//DestroyBannerAd();
		//RequestBannerAd();
    }

}
