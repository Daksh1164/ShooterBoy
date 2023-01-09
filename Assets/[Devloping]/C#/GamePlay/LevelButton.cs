using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int LevelNo;
    UnityEngine.UI.Button Btn;

    private void Start()
    {
        Btn = GetComponent<UnityEngine.UI.Button>();
        Btn.onClick.AddListener( () => Bazooka.Boy.LevelManager.instance.Level_Btn_Click(LevelNo));
    }
}
