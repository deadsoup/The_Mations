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
        

        if (battle.battleaction == false && Input.GetKeyDown(KeyCode.Space))
        {
            move++;
            Debug.Log(move + "만큼 이동합니다.");
            battlecount = Random.Range(1, 3);
            battle.i = Random.Range(2, 4);



            if (battlecount == 1)
            {
                Debug.Log("전투 시작");
                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                battle.battleaction = true;
                npc.action = true;

            }
            
        }
	}
}
