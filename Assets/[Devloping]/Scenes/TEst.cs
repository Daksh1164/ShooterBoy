using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowINter());
    }

    
    IEnumerator ShowINter()
    {
        Debug.Log("Start Calling ");
        float T = 0;
        while (T <= 4)
        {
            Debug.Log("Counting");
            T += 0.01666f;
            yield return new WaitForSeconds(0.01f);
        }

        Debug.Log("Finished");
      
    }

   
}
