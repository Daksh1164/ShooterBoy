using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdPermission : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Massagt_Type;
    public GameObject Loader_Object;
    public GameObject Yes_button;

    private void OnDisable()
    {
        Loader_Object.SetActive(true);
        Yes_button.GetComponent<Image>().enabled = false;
        Yes_button.GetComponent<Button>().enabled = false;
        Yes_button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
    }

}
    