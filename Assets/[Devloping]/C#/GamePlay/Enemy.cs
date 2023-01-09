using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject DiedEnemy;
    bool IsDied;

    private void Start()
    {
        IsDied = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Props"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            EnemyDie(transform.parent.gameObject);
        }
    }

    public void EnemyDie(GameObject Enmy)
    {
        if (!IsDied)
        {
            IsDied = true;
            GameObject DieEnemy = Instantiate(DiedEnemy, Enmy.transform.position, Quaternion.identity, Bazooka.Boy.GameManager.Instance.MainParent.transform);
            Destroy(Enmy);
            EnemyDieCounter();
            foreach (Transform parts in DieEnemy.transform)
            {
                parts.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(2, 5)), ForceMode2D.Impulse);
            }
            Destroy(DieEnemy, 2.5f);
            // GameObject Par = Instantiate(Blood_Particle , DieEnemy.transform.position , Quaternion.identity , DieEnemy.transform);
        }
    }

    public void EnemyDieCounter()
    {
        Bazooka.Boy.GameManager.Total_Killed_Enemy++;

        if (Bazooka.Boy.GameManager.Total_Killed_Enemy == Bazooka.Boy.GameManager.Instance.Total_Enemy)
        {
            Debug.Log(" You Won Man");
            Bazooka.Boy.UIManager.instance.GameWin();

        }
    }
}
