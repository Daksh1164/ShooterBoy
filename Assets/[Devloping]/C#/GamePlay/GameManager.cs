using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bazooka.Boy
{

    public class GameManager : MonoBehaviour
    {
        public GameObject Enemy_Parent;
        public int Total_Enemy;
        public static int TotalShootedBullet ;
        public GameObject Player;
        public GameObject MainParent;
        public bool isInterShow = true;
        [HideInInspector] public static int Total_Killed_Enemy;


      

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
           
        }

        private void Start()
        {
            Total_Killed_Enemy = 0;
            Time.timeScale = 1f;

            StaticData.isOver = false;
            StaticData.IsWin = false;

        }

        
    }
}