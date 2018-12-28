using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Party : MonoBehaviour
{
    bool[] player = new bool[6]; //  캐릭터 셀렉트에서 사용하면 될듯
    internal GameObject[] playerSlot = new GameObject[3]; // 캐릭터 슬롯 즉 전투캐릭터슬롯 1,2,3 말하는거임
    internal GameObject[] playerSprite = new GameObject[3]; // 전투캐릭터1,2,3의 스프라이트
    public Sprite[] CharSprite = new Sprite[3]; // 저장시킨 스프라이트 이미지들  | playerSprite로 가져올거임
    void selectPlayer(int num)
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
                        playerSprite[PS].GetComponent<Image>().sprite = CharSprite[num];
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



    // Start is called before the first frame update
    void Start()
    {
        playerSlot[0] = GameObject.Find("Getta1");
        playerSlot[1] = GameObject.Find("Getta2");
        playerSlot[2] = GameObject.Find("Getta3");

        playerSprite[0] = GameObject.Find("Char1");
        playerSprite[1] = GameObject.Find("Char2");
        playerSprite[2] = GameObject.Find("Char3");
        print(playerSprite[0].GetComponent<Image>().sprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            selectPlayer(0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            selectPlayer(1);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            selectPlayer(2);
        }

    }
}
