using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    battle starbattle;

    Player player;

    int move;
    int battlecount;
    

    int TheBT;


    GameObject charHp;
    GameObject mobHp;

    // Use this for initialization
    void Start ()
    {
        starbattle = GetComponent<battle>();
        player = GetComponent<Player>();
        battle.battleaction = false;


        charHp = GameObject.Find("charHp");
        mobHp = GameObject.Find("mobHp");

    }
	
	// Update is called once per frame
	void Update ()
    {

        charHp.GetComponent<Text>().text = "체력 : " + npc.Hp[1];


        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("***********" + npc.name[1] + "의 정보입니다"+"***********");
            Debug.Log("***********"+"현재 최대 체력은  " + npc.MaxHp[1] + "***********");
            Debug.Log("***********" + "현재 현재 체력은  " + npc.Hp[1] + "***********");
            Debug.Log("***********" + "현재 최대 마나는  " + npc.MaxMp[1] + "***********");
            Debug.Log("***********" + "현재 현재 마나는  " + npc.Mp[1] + "***********");
            Debug.Log("***********" + "현재 공격력은  " + npc.atk[1] + "***********");
            Debug.Log("***********" + "현재 회피율은  " + npc.evasion[1] + "***********");

            Debug.Log("***********" + npc.name[4] + "의 정보입니다" + "***********");
            Debug.Log("***********" + "현재 최대 체력은  " + npc.MaxHp[4] + "***********");
            Debug.Log("***********" + "현재 현재 체력은  " + npc.Hp[4] + "***********");
            Debug.Log("***********" + "현재 최대 마나는  " + npc.MaxMp[4] + "***********");
            Debug.Log("***********" + "현재 현재 마나는  " + npc.Mp[4] + "***********");
            Debug.Log("***********" + "현재 공격력은  " + npc.atk[4] + "***********");
            Debug.Log("***********" + "현재 회피율은  " + npc.evasion[4] + "***********");




        }





        if (battle.battleaction == false && Input.GetKeyDown(KeyCode.M))
        {
            move++;
            Debug.Log(move + "만큼 이동합니다.");
            battlecount = Random.Range(1, 6);
            battle.i = Random.Range(2, 4);
            Item.setItem = false;
            Item.c = false;
            Item.Q = 0;


            if (battlecount == 1)
            {
                Debug.Log("전투 시작");
                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                battle.battleaction = true;
                npc.action = true;
               

            }
            
            if (battlecount == 2)
            {
                bool i = true;
                Debug.Log("아이템 등장");
                if (i == true)
                {
                    Item.Q = 10;
                    Debug.Log("1번 캐릭터에게 아이템을 장착시키겠습니까? --- 1번 클릭 ---");
                    Debug.Log("2번 캐릭터에게 아이템을 장착시키겠습니까? --- 2번 클릭 ---");

                    Item.i = Random.Range(1, 5);
                    Debug.Log(Item.i+"번 아이템 등장");
                    Item.getItem();
                    i = false;
                }
                

            }
            

            if (battlecount == 3)
            {
                Debug.Log("체력과 마나를 10% 회복합니다.");
                GameEvent.hpMpRegen();
                

            }


        }
	}
}
