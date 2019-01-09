using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class Party : MonoBehaviour
{
    internal bool[] player = new bool[10]; //  캐릭터 셀렉트에서 사용하면 될듯
    internal GameObject[] playerSlot = new GameObject[3]; // 캐릭터 슬롯 즉 전투캐릭터슬롯 1,2,3 말하는거임
    public GameObject[] playerSprite = new GameObject[3]; // 전투캐릭터1,2,3의 스프라이트
    public Sprite[] CharSprite = new Sprite[3]; // 저장시킨 스프라이트 이미지들  | playerSprite로 가져올거임
    public int CharSelectNum;

    public static Party instance = null;
    battle Battle;

    public int num;
    public int num2;
    public int num3;

    public void selectPlayer(int num)
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (i == num)
            {
                player[i] = true;
                for (int PS = 0; PS < playerSlot.Length; PS++)
                {
                    //if (playerSlot[PS].GetComponent<PlayerSlot1>().slotCharge == false)
                    if (playerSlot[PS].GetComponent<PlayerSlot1>().slotCharge == false)
                    {
                        playerSlot[PS].GetComponent<PlayerSlot1>().slotCharge = true;
                        battle.switching[PS] = num;
                        if (SceneManager.GetActiveScene().name == "DH_Battle")
                        {
                            Debug.Log("캐릭터 스프라이트 호출");
                            playerSprite[PS].GetComponent<Image>().sprite = CharSprite[num];
                            Debug.Log(PS);
                            Debug.Log(playerSprite[PS].GetComponent<Image>().sprite);
                            Debug.Log(CharSprite[num]);
                        }
                        break;
                    }
                    else if (playerSlot[0].GetComponent<PlayerSlot1>().slotCharge == true && playerSlot[1].GetComponent<PlayerSlot1>().slotCharge == true && playerSlot[2].GetComponent<PlayerSlot1>().slotCharge == true)
                    {
                        break;
                    }
                }
                
                break;
            }
        }

    }

    public int playerSelect1(int Adebt)
    {
        player[Adebt] = true;
        num = Adebt;
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            if (playerSlot[0].GetComponent<PlayerSlot1>().slotCharge == false)
            {
                GameObject Image = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
                Image.SetActive(true);
                playerSlot[0].GetComponent<PlayerSlot1>().slotCharge = true;
                battle.switching[0] = Adebt;
                if (SceneManager.GetActiveScene().name == "DH_Battle")

                    Debug.Log("캐릭터 스프라이트 호출");
                playerSprite[0].GetComponent<Image>().sprite = CharSprite[Adebt];

                Battle.chaneGetta1();

            }
        }
        return num;
    }



    public int playerSelect2(int num)
    {
        player[num] = true;
        num2 = num;
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            if (playerSlot[1].GetComponent<PlayerSlot1>().slotCharge == false)
            {

                GameObject Image = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
                Image.SetActive(true);
                playerSlot[1].GetComponent<PlayerSlot1>().slotCharge = true;
                battle.switching[1] = num;

                Debug.Log("캐릭터 스프라이트 호출");
                playerSprite[1].GetComponent<Image>().sprite = CharSprite[num];
            }
        }
        return num2;
    }


    public int playerSelect3(int num)
    {
        player[num] = true;
        num3 = num;
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            if (playerSlot[2].GetComponent<PlayerSlot1>().slotCharge == false)
            {

                GameObject Image = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;
                Image.SetActive(true);
                playerSlot[2].GetComponent<PlayerSlot1>().slotCharge = true;
                battle.switching[2] = num;
                if (SceneManager.GetActiveScene().name == "DH_Battle")

                    Debug.Log("캐릭터 스프라이트 호출");
                playerSprite[2].GetComponent<Image>().sprite = CharSprite[num];

            }
        }
        return num3;
    }

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        //print(playerSprite[0].GetComponent<Image>().sprite);
        




        //playerSelect1(0);
        //playerSelect2(1);
        //playerSelect3(2);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            playerSlot[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
            playerSlot[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
            playerSlot[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;

            playerSprite[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").transform.Find("Char1").gameObject;
            playerSprite[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").transform.Find("Char2").gameObject;
            playerSprite[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").transform.Find("Char3").gameObject;
            Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            playerSlot[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
            playerSlot[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
            playerSlot[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;

            playerSprite[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").transform.Find("Char1").gameObject;
            playerSprite[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").transform.Find("Char2").gameObject;
            playerSprite[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").transform.Find("Char3").gameObject;
            Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();
        }

        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Json"))
            {
                print("캐릭터 생성 완료 ");
                if (player[num] == true)
                {
                    print("1번 캐릭 생성");
                    playerSelect1(num);
                }
            }

        }




            /*
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                playerSelect1(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                playerSelect1(1);
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                playerSelect1(2);
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                playerSelect2(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                playerSelect2(1);
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                playerSelect2(2);
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                playerSelect3(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                playerSelect3(1);
            }
            if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                playerSelect3(2);
            }
            */
        }
    }
