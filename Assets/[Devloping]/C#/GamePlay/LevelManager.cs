using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Bazooka.Boy
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] GameObject[] Levels;
        [SerializeField] List<Button> Level_Btn;
        [SerializeField] List<GameObject> Level_Text;
        [SerializeField] Sprite lockLevelBtnIMG, unlockLevelBtnIMG;
        [SerializeField] TMPro.TextMeshProUGUI GamePlayLevelNo;
        public GameObject GenratedLevelParent;
        public GameObject Level_Gen;
        public int LevelIndex;

        [Space(10)]
        [SerializeField] Button Button_Prefabe;
        [SerializeField] GameObject Button_Parent;
        [SerializeField] int Total_Levels;
        int levelCounter = 0;
        public static LevelManager instance;


        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            for (int i = 0; i < Total_Levels; i++)
            {
                Button Btn = Instantiate(Button_Prefabe, Button_Parent.transform);
                Btn.name = (i + 1).ToString();
                Btn.GetComponent<LevelButton>().LevelNo = i;
                Btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + (i + 1);
                Btn.transform.GetChild(1).gameObject.SetActive(false);
                Level_Btn.Add(Btn);
                Level_Text.Add(Btn.transform.GetChild(0).gameObject);
            }
            Lock_Set();
        }

        public void Lock_Set()
        {
            for (int i = 0; i < Level_Btn.Count; i++)
            {
                if (i <= StaticData.LevelNo)
                {
                    Level_Btn[i].interactable = true;
                    Level_Btn[i].GetComponent<Image>().sprite = unlockLevelBtnIMG;
                    Level_Btn[i].transform.GetChild(0).gameObject.SetActive(true);
                    Level_Btn[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    Level_Btn[i].interactable = false;
                    Level_Btn[i].GetComponent<Image>().sprite = lockLevelBtnIMG;
                    Level_Btn[i].transform.GetChild(0).gameObject.SetActive(false);
                    Level_Btn[i].transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }

        public void Level_Btn_Click(int a)
        {
            UIManager.instance.CurBtn = UIManager.WhichBtn.level;
            UIManager.instance.LNo = a;
            Bazooka.Boy.UIManager.instance.AdLoadCounter();
            /*Level_Genrate(a);
            Bazooka.Boy.UIManager.instance.PanelForBackBtn = 11;*/
        }


        public void Level_Genrate(int a)
        {
            StaticData.AdShowCounter = 1;
            SoundManager.instance.ButtonClickSound();
            StaticData.CurLevelNo = a;
            Debug.LogError("It's Current Level : " + StaticData.CurLevelNo);
            if (StaticData.CurLevelNo >= 35)
            {
                Bazooka.Boy.GameManager.TotalShootedBullet = 4;
                 UIManager.instance.EmptyBulletParent = UIManager.instance.EmptyBulletParent4.transform.gameObject;
                 UIManager.instance.EmptyBulletParent3.SetActive(false);
                 UIManager.instance.EmptyBulletParent4.SetActive(true);
            }
            else
            {
                Bazooka.Boy.GameManager.TotalShootedBullet = 3;
                UIManager.instance.EmptyBulletParent = UIManager.instance.EmptyBulletParent3.transform.gameObject;
                UIManager.instance.EmptyBulletParent4.SetActive(false);
                UIManager.instance.EmptyBulletParent3.SetActive(true);
            }
            Debug.LogError("It's Current Level : " + Bazooka.Boy.GameManager.TotalShootedBullet);
            if (Level_Gen != null) Destroy(Level_Gen);
            Level_Gen = Instantiate(Levels[a]);
            Level_Gen.transform.SetParent(GenratedLevelParent.transform);
            GamePlayLevelNo.text = "level " + (a + 1).ToString();
            Lock_Set();
            Bazooka.Boy.UIManager.instance.OnOffPanel(5);
            LevelIndex = (a + 1);

        }

    }
}