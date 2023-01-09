using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using SimpleJSON;

public class FireBaseData : MonoBehaviour
{
    private string userID;
    public string Banner;
    public string Interstitial;
    public string Reward;
    public string AppId;
    public string Count;
    public string AppOpenID;
    public bool IsAds;

    public bool isSceneLoaded;
    public bool IsIdGet;
    public static FireBaseData instance;


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        IsIdGet = false;
        isSceneLoaded = false;
    }
    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
       /* GetBanner();
        GetInterStitial();
        GetCounter();
        GetRewared();
        GetIsAdsBool();
        GetAppOpen();*/
    }
    #region Commet Code
    /* public void GetBanner()
     {
         FirebaseDatabase.DefaultInstance
         .GetReference("Banner")

         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 // Handle the error...
             }
             else if (task.IsCompleted)
             {
               DataSnapshot snapshot = task.Result;
                 // Do something with snapshot...
                Banner = (string)snapshot.Value;
                 Admob.instance.idBanner = snapshot.Value.ToString();

             }
         });
     }


     public void GetInterStitial()
     {
         FirebaseDatabase.DefaultInstance
         .GetReference("Inter")

         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 // Handle the error...
             }
             else if (task.IsCompleted)
             {
                 DataSnapshot snapshot = task.Result;
                 // Do something with snapshot...
                 Interstitial = (string)snapshot.Value;
                 InterAd.instance.Interid = snapshot.Value.ToString();
                 InterAd.instance.RequestInterstitial();
             }
         });
     }

     public void GetRewared()
     {
         FirebaseDatabase.DefaultInstance
         .GetReference("Rewarded")

         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 // Handle the error...
             }
             else if (task.IsCompleted)
             {
                 DataSnapshot snapshot = task.Result;
                 // Do something with snapshot...
                 Reward = (string)snapshot.Value;

             }
         });
     }

     public void GetCounter()
     {
         FirebaseDatabase.DefaultInstance
         .GetReference("Counter")

         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 // Handle the error...
             }
             else if (task.IsCompleted)
             {
                 DataSnapshot snapshot = task.Result;
                 // Do something with snapshot...
                 Count = (string)snapshot.Value;
                 Debug.Log("Ad Counter : " + snapshot);


             }
         });
     }

     public void GetIsAdsBool()
     {
         FirebaseDatabase.DefaultInstance
         .GetReference("IsAds")

         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 // Handle the error...
             }
             else if (task.IsCompleted)
             {
                 DataSnapshot snapshot = task.Result;
                 // Do something with snapshot...
                 IsAds = (bool)snapshot.Value;
                 Debug.Log(IsAds + " and " + snapshot);

             }
         });
     }

     public void GetAppOpen()
     {
         FirebaseDatabase.DefaultInstance
         .GetReference("AppOpen")

         .GetValueAsync().ContinueWithOnMainThread(task => {
             if (task.IsFaulted)
             {
                 // Handle the error...
                 Debug.LogError("It's Error");

             }
             else if (task.IsCompleted)
             {
                 DataSnapshot snapshot = task.Result;
                 // Do something with snapshot...
                 AppOpenID = snapshot.Value.ToString() ;
                 AppOpenAdManager.AD_UNIT_ID = AppOpenID;
                 AppOpen.AD_UNIT_ID = AppOpenID;
                 if (LoadingBar.instance.isInterNet && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Splash")
                 {
                     //UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
                 }
                 else
                 {
                     LoadingBar.instance.Check();
                 }
                 AppOpenAdManager.Instance.LoadAd();
                 IsIdGet = true;
                 Debug.LogError(AppOpenAdManager.Instance.IsAdAvailable + "   and Scene Name : " +  UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

                 #region It's Code
                 /*
                 if (IsAds)
                 {
                     if (AppOpenAdManager.Instance.IsAdAvailable)
                     {
                         Debug.Log("Yeh it's Scene");
                         AppOpenAdManager.Instance.ShowAdIfAvailable();
                         //SceneManager.LoadScene("GamePlay");

                     }
                 }
                 else
                 {
                     if (!isSceneLoaded)
                     {
                         isSceneLoaded = true;
                         SceneManager.LoadScene("GamePlay");
                     }
                 }
             */

    /* #endregion
 }
 });
}*/
    #endregion
    public IEnumerator getAdsAID()
    {
        JSONObject data = new JSONObject();
        UnityWebRequest webRequest = UnityWebRequest.Post("https://adsapi.raghuveerinfotech.com/api/ads/shooterboy", data.ToString());

        yield return webRequest.SendWebRequest();

        if(webRequest.isHttpError || webRequest.isHttpError)
        {
            Debug.Log("Api Error : " + webRequest.error);
        }
        else
        {
            JSONNode Data = JSON.Parse(webRequest.downloadHandler.text);
            Debug.Log("Api Data : " +Data.ToString());
            Banner = Data["banner"].Value;
            Interstitial = Data["inter"].Value;
            Reward = Data["reward"].Value;
            AppOpenID = Data["appOpen"].Value;
            Count = Data["counter"].Value;
            IsAds = Data["isAds"].AsBool;
            IsIdGet = true; 

            LoadAds();

        }
    }

    public void LoadAds()
    {
        InterAd.instance.Interid = Interstitial;
        Admob.instance.idBanner = Banner;
        /*Shop_Reward.instance.adUnitId = Reward;
        Gun_Rewards.instance.adUnitId = Reward;
        RewaredAd.instance.adUnitId = Reward;*/
        AppOpen.AD_UNIT_ID = AppOpenID;
        AppOpenAdManager.AD_UNIT_ID = AppOpenID;

        /*RewaredAd.instance.requestrewared();
        Gun_Rewards.instance.CreateAndLoadRewardedAd();
        Shop_Reward.instance.CreateAndLoadRewardedAd();*/
       // InterAd.instance.RequestInterstitial();
        AppOpen.Instance.LoadAd();
        AppOpenAdManager.Instance.LoadAd();
    }


    /*private void Update()
    {
        if(IsIdGet)
        {
            AppOpenAdManager.Instance.LoadAd();
            IsIdGet = false;
            if (IsAds)
            {
                if (AppOpenAdManager.Instance.IsAdAvailable)
                {
                    Debug.Log("Yeh it's Scene");
                    SceneManager.LoadScene("GamePlay");
                    AppOpenAdManager.Instance.ShowAdIfAvailable();

                }
            }
            else
            {
                if (!isSceneLoaded)
                {
                    isSceneLoaded = true;
                    //SceneManager.LoadScene("GamePlay");
                }
            }
        }
    }*/


}
