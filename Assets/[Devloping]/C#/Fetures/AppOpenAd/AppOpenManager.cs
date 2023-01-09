using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppOpenManager : MonoBehaviour
{
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if((FireBaseData.instance.IsAds))
            {
                AppOpen.Instance.ShowAdIfAvailable();
            }
        }
    }
}
    