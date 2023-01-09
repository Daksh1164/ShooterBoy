using UnityEngine;
//using UnityEngine.iOS;        // TODO uncomment this while making build for ios device

public class RateAndShare : MonoBehaviour
{

    public void RateButton()
    {
        SoundManager.instance.ButtonClickSound();

#if UNITY_ANDROID
        Application.OpenURL("https://play.google.com/store/apps/details?id=" + Application.identifier);
#elif UNITY_IOS
        Device.RequestStoreReview();
#endif
    }



    public void ShareButton()
    {
        SoundManager.instance.ButtonClickSound();

        new NativeShare().SetSubject("Share It").SetText("Share app & support us  "+ "https://play.google.com/store/apps/details?id="+ Application.identifier).Share();    // Download & Import Native Share Package from Assets Store
    }


}   // Class End
