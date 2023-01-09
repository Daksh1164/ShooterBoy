using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] GameObject noInternetpanel;


    public bool isInterNet;

    public static LoadingBar instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        isInterNet = false;
        StartCoroutine(InterNetCheck());
        
    }

    

    IEnumerator InterNetCheck()
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            isInterNet = false;
            noInternetpanel.SetActive(true);
        }
        else
        {
            isInterNet = true;
            StartCoroutine(FireBaseData.instance.getAdsAID());
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        if(FireBaseData.instance.IsIdGet)
        {
            if (FireBaseData.instance.IsAds)
            {
                StartCoroutine(ShowAppOpen());
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
                Debug.LogError("Ad is Off");
            }

        }
        else
        {
            StartCoroutine(InterNetCheck());
        }

    }

    IEnumerator ShowAppOpen()
    {
        yield return new WaitForSeconds(4f);

        Debug.LogError("Is Ads Availble : " + AppOpenAdManager.Instance.IsAdAvailable);

        if(AppOpenAdManager.Instance.IsAdAvailable)
        {
            AdOpenAdDemo.instance.ShoeAppOpen();
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            Debug.LogError("Ad Not Avaible");
        }
        
    }

    public void TryAgainButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Splash");

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void Check()
    {
        StartCoroutine(InterNetCheck());
        StartCoroutine(ChangeScene());
    }

}
