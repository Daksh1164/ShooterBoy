using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public static Shop Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GunData();
        PlayerData();
    }

    #region GunShop

    const string Gun1 = "Gun1";

    public static int GunNo1
    {
        get => PlayerPrefs.GetInt(Gun1);
        set => PlayerPrefs.SetInt(Gun1, value);
    }

    const string Gun2 = "Gun2";

    public static int GunNo2
    {
        get => PlayerPrefs.GetInt(Gun2);
        set => PlayerPrefs.SetInt(Gun2, value);
    }

    const string Gun3 = "Gun3";

    public static int GunNo3
    {
        get => PlayerPrefs.GetInt(Gun3);
        set => PlayerPrefs.SetInt(Gun3, value);
    }

    const string Gun4 = "Gun4";

    public static int GunNo4
    {
        get => PlayerPrefs.GetInt(Gun4);
        set => PlayerPrefs.SetInt(Gun4, value);
    }

    const string Gun5 = "Gun5";

    public static int GunNo5
    {
        get => PlayerPrefs.GetInt(Gun5);
        set => PlayerPrefs.SetInt(Gun5, value);
    }

    const string Gun6 = "Gun6";

    public static int GunNo6
    {
        get => PlayerPrefs.GetInt(Gun6);
        set => PlayerPrefs.SetInt(Gun6, value);
    }

    const string Gun7 = "Gun7";

    public static int GunNo7
    {
        get => PlayerPrefs.GetInt(Gun7);
        set => PlayerPrefs.SetInt(Gun7, value);
    }

    const string Gun8 = "Gun8";

    public static int GunNo8
    {
        get => PlayerPrefs.GetInt(Gun8);
        set => PlayerPrefs.SetInt(Gun8, value);
    }

    const string Gun9 = "Gun9";

    public static int GunNo9
    {
        get => PlayerPrefs.GetInt(Gun9);
        set => PlayerPrefs.SetInt(Gun9, value);
    }

    const string Gun10 = "Gun10";

    public static int GunNo10
    {
        get => PlayerPrefs.GetInt(Gun10);
        set => PlayerPrefs.SetInt(Gun10, value);
    }

    
    public void GunData()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo1;
                }
                else if (i == 1)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo2;

                }
                else if (i == 2)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo3;

                }
                else if (i == 3)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo4;

                }
                else if (i == 4)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo5;

                }
                else if (i == 5)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo6;

                }
                else if (i == 6)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo7;

                }
                else if (i == 7)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo8;

                }
                else if (i == 8)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo9;

                }
                else if (i == 9)
                {
                    ShopManager.instance.GunDataNo[i] = Shop.GunNo10;
                }
            }
        }
    #endregion

    #region PlayerGun

    const string Player1 = "player1";

    public static int PLayer_1
    {
        get => PlayerPrefs.GetInt(Player1);
        set => PlayerPrefs.SetInt(Player1, value);
    }

    const string Player2 = "player2";

    public static int PLayer_2
    {
        get => PlayerPrefs.GetInt(Player2);
        set => PlayerPrefs.SetInt(Player2, value);
    }

    const string Player3 = "player3";

    public static int PLayer_3
    {
        get => PlayerPrefs.GetInt(Player3);
        set => PlayerPrefs.SetInt(Player3, value);
    }

    const string Player4 = "player4";

    public static int PLayer_4
    {
        get => PlayerPrefs.GetInt(Player4);
        set => PlayerPrefs.SetInt(Player4, value);
    }

    const string Player5 = "player5";

    public static int PLayer_5
    {
        get => PlayerPrefs.GetInt(Player5);
        set => PlayerPrefs.SetInt(Player5, value);
    }

    const string Player6 = "player6";

    public static int PLayer_6
    {
        get => PlayerPrefs.GetInt(Player6);
        set => PlayerPrefs.SetInt(Player6, value);
    }


    public void PlayerData()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                ShopManager.instance.PlayerDataNo[i] = Shop.PLayer_1;
            }
            else if (i == 1)
            {
                ShopManager.instance.PlayerDataNo[i] = Shop.PLayer_2;

            }
            else if (i == 2)
            {
                ShopManager.instance.PlayerDataNo[i] = Shop.PLayer_3;

            }
            else if (i == 3)
            {
                ShopManager.instance.PlayerDataNo[i] = Shop.PLayer_4;

            }
            else if (i == 4)
            {
                ShopManager.instance.PlayerDataNo[i] = Shop.PLayer_5;

            }
            else if (i == 5)
            {
                ShopManager.instance.PlayerDataNo[i] = Shop.PLayer_6;

            }

        }

        
    }
    #endregion
}

