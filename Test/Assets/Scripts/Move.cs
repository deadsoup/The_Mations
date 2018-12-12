using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    battle starbattle;

    Player player;

    int move;
    int battlecount;
    

    int TheBT;

    // Use this for initialization
    void Start ()
    {
        starbattle = GetComponent<battle>();
        player = GetComponent<Player>();
        battle.battleaction = false;

    }
	
	// Update is called once per frame
	void Update ()
    {

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





        if (battle.battleaction == false && Input.GetKeyDown(KeyCode.Space))
        {
            move++;
            Debug.Log(move + "만큼 이동합니다.");
            battlecount = Random.Range(1, 6);
            battle.i = Random.Range(2, 4);



            if (battlecount == 6)
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
