using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShop : MonoBehaviour
{
    int AdsCount;
    public GameObject SelectedButton;
    public GameObject SelecteButton;
    public GameObject AdNoButton;
    public TMPro.TextMeshProUGUI AdNo;
    public int TotalAdToShow;
    public bool IsPurchased = false;

    public static PlayerShop instance;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        Shop.Instance.PlayerData();
        Button_Change();
    }

    public void Button_Change()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i == ShopManager.PlayerNo)
            {
                ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().SelectedButton.SetActive(true);
                ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().SelecteButton.SetActive(false);
                ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().AdNoButton.SetActive(false);

            }
            else
            {
                if (ShopManager.instance.PlayerDataNo[i] == 0)
                {
                    ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().SelectedButton.SetActive(false);
                    ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().SelecteButton.SetActive(true);
                    ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().AdNoButton.SetActive(false);
                }
                else
                {
                    PlayerShop OBJ = ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>();
                    OBJ.SelectedButton.SetActive(false);
                    OBJ.SelecteButton.SetActive(false);
                    OBJ.AdNoButton.SetActive(true);

                    int NoToShow = 0;
                    NoToShow =   OBJ.TotalAdToShow - ShopManager.instance.PlayerDataNo[i];


                    ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().AdNo.text = NoToShow.ToString();
                   // ShopManager.instance.Player_Objects[i].GetComponent<PlayerShop>().AdNo.text = ShopManager.instance.PlayerDataNo[i].ToString();

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
        Bazooka.Boy.UIManager.instance.RewerdGive = Bazooka.Boy.UIManager.WhichRewerd.Player;

        if (!IsPurchased)
        {
            GameObject MassagePanel = Bazooka.Boy.UIManager.instance.Panels[11];
            MassagePanel.GetComponent<AdPermission>().Massagt_Type.text = "Are  you saure you want to watch “30 Second video Ad” to get this Charatcer?";
            MassagePanel.SetActive(true);
            Shop_Reward.instance.RequestRewerd();
        }
        else
            ShownAds();
    }

    public void ShownAds()
    {
        gameObject.name = Bazooka.Boy.UIManager.instance.ObjectName;

        if (gameObject.name == "1")
        {
            if (Shop.PLayer_1 > 0)
            {
                StaticData.PlayerClickedNo = 1;
                if (Shop_Reward.instance.rewardedAd.IsLoaded())
                {
                    Shop_Reward.instance.UserChoseToWatchAd();
                }
            }
            else if (Shop.PLayer_1 == 0)
            {
                ShopManager.PlayerNo = 0;

            }
        }
        else if (gameObject.name == "2")
        {
            if (Shop.PLayer_2 > 0)
            {
                StaticData.PlayerClickedNo = 2;
                if (Shop_Reward.instance.rewardedAd.IsLoaded())
                {
                    Shop_Reward.instance.UserChoseToWatchAd();
                }
            }
            else if (Shop.PLayer_2 == 0)
            {
                ShopManager.PlayerNo = 1;

            }

        }
        else if (gameObject.name == "3")
        {
            if (Shop.PLayer_3 > 0)
            {

                StaticData.PlayerClickedNo = 3;

                if (Shop_Reward.instance.rewardedAd.IsLoaded())
                {
                    Shop_Reward.instance.UserChoseToWatchAd();
                }
            }
            else if (Shop.PLayer_3 == 0)
            {
                ShopManager.PlayerNo = 2;

            }

        }
        else if (gameObject.name == "4")
        {
            if (Shop.PLayer_4 > 0)
            {
                StaticData.PlayerClickedNo = 4;

                if (Shop_Reward.instance.rewardedAd.IsLoaded())
                {
                    Shop_Reward.instance.UserChoseToWatchAd();
                }
            }
            else if (Shop.PLayer_4 == 0)
            {
                ShopManager.PlayerNo = 3;

            }

        }
        else if (gameObject.name == "5")
        {
            if (Shop.PLayer_5 > 0)
            {
                StaticData.PlayerClickedNo = 5;

                if (Shop_Reward.instance.rewardedAd.IsLoaded())
                {
                    Shop_Reward.instance.UserChoseToWatchAd();
                }
            }
            else if (Shop.PLayer_5 == 0)
            {
                ShopManager.PlayerNo = 4;

            }

        }
        else if (gameObject.name == "6")
        {
            if (Shop.PLayer_6 > 0)
            {
                StaticData.PlayerClickedNo = 6;

                if (Shop_Reward.instance.rewardedAd.IsLoaded())
                {
                    Shop_Reward.instance.UserChoseToWatchAd();
                }
            }
            else if (Shop.PLayer_6 == 0)
            {
                ShopManager.PlayerNo = 5;

            }

        }
        Shop.Instance.PlayerData();
        Button_Change();
    }
}
