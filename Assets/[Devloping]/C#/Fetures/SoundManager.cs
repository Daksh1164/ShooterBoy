using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [Header("Music")]
    public AudioSource Sound;
    private bool IsOn = false;
    public AudioClip ButtonClick;
    public AudioClip Win;
    public AudioClip Loss;
    //public AudioClip Crack;
    [SerializeField] Image On;
    [SerializeField] Image Off;

    [Header("Sound")]
    public AudioSource BGSource;
    [SerializeField] Image SoundOn;
    [SerializeField] Image SoundOff;
    private bool IsSoundOn = false;

    public static SoundManager instance;


    private void Awake() { instance = this; }
    
    void Start()
    {
        
        //if (!PlayerPrefs.HasKey("mute"))
        //{
        //   PlayerPrefs.SetInt("mute",0);
        //    Load();
        //}
        //else
        //{
        //    Load();
        //}

        //if (!PlayerPrefs.HasKey("soundmute"))
        //{
        //    PlayerPrefs.SetInt("soundmute", 0);
        //    Load();
        //}
        //else
        //{
        //    Load();
        //}


        //ChangrIcon();
        //ChangrSoundIcon();
        //Sound.mute = IsOn;
        //BGSource.mute = IsSoundOn;
    }

    public void ButtonClickSound()
    {
        Sound.PlayOneShot(ButtonClick);
        if(!BGSource.isPlaying)
        {
            BGSource.Play();
        }
    }

    #region Music
    public void OnButtobPress()
    {
        ButtonClickSound();
        if(IsOn == false)
        {
            IsOn = true;
            Sound.mute = true;
        }
        else
        {
            IsOn = false;
            Sound.mute = false;
        }
        Save();
        ChangrIcon();
    }


    private void ChangrIcon()
    {
        if (IsOn == false)
        {
            On.enabled = true;
            Off.enabled = false;
        }
        else
        {
            SoundOn.enabled = false;
            Off.enabled = true;
        }
    }

    #endregion

    #region Sound

    public void OnSoundButtobPress()
    {
        ButtonClickSound();
        if (IsSoundOn == false)
        {
            IsSoundOn = true;
            BGSource.mute = true;
        }
        else
        {
            IsSoundOn = false;
            BGSource.mute = false;
        }
        Save();
        ChangrSoundIcon();
    }

    private void ChangrSoundIcon()
    {
        if (IsSoundOn == false)
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
        }
        else
        {
            On.enabled = false;
            SoundOff.enabled = true;
        }
    }
    #endregion
    private void Load()
    {
        IsOn = PlayerPrefs.GetInt("mute") == 1;
        IsSoundOn = PlayerPrefs.GetInt("soundmute") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("mute", IsOn ? 1 : 0 ) ;
        PlayerPrefs.SetInt("soundmute", IsSoundOn ? 1 : 0);
    }
}
