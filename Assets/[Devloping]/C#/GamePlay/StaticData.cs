using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public static bool isOver;
    public static bool IsWin;
    public static int counter;
    public static int Firebase_Counter = 0;
    public static int lastloadedCount;
    public static int GameWin_AdCount;

    public static int GunClickedNo;
    public static int PlayerClickedNo;

    public static int AdShowCounter;



    public static StaticData instance;

    const string levelNo = "levelNo";
    const string curLevelNo = "curLevelNo";
    const string Amount = "WinAmount"; 
    const string IsFirst = "first";
    const string IsFirstLoad = "firstLoad";


    public static int LevelNo
    {
        get => PlayerPrefs.GetInt(levelNo);
        set => PlayerPrefs.SetInt(levelNo, value);
    }

    public static int CurLevelNo
    {
        get => PlayerPrefs.GetInt(curLevelNo);
        set => PlayerPrefs.SetInt(curLevelNo, value);
    }

    public static int WinAmount
    {
        get => PlayerPrefs.GetInt(Amount);
        set => PlayerPrefs.SetInt(Amount, value);
    }

    public static int FirstTime
    {
        get => PlayerPrefs.GetInt(IsFirst);
        set => PlayerPrefs.SetInt(IsFirst, value);
    }

    public static int FirstLoad
    {
        get => PlayerPrefs.GetInt(IsFirstLoad);
        set => PlayerPrefs.SetInt(IsFirstLoad, value);
    }

    private void Awake()
    {
        instance = this;
        counter = 0;
        GameWin_AdCount = 0;
        int.TryParse(FireBaseData.instance.Count, out Firebase_Counter);
        Debug.Log("FireBase : " + Firebase_Counter);
        AdShowCounter = 0;
        if (!PlayerPrefs.HasKey(IsFirstLoad))
        {
            FirstLoad = 0;
        }
    }


    private void Start()
    {
        if(FirstTime == 0)
        {
            FirstTime = 1;
            #region ForGun
            Shop.GunNo1 = 0;
            Shop.GunNo2 = 1;
            Shop.GunNo3 = 2;
            Shop.GunNo4 = 2;
            Shop.GunNo5 = 2;
            Shop.GunNo6 = 3;
            Shop.GunNo7 = 3;
            Shop.GunNo8 = 3;
            Shop.GunNo9 = 3;
            Shop.GunNo10 = 3;
            ShopManager.instance.GunDataNo[0] = Shop.GunNo1;
            ShopManager.instance.GunDataNo[1] = Shop.GunNo2;
            ShopManager.instance.GunDataNo[2] = Shop.GunNo3;
            ShopManager.instance.GunDataNo[3] = Shop.GunNo4;
            ShopManager.instance.GunDataNo[4] = Shop.GunNo5;
            ShopManager.instance.GunDataNo[5] = Shop.GunNo6;
            ShopManager.instance.GunDataNo[6] = Shop.GunNo7;
            ShopManager.instance.GunDataNo[7] = Shop.GunNo8;
            ShopManager.instance.GunDataNo[8] = Shop.GunNo9;
            ShopManager.instance.GunDataNo[9] = Shop.GunNo10;
            #endregion

            #region For Player

            Shop.PLayer_1 = 0;
            Shop.PLayer_2 = 1;
            Shop.PLayer_3 = 2;
            Shop.PLayer_4 = 3;
            Shop.PLayer_5 = 3;
            Shop.PLayer_6 = 3;
            ShopManager.instance.PlayerDataNo[0] = Shop.PLayer_1;
            ShopManager.instance.PlayerDataNo[1] = Shop.PLayer_2;
            ShopManager.instance.PlayerDataNo[2] = Shop.PLayer_3;
            ShopManager.instance.PlayerDataNo[3] = Shop.PLayer_4;
            ShopManager.instance.PlayerDataNo[4] = Shop.PLayer_5;
            ShopManager.instance.PlayerDataNo[5] = Shop.PLayer_6;
            #endregion
        }
        Shop.Instance.GunData();

    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey(IsFirstLoad);
    }


}
