using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    public List<Sprite> Guns;
    public List<Sprite> UpBoady;
    public List<Sprite> DownBody;

    public List<int> GunDataNo;
    public List<int> PlayerDataNo;


    public List<GameObject> Guns_Objects;
    public List<GameObject> Player_Objects;



    public static ShopManager instance;


    const string GunShop = "Gun";

    public static int GunNo
    {
        get => PlayerPrefs.GetInt(GunShop);
        set => PlayerPrefs.SetInt(GunShop, value);
    }

    const string PlayerShop = "Player";

    public static int PlayerNo
    {
        get => PlayerPrefs.GetInt(PlayerShop);
        set => PlayerPrefs.SetInt(PlayerShop, value);
    }

    private void Awake()
    {

        instance = this;
    }

    

}
