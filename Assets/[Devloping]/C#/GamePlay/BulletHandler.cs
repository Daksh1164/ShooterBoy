using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] GameObject RedExplosion;
    [SerializeField] List<GameObject> Enemys;
    [SerializeField] GameObject DiedEnemy;
    [SerializeField] GameObject DiedPlayer;
    [SerializeField] GameObject Blood_Particle;
    bool IsCollide;



    private void Start()
    {
        foreach(Transform child in Bazooka.Boy.GameManager.Instance.Enemy_Parent.transform)
        {
            Enemys.Add(child.gameObject);
        }


        IsCollide = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Props") && !IsCollide)
        {
            IsCollide = true;
            StartCoroutine(TrueIsCollider());
            SpwanExplosion();

            foreach (GameObject Enemy in Enemys)
            {
                float Dis = Vector2.Distance(Enemy.transform.position , transform.position);

                if(Dis <= 1)
                {
                    EnemyDie(Enemy);
                    EnemyDieCounter();
                    //ChanceCounter();

                }
            }

            float DisToPlayer = Vector2.Distance(Bazooka.Boy.GameManager.Instance.Player.transform.position , transform.position);

            if(DisToPlayer <= 1)
            {
                PlayerDie((Bazooka.Boy.GameManager.Instance.Player.gameObject));
            }
        }

        if (collision.collider.CompareTag("Enemy") && !IsCollide)
        {
            IsCollide = true;
            StartCoroutine(TrueIsCollider());
            EnemyDie(collision.gameObject);
            SpwanExplosion();
            EnemyDieCounter();
            //ChanceCounter();
        }

            if (collision.collider.CompareTag("Player") && !IsCollide)
            {
                IsCollide = true;
                StartCoroutine(TrueIsCollider());

                SpwanExplosion();
                PlayerDie(collision.gameObject);
            }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !IsCollide)
        {
            IsCollide = true;
            StartCoroutine(TrueIsCollider());
            SpwanExplosion();
            PlayerDie(collision.gameObject);
        }
    }

    public void SpwanExplosion()
    {
        Destroy(gameObject);
        Instantiate(RedExplosion, transform.position, Quaternion.identity , Bazooka.Boy.GameManager.Instance.MainParent.transform);
    }

    public void EnemyDie(GameObject Enmy)
    {
        GameObject DieEnemy = Instantiate(DiedEnemy, Enmy.transform.position, Quaternion.identity, Bazooka.Boy.GameManager.Instance.MainParent.transform);
        Destroy(Enmy);

        foreach(Transform parts in DieEnemy.transform)
        {
            parts.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,Random.Range(2,5)) , ForceMode2D.Impulse);
        }
            Destroy(DieEnemy , 2.5f);
       // GameObject Par = Instantiate(Blood_Particle , DieEnemy.transform.position , Quaternion.identity , DieEnemy.transform);

    }

    

    public void EnemyDieCounter()
    {
        Bazooka.Boy.GameManager.Total_Killed_Enemy++;

        if(Bazooka.Boy.GameManager.Total_Killed_Enemy == Bazooka.Boy.GameManager.Instance.Total_Enemy)
        {
            Debug.Log(" You Won Man");
            Bazooka.Boy.UIManager.instance.GameWin();

        }
    }

    public void ChanceCounter()
    {
        if(Bazooka.Boy.GameManager.TotalShootedBullet == 0)
        {
            if (Bazooka.Boy.GameManager.Total_Killed_Enemy != Bazooka.Boy.GameManager.Instance.Total_Enemy)
            {
                Debug.Log("GameOver");
                Bazooka.Boy.UIManager.instance.GameOver();

            }
        }
    }

    public void PlayerDie(GameObject player)
    {
        if (!StaticData.isOver)
        {
            StaticData.isOver = true;
            GameObject DiePlayer = Instantiate(DiedPlayer, player.transform.position, Quaternion.identity, Bazooka.Boy.GameManager.Instance.MainParent.transform);
            Destroy(Bazooka.Boy.GameManager.Instance.Player);

            foreach (Transform parts in DiedPlayer.transform)
            {
                parts.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(2, 5)), ForceMode2D.Impulse);
            }

            Debug.Log("Game Over Lavde");
            Bazooka.Boy.UIManager.instance.GameOver();
        }
    }

    IEnumerator gameWin()
    {
        Debug.Log("It's Called");
        yield return new WaitForSeconds(2);
        Bazooka.Boy.UIManager.instance.GameOver();

    }

    public IEnumerator TrueIsCollider()
    {
        yield return new WaitForSeconds(0.6f);

        IsCollide = false;
    }
}
     