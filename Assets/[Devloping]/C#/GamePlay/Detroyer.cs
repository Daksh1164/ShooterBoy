using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(StartDestroyer());
    }

    IEnumerator StartDestroyer()
    {
        yield return new WaitForSeconds(1.5f);

        if(transform.parent == null)
        {
            Destroy(gameObject);
        }
    }
}
