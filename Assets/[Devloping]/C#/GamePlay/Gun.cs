using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Gun : MonoBehaviour
{
    Vector2 Dir;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Shoot_Pos;
    [SerializeField] GameObject Aim;
    [HideInInspector]public Vector2 diff;
    public float Force;


    public static Gun instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Debug.Log(Bazooka.Boy.GameManager.TotalShootedBullet);
        if (StaticData.CurLevelNo >= 35)
        {
            BulletViewer(4);
        }
        else
        {
            BulletViewer(3);
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButton(0) && !StaticData.isOver && !StaticData.IsWin && EventSystem.current.currentSelectedGameObject == null)
        {
            RotateGun();
        }

        if(Input.GetMouseButtonUp(0) && !StaticData.isOver && !StaticData.IsWin && EventSystem.current.currentSelectedGameObject == null)
        {
            if(Bazooka.Boy.GameManager.TotalShootedBullet > 0)
            Shoot();
        }

    }

    public void RotateGun()
    {
         diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diff.Normalize();
        Aim.SetActive(true);
        Aim.transform.position = Pos;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z );
         Force = Vector2.Distance(Aim.transform.position, transform.position) + 3f;

    }

    public void Shoot()
    {
        
        Aim.SetActive(false);
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        GameObject Bul = Instantiate(Bullet , Shoot_Pos.position, transform.rotation , Bazooka.Boy.GameManager.Instance.MainParent.transform);
        Force = Vector2.Distance(Aim.transform.position , transform.position) + 3f;
        Bul.GetComponent<Rigidbody2D>().AddForce(diff * Force, ForceMode2D.Impulse);
        Force = Vector2.Distance(Aim.transform.position, transform.position) + 3f;
        Bazooka.Boy.GameManager.TotalShootedBullet--;
        Debug.LogError("It's Bullet : " + Bazooka.Boy.GameManager.TotalShootedBullet);
        BulletViewer(Bazooka.Boy.GameManager.TotalShootedBullet);
        if (Bazooka.Boy.GameManager.TotalShootedBullet == 0)
        {
            StartCoroutine(ChanceCounter());
        }
        

    }


    public IEnumerator ChanceCounter()
    {
        Debug.LogError("Called");
        yield return new WaitForSeconds(3.5f);

        Debug.LogError("Total Killed : " + Bazooka.Boy.GameManager.Total_Killed_Enemy + "Total : " +Bazooka.Boy.GameManager.Instance.Total_Enemy);
            if (Bazooka.Boy.GameManager.Total_Killed_Enemy != Bazooka.Boy.GameManager.Instance.Total_Enemy && !StaticData.IsWin)
            {
                    Debug.Log("GameOver");
                //Bazooka.Boy.UIManager.instance.GameOver();
                if (FireBaseData.instance.IsAds && StaticData.AdShowCounter <= 3)
                {
                Debug.LogError(StaticData.AdShowCounter);
                    Bazooka.Boy.UIManager.instance.FillCircle.fillAmount = 1;
                    Bazooka.Boy.UIManager.instance.OpenBulletAdPanel();
                }
                else
                {
                    Bazooka.Boy.UIManager.instance.GameOver();
                }
            }
    }

    public void BulletViewer(int no)
    {
        int total = new int();

        if(StaticData.CurLevelNo >= 35)
        {
            total = 4;
        }
        else
        {
            total = 3;
        }
        Debug.LogError("Child : "+Bazooka.Boy.UIManager.instance.EmptyBulletParent.transform.GetChild(0).transform.childCount + " And "+ Bazooka.Boy.UIManager.instance.EmptyBulletParent.name); 

        for (int i = 0; i < total; i++)
        {
            Bazooka.Boy.UIManager.instance.EmptyBulletParent.transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }

        for (int i = 0; i < no; i++)
        {
            Bazooka.Boy.UIManager.instance.EmptyBulletParent.transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
