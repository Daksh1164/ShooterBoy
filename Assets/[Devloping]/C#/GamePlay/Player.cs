using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool IsLeftChanged;
    bool IsRightChanged;
    int Counter;


    [SerializeField] GameObject UpBody;
    [SerializeField] GameObject Gun;


    private void Start()
    {
        IsLeftChanged = false;
        IsRightChanged = true;

        Counter = 0;
        Gun.GetComponent<SpriteRenderer>().sprite = ShopManager.instance.Guns[ShopManager.GunNo];
        GetComponent<SpriteRenderer>().sprite = ShopManager.instance.DownBody[ShopManager.PlayerNo];
        UpBody.GetComponent<SpriteRenderer>().sprite = ShopManager.instance.UpBoady[ShopManager.PlayerNo];

    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(transform.localPosition.x > pos.x )
            {
                if (!IsLeftChanged)
                {
                    IsLeftChanged = true;
                    IsRightChanged = false;

                    if (UpBody.transform.rotation.z == 180)
                    {
                        UpBody.transform.Rotate(Vector3.zero);
                    }
                    else
                    {
                        UpBody.transform.Rotate(new Vector3(0, 0, -180));

                    }

                    UpBody.GetComponent<SpriteRenderer>().flipX = true;

                }
            }
            else
            {
                if(IsLeftChanged)
                {

                    IsLeftChanged = false;
                    IsRightChanged = true;

                    if(UpBody.transform.rotation.z == 180)
                    {
                        UpBody.transform.Rotate(Vector3.zero);
                    }
                    else
                    {
                        UpBody.transform.Rotate(new Vector3(0, 0, -180));

                    }

                    UpBody.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}
