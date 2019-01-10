using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Option1 : MonoBehaviour
{

    
    public GameObject OptionPopup;
    public GameObject Close;
    public GameObject TitleGo;
    public static int Coin;


    // 캐릭터 선택 버튼
    public GameObject CharAdd;
    public Button[] buttons;
    // 캐릭터 획득, 스테이지 체크변수
    public int checkCount;
    public bool onChar;

    private bool isFIrst;

    // 파티 스크립트
    Party party;
    SaveBattleScene saveBS;


    private void Start()
    {
        isFIrst = false;

        Debug.Log("zzz");
    }

    private void Update()
    {
        if(isFIrst == false)
        {
            // 파티 스크립트 할당
            party = GameObject.Find("PartySystem").GetComponent<Party>();
            saveBS = GameObject.Find("EventSystem").GetComponent<SaveBattleScene>();

            // 캐릭터 획득
            addCharProcess();

            isFIrst = true;
        }
    }

    public void addCharProcess()
    {
        checkCount = 0;
        onChar = false;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (party.player[i] == true)
            {
                checkCount += 1;
            }
        }
        if (checkCount == 1 && GameManager.instance.StageInfos[4].FirstClear == true)
        {
            onChar = true;
        }

        if (checkCount == 2 && GameManager.instance.StageInfos[7].FirstClear == true)
        {
            onChar = true;
        }

        if (onChar == true)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                CharAdd.SetActive(true);

                if (party.player[i] == false)
                {
                    buttons[i].gameObject.SetActive(true);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    // 캐릭터 선택 버튼
    public void addChar(int num)
    {
        if (checkCount == 1)
        {
            saveBS.playerSelect2(num);
        }
        else if (checkCount == 2)
        {
            saveBS.playerSelect3(num);
        }

        CharAdd.SetActive(false);
    }

    public void Click()
    {
        OptionPopup.SetActive(true);
        Close.SetActive(true);

        if (StartDirector.count == true)
        {
            TitleGo.SetActive(true);
            

        }
        if (StartDirector.count == false)
        {


            TitleGo.SetActive(false);

        }


    }
    public void Click2()
    {

        OptionPopup.SetActive(false);

    }

}