    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    int AdsCount;
    public GameObject SelectedButton;
    public GameObject SelecteButton;
    public GameObject AdNoButton;
    public TMPro.TextMeshProUGUI AdNo;
    public int TotalAdToShow;
    public bool IsPurchased = false;

    public static ShopItem instance;

    private void Awake()
    {
        instance = this;
        InvokeRepeating("Button_Change", 1,1);
    }


    private void Start()
    {
        Shop.Instance.GunData();
        Button_Change();
    }

    public void Button_Change()
    {
        for (int i = 0; i < 10 ; i++)
        {
            if (i == ShopManager.GunNo)
            {
                ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().SelectedButton.SetActive(true);
                ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().SelecteButton.SetActive(false);
                ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().AdNoButton.SetActive(false);

            }
            else
            {
                if(ShopManager.instance.GunDataNo[i] == 0)
                {
                    ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().SelectedButton.SetActive(false);
                    ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().SelecteButton.SetActive(true);
                    ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().AdNoButton.SetActive(false);
                }
                else
                {
                    ShopItem OBJ = ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>();

                    OBJ.SelectedButton.SetActive(false);
                    OBJ.SelecteButton.SetActive(false);
                    OBJ.AdNoButton.SetActive(true);

                    int NoToShow = 0;
                    NoToShow = OBJ.TotalAdToShow - ShopManager.instance.GunDataNo[i];

                    ShopManager.instance.Guns_Objects[i].GetComponent<ShopItem>().AdNo.text = NoToShow.ToString();

                }
            }
        }
    }

    public void OnClick_Select()
    {
        IsPurchased = true;
    }

    public void WatchAd()
    {
        Bazooka.Boy.UIManager.instance.ObjectName = gameObject.name;
        Bazooka.Boy.UIManager.instance.RewerdGive = Bazooka.Boy.UIManager.WhichRewerd.Gun;

        if (!IsPurchased)
        {
            GameObject MassagePanel = Bazooka.Boy.UIManager.instance.Panels[11];
            MassagePanel.GetComponent<AdPermission>().Massagt_Type.text = "Are  you saure you want to watch “30 Second video Ad” to get this Gun Skin?";
            MassagePanel.SetActive(true);
            Gun_Rewards.instance.RequestRewerd();
            
        }
        else
            ShowAds();
    }

  


    public void ShowAds()
    {
        gameObject.name = Bazooka.Boy.UIManager.instance.ObjectName;
        if (gameObject.name == "1")
            {
                if(Shop.GunNo1 > 0)
                {
                    StaticData.GunClickedNo = 1;
                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo1 == 0)
                {
                    ShopManager.GunNo = 0;
                    
                }
            }
            else if (gameObject.name == "2")
            {
                if(Shop.GunNo2 > 0)
                {
                    StaticData.GunClickedNo = 2;
                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo2 == 0)
                {
                    ShopManager.GunNo = 1;
                }

            }
            else if (gameObject.name == "3")
            {
                if (Shop.GunNo3 > 0)
                {

                    StaticData.GunClickedNo = 3;

                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if (Shop.GunNo3 == 0)
                {
                    ShopManager.GunNo = 2;

                }

            }
            else if (gameObject.name == "4")
            {
                if (Shop.GunNo4 > 0)
                {
                    StaticData.GunClickedNo = 4;

                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if (Shop.GunNo4 == 0)
                {
                    ShopManager.GunNo = 3;

                }

            }
            else if (gameObject.name == "5")
            {
                if(Shop.GunNo5 > 0)
                {
                    StaticData.GunClickedNo = 5;

                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo5 == 0)
                {
                    ShopManager.GunNo = 4;
                    
                }

            }
            else if (gameObject.name == "6")
            {
                if(Shop.GunNo6 > 0)
                {
                    StaticData.GunClickedNo = 6;

                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo6 == 0)
                {
                    ShopManager.GunNo = 5;
                    
                 }

            }
            else if (gameObject.name == "7")
            {
                if(Shop.GunNo7 > 0)
                {
                    StaticData.GunClickedNo = 7;

                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo7 == 0)
                {
                    ShopManager.GunNo = 6;
                    
                }

            }
            else if (gameObject.name == "8")
            {
                if(Shop.GunNo8 > 0)
                {
                    StaticData.GunClickedNo = 8;
                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo8 == 0)
                {
                    ShopManager.GunNo = 7;
                    
                }

            }
            else if (gameObject.name == "9")
            {
                if(Shop.GunNo9 > 0)
                {
                    StaticData.GunClickedNo = 9;
                    if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                    {
                        Gun_Rewards.instance.UserChoseToWatchAd();
                    }
                }
                else if(Shop.GunNo9 == 0)
                {
                    ShopManager.GunNo = 8;
                    
                }

            }
            else if (gameObject.name == "10")
            {
                if (Shop.GunNo10 > 0)
                {
                    StaticData.GunClickedNo = 10;
                if (Gun_Rewards.instance.rewardedAd.IsLoaded())
                {
                    Gun_Rewards.instance.UserChoseToWatchAd();
                }

            }
                else if (Shop.GunNo10 == 0)
                { 
                    ShopManager.GunNo = 9;
                     
                }
            }
            Shop.Instance.GunData();
        Button_Change();
    }

}

