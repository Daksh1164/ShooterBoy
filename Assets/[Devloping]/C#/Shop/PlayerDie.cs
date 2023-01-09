using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public List<Sprite> Head;
    public List<Sprite> stomach;
    public List<Sprite> Gun;
    public List<Sprite> RightLeg;
    public List<Sprite> LeftLeg;
    [Space(10)]
    public GameObject Head1;
    public GameObject stomach1;
    public GameObject Gun1;
    public GameObject RightLeg1;
    public GameObject LeftLeg1;


    private void Start()
    {
        Head1.GetComponent<SpriteRenderer>().sprite = Head[ShopManager.PlayerNo];
        stomach1.GetComponent<SpriteRenderer>().sprite = stomach[ShopManager.PlayerNo];
        Gun1.GetComponent<SpriteRenderer>().sprite = Gun[ShopManager.GunNo];
        RightLeg1.GetComponent<SpriteRenderer>().sprite = RightLeg[ShopManager.PlayerNo];
        LeftLeg1.GetComponent<SpriteRenderer>().sprite = LeftLeg[ShopManager.PlayerNo];

    }

}
