using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Bazooka.Boy
{
    public class UIManager : MonoBehaviour
    {

        public List<GameObject> Panels;
        [SerializeField] GameObject LevelParent;

        public GameObject EmptyBulletParent;
        public GameObject EmptyBulletParent3;
        public GameObject EmptyBulletParent4;

        [Space(10)]
        [SerializeField] TextMeshProUGUI Balance_Amount;
        [SerializeField] TextMeshProUGUI WithDraw_Amount;
        [SerializeField] GameObject Dollar_Prefabe;
        [SerializeField] GameObject Dollar;
        [SerializeField] GameObject Dollar_Parent;
        [SerializeField] GameObject TopBar;
        [SerializeField] Canvas can;


        
        public Image FillCircle;
        private float Fill_Counter;
        private string PanelName;

        private bool IsInterAd;

        public int PanelForBackBtn;
        public GameObject AppOpenObject;

        public string ObjectName;
        public enum WhichRewerd
        {
            Gun,
            Player,
            Bullet
        };

        public WhichRewerd RewerdGive;

        public enum WhichBtn
        {
            start,
            play,
            balance,
            withdraw,
            shop,
            home,
            restart,
            next,
            level
        };

        public WhichBtn CurBtn;
        [HideInInspector]public int LNo;

        private bool IsInterShow = true;
        public static UIManager instance;

        private void Awake()
        {
            Time.timeScale = 1f;
            instance = this;
            IsInterAd = false;

            Fill_Counter = 1;
            PanelForBackBtn = 10;
            PanelName = "Home";
            StartCoroutine(OffAd()) ;

            if(StaticData.CurLevelNo >= 35)
            {
                EmptyBulletParent = EmptyBulletParent4.transform.gameObject;
                EmptyBulletParent3.SetActive(false);
                EmptyBulletParent4.SetActive(true);
            }
            else
            {
                EmptyBulletParent = EmptyBulletParent3.transform.gameObject;
                EmptyBulletParent4.SetActive(false);
                EmptyBulletParent3.SetActive(true);

            }
            LoadBanner();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(PanelForBackBtn == 10)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Splash");
                }
                else if(PanelForBackBtn == 11)
                {
                    GamePLayBack();
                }
                else
                {
                    BackButton(PanelForBackBtn);
                }
            }
        }

        public void ShowRewerdAD()
        {
            if (RewerdGive == WhichRewerd.Gun)
            {
                ShopItem.instance.ShowAds();
            }

            if (RewerdGive == WhichRewerd.Player)
            {
                PlayerShop.instance.ShownAds();
            }

            if (RewerdGive == WhichRewerd.Bullet)
            {
                RewaredAd.instance.ShowAds();
            }
        }

        public void StartButton()
        {
            CurBtn = WhichBtn.start;
            AdLoadCounter();
          /*  OnOffPanel(1);
            WithDraw_Amount.text = StaticData.WinAmount.ToString() + "$";
            Balance_Amount.text = StaticData.WinAmount.ToString() + "$";
            SoundManager.instance.ButtonClickSound();
            //AdManager._instance.showInterststitialAd();
            PanelForBackBtn = 0;
            PanelName = "Start";

            if(IsInterAd == true )
            {
                Panels[10].SetActive(true);
            }

            LoadBanner();*/


        }

        public void PlayButton()
        {
            CurBtn = WhichBtn.play;
            AdLoadCounter();

            /* Panels[2].SetActive(true);
             OnOffPanel(2);
             SoundManager.instance.ButtonClickSound();
             PanelForBackBtn = 1;
             PanelName = "Level";

             if (IsInterAd == true)
             {
                 Panels[10].SetActive(true);
             }
             LoadBanner();*/

        }

        public void BalanceButton()
        {
            CurBtn = WhichBtn.balance;
            AdLoadCounter();

            /*Panels[3].SetActive(true);
            OnOffPanel(3);
            SoundManager.instance.ButtonClickSound();
            PanelForBackBtn = 1;
            PanelName = "Balance";

            if (IsInterAd == true)
            {
                Panels[10].SetActive(true);
            }
            LoadBanner();*/

        }

        public void ShopButton()
        {
            CurBtn = WhichBtn.shop;

            AdLoadCounter();
            /*OnOffPanel(9);
            SoundManager.instance.ButtonClickSound();
            PanelForBackBtn = 1;
            PanelName = "Shop";

            if (IsInterAd == true)
            {
                Panels[10].SetActive(true);
            }
            LoadBanner();*/
        }

        public void WithDrawButton()
        {
            CurBtn = WhichBtn.withdraw;

            AdLoadCounter();
            /*Panels[4].SetActive(true);
            OnOffPanel(4);
            SoundManager.instance.ButtonClickSound();
            PanelForBackBtn = 1;
            PanelName = "Withdraw";

            if (IsInterAd == true)
            {
                Panels[10].SetActive(true);
            }
            LoadBanner();*/

        }

        public void PrivacyBtn()
        {
            Application.OpenURL("https://docs.google.com/document/d/1h8m32Q9eoM95QlLa-v4N0obauVhBgy2b9k_DuBX89-E/edit");
        }

        public void BackButton(int PanelNo)
        {
            
            if(PanelNo == 1)
            {
                PanelForBackBtn = 0;
            }
            if (PanelNo == 0)
            {
                PanelName = "Start";
                PanelForBackBtn = 10;
            }
            OnOffPanel(PanelNo);
            //Panels[PanelNo].SetActive(false);
            SoundManager.instance.ButtonClickSound();
            if (PanelName == "Balance")
                PanelForBackBtn = 0;
            if (PanelName == "Withdraw")
                PanelForBackBtn = 0;
            if (PanelName == "Level")
                PanelForBackBtn = 0;
            if (PanelName == "Shop")
                PanelForBackBtn = 0;
            if (PanelName == "Start")
                PanelForBackBtn = 10;

            

            LoadBanner();

        }

        public void GamePLayBack()
        {
            ClearAll();
            OnOffPanel(2);
            LoadBanner();
            SoundManager.instance.ButtonClickSound();
        }
        public void HomeButton()
        {
            Admob.instance.DestroyBannerAd();
            CurBtn = WhichBtn.home;

           // AdLoadCounter();
            StaticData.isOver = false;
            StaticData.IsWin = false;
            SoundManager.instance.ButtonClickSound();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
            PanelForBackBtn = 10;
            PanelName = "Home";

            LoadBanner();
        }

        public void Restart()
        {
            AdLoadCounter();
            CurBtn = WhichBtn.restart;

            /* ClearAll();
             StaticData.isOver = false;
             StaticData.IsWin = false;
             //SoundManager.instance.ButtonClickSound();
             Time.timeScale = 1f;
             LevelManager.instance.Level_Genrate(StaticData.CurLevelNo);
             OnOffPanel(5);
             //StaticData.instance.CrossedCounter = 0;
             if (StaticData.CurLevelNo >= 35)
             {
                 Bazooka.Boy.GameManager.TotalShootedBullet = 4;
             }
             else
             {
                 Bazooka.Boy.GameManager.TotalShootedBullet = 3;
             }
             SoundManager.instance.ButtonClickSound();
             PanelForBackBtn = 11;
             PanelName = "GamePlay";

             if (IsInterAd == true)
             {
                 Panels[10].SetActive(true);
             }
             LoadBanner();*/
        }

        public void nextbtn(bool IsWinOpen)
        {
            //StaticData.instance.CrossedCounter = 0;
            TopBar.transform.SetParent(Panels[5].transform);
            CurBtn = WhichBtn.next;

            if (!IsWinOpen)
            {
                AdLoadCounter();
            }
            /*Time.timeScale = 1f;
            ClearAll();
            StaticData.isOver = false;
            StaticData.IsWin = false;
            SoundManager.instance.ButtonClickSound();
            LevelManager.instance.Level_Genrate(StaticData.CurLevelNo + 1);
            //OnOffPanel(2);
            Time.timeScale = 1f;
            PanelForBackBtn = 1;
            PanelName = "Level";

            if (StaticData.CurLevelNo >= 35)
            {
                Bazooka.Boy.GameManager.TotalShootedBullet = 4;
            }
            else
            {
                Bazooka.Boy.GameManager.TotalShootedBullet = 3;
            }
            SoundManager.instance.ButtonClickSound();

            if (IsInterAd == true)
            {
                Panels[10].SetActive(true);
            }
            LoadBanner();*/
        }

        public void CloseAdPermissonPanel()
        {
            Panels[11].SetActive(false);
        }


        public IEnumerator OpenGameWinpanel()
        {
            yield return new WaitForSeconds(3f);
            TopBar.transform.SetParent(Panels[6].transform);
            Debug.Log("Level no : " + StaticData.LevelNo + "<======> Current level" + StaticData.CurLevelNo);
            SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Win);
            StaticData.IsWin = true;
            Time.timeScale = 0f;
            Panels[6].SetActive(true);
            SoundManager.instance.BGSource.Pause();
            
            if (StaticData.LevelNo <= StaticData.CurLevelNo)
            {
                StaticData.LevelNo = StaticData.CurLevelNo + 1;
                LevelManager.instance.Lock_Set();
                StaticData.WinAmount += 2;
                CoinsManager.instance.AddCoins(Vector3.zero,2);
            }

        }

        public IEnumerator OpengamwOverPanel(float time)
        {
            yield return new WaitForSeconds(time);
            Panels[8].SetActive(false);
            SoundManager.instance.Sound.PlayOneShot(SoundManager.instance.Loss);
            SoundManager.instance.BGSource.Pause();
            StaticData.isOver = true;
            Panels[7].SetActive(true);
            Time.timeScale = 0f;
        }

        public void OpenBulletAdPanel()
        {
            SoundManager.instance.BGSource.Pause();
            StaticData.isOver = true;
            Panels[8].SetActive(true);
            StartCoroutine(Second_Counter(10));
        }

        public IEnumerator Second_Counter(int i)
        {
            while(i!=0)
            {
                yield return new WaitForSeconds(1);
                i--;
                Fill_Counter -= 0.1f;
                //FillCircle.fillAmount = Fill_Counter;
                FillCircle.DOFillAmount(Fill_Counter,1f).SetEase(Ease.Linear);
                if(i==0)
                {

                    StartCoroutine(OpengamwOverPanel(1f));
                    
                }
            }

        }

        public void AddOneBullet()
        {
            FillCircle.fillAmount = 1;
            Fill_Counter = 1f;
            StopAllCoroutines();
            GameManager.TotalShootedBullet = 1;
            StaticData.isOver = false;
            Gun.instance.BulletViewer(GameManager.TotalShootedBullet);
            Time.timeScale = 1f;
            OnOffPanel(5);
        }

        public void OnOffPanel(int Index)
        {
            foreach (GameObject panel in Panels)
            {
                panel.SetActive(false);
            }

            Panels[Index].SetActive(true);
        }

        public void ClearAll()
        {
            foreach (Transform child in LevelParent.transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void GameWin()
        {
            if(!StaticData.isOver)
                StartCoroutine(OpenGameWinpanel());
        }

        public void GameOver()
        {
            if (!StaticData.IsWin)
                StartCoroutine(OpengamwOverPanel(3));
        }

        public void AdLoadCounter()
        {

            if(FireBaseData.instance.IsAds)
            {  
                if (StaticData.counter == 0)
                {

                    InterAd.instance.RequestInterstitial();
                    IsInterShow = true;
                    StaticData.lastloadedCount = StaticData.counter;
                    StartCoroutine(ShowINter());

                }
                else if (StaticData.lastloadedCount + (StaticData.Firebase_Counter + 1) == StaticData.counter)
                {
                    InterAd.instance.RequestInterstitial();
                    IsInterShow = true;

                    StaticData.lastloadedCount = StaticData.counter;
                    StartCoroutine(ShowINter());
                }
                else
                {
                    IsInterAd = false;
                    IsInterShow = false;

                    //StartCoroutine(Loader.instance.OfScreen());
                    StartCoroutine(ButtonCode(CurBtn));
                    Panels[10].SetActive(false);
                }
                StaticData.counter++;
            }
            else
            {
                ButtonCode(CurBtn);
            }

        }

        IEnumerator ShowINter()
        {
            Debug.LogError("Current Btn : " + CurBtn);
            StartCoroutine(ButtonCode(CurBtn));
            bool IsShown = false;
           // GameManager.Instance.isInterShow = true;
             float T = 0;

             while (T <= 4)
             {
                 T += 0.01666f;
                 yield return new WaitForSeconds(0.01f);
                 if (InterAd.instance.IsLoaded)
                 {
                    IsShown = true;
                    AppOpenObject.SetActive(false);
                    IsInterAd = true;
                    
                    InterAd.instance.ShowInter();
                    break;
                }
             }
            yield return null;
            //GameManager.Instance.isInterShow = false;
            if (!IsShown)
            {
                 ButtonCode(CurBtn);
                 Panels[10].SetActive(false);
             }
           
            
        }


        public void LoadBanner()
        {
            Admob.instance.DestroyBannerAd();
            Admob.instance.RequestBannerAd();
        }

        public IEnumerator OffAd()
        {
            yield return new WaitForSeconds(0.5f);
            AppOpenObject.SetActive(true);
        }

        public IEnumerator ButtonCode(WhichBtn Btn)
        {
            Time.timeScale = 1f;

            if(Btn == WhichBtn.start)
            {
                OnOffPanel(1);
                WithDraw_Amount.text = StaticData.WinAmount.ToString() + "$";
                Balance_Amount.text = StaticData.WinAmount.ToString() + "$";
                SoundManager.instance.ButtonClickSound();
                //AdManager._instance.showInterststitialAd();
                PanelForBackBtn = 0;
                PanelName = "Start";

               /* if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/

                LoadBanner();
            }

            if (Btn == WhichBtn.play)
            {
                Panels[2].SetActive(true);
                OnOffPanel(2);
                SoundManager.instance.ButtonClickSound();
                PanelForBackBtn = 1;
                PanelName = "Level";

               /* if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (Btn == WhichBtn.balance)
            {
                Panels[3].SetActive(true);
                OnOffPanel(3);
                SoundManager.instance.ButtonClickSound();
                PanelForBackBtn = 1;
                PanelName = "Balance";

              /*  if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (Btn == WhichBtn.withdraw)
            {
                Panels[4].SetActive(true);
                OnOffPanel(4);
                SoundManager.instance.ButtonClickSound();
                PanelForBackBtn = 1;
                PanelName = "Withdraw";

               /* if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (Btn == WhichBtn.shop)
            {
                OnOffPanel(9);
                SoundManager.instance.ButtonClickSound();
                PanelForBackBtn = 1;
                PanelName = "Shop";

                /*if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (Btn == WhichBtn.home)
            {
                StaticData.isOver = false;
                StaticData.IsWin = false;
                SoundManager.instance.ButtonClickSound();
                UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
                PanelForBackBtn = 10;
                PanelName = "Home";

               /* if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (Btn == WhichBtn.restart)
            {
                ClearAll();
                StaticData.isOver = false;
                StaticData.IsWin = false;
                //SoundManager.instance.ButtonClickSound();
                Time.timeScale = 1f;
                LevelManager.instance.Level_Genrate(StaticData.CurLevelNo);
                OnOffPanel(5);
                //StaticData.instance.CrossedCounter = 0;
                if (StaticData.CurLevelNo >= 35)
                {
                    Bazooka.Boy.GameManager.TotalShootedBullet = 4;
                }
                else
                {
                    Bazooka.Boy.GameManager.TotalShootedBullet = 3;
                }
                SoundManager.instance.ButtonClickSound();
                PanelForBackBtn = 11;
                PanelName = "GamePlay";

                /*if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (Btn == WhichBtn.next)
            {
                Time.timeScale = 1f;
                ClearAll();
                WithDraw_Amount.text = StaticData.WinAmount.ToString() + "$";
                Balance_Amount.text = StaticData.WinAmount.ToString() + "$";
                StaticData.isOver = false;
                StaticData.IsWin = false;
                SoundManager.instance.ButtonClickSound();
                LevelManager.instance.Level_Genrate(StaticData.CurLevelNo + 1);
                //OnOffPanel(2);
                Time.timeScale = 1f;
                PanelForBackBtn = 1;
                PanelName = "Level";

                if (StaticData.CurLevelNo >= 35)
                {
                    Bazooka.Boy.GameManager.TotalShootedBullet = 4;
                }
                else
                {
                    Bazooka.Boy.GameManager.TotalShootedBullet = 3;
                }
                SoundManager.instance.ButtonClickSound();

                /*if (IsInterAd == true)
                {
                    Panels[10].SetActive(true);
                }*/
                LoadBanner();
            }

            if (CurBtn == WhichBtn.level)
            {
                LevelManager.instance.Level_Genrate(LNo);
                Bazooka.Boy.UIManager.instance.PanelForBackBtn = 11;
            }

            if (IsInterShow)
            {
                Panels[10].SetActive(true);
            }
            yield return null;  
        }
    }

}

/*
 * 
0. Home
1. Start
2. Level
3. Balance
4. WithDraw
5. GamePlay
6. Gamewin
7. Game Over
8. no Internet
9. shop
10. Loader
 * */