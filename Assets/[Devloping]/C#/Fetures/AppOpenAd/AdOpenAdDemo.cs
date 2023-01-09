using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdOpenAdDemo : MonoBehaviour
{
    // Start is called before the first frame update
    public static AdOpenAdDemo instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //AppOpenAdManager.Instance.LoadAd();
        
    }
    void Start()
    {
        //AppOpenAdManager.Instance.LoadAd();
    }

    // Update is called once per frame
   

    public void ShoeAppOpen()
    {
        if (FireBaseData.instance.IsAds)
        {
                AppOpenAdManager.Instance.ShowAdIfAvailable();
                StaticData.FirstLoad = 1;
            
        }
    }

    public void ChaneScene()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

}
