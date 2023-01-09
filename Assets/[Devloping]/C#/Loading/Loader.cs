using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public static Loader instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(OfScreen());    
    }
    
    public IEnumerator OfScreen()
    {
        yield return new WaitForSeconds(4);
        Bazooka.Boy.UIManager.instance.Panels[10].SetActive(false);
    }

}
