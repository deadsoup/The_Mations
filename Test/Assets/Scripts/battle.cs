using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle : MonoBehaviour {

    int pdamage;
    int edamage;

    float eTime = 10.0f;

    public static bool battleaction;
    public static int i; //몬스터 배열 호출

    public static int c = 1; //캐릭터 변환




    public void playerAttak()
    {
        npc.actiongage -= 3.0f;

        int dice = Random.Range(1, 7);
        int enemyDef = dice + npc.evasion[i];

        pdamage = npc.atk[c] - enemyDef;
        if (pdamage <= 0) { pdamage = 0; }

        npc.Hp[i] -= pdamage;



        if (npc.actiongage <= 0)
        {
            npc.actiongage = 0f;
            npc.action = false;
            npc.eAction = true;
            npc.eActiongage = 10f;
        }
    }

    public void skillAttak()
    {
        npc.actiongage -= 5.0f;

        int dice = Random.Range(1, 7);
        int enemyDef = dice + npc.evasion[i];

        pdamage = npc.atk[c] + 10 - enemyDef;
        if (pdamage <= 0) { pdamage = 0; }

        npc.Hp[i] -= pdamage;



        if (npc.actiongage <= 0)
        {

            npc.actiongage = 0;

            npc.action = false;
            npc.eAction = true;
            if (npc.eAction == true)
            {

                npc.eActiongage = 10f;
                npc.actiongage = 10.1f;
            }
        }
    }

    public void skip()
    {
        npc.actiongage = 0f;
        
        
            npc.action = false;
            npc.eAction = true;
            npc.eActiongage = 10f;
        
        
    }





    public void enemyAttak()
    {
        npc.eActiongage -= 3.0f;

        int dice = Random.Range(1, 7);
        int enemyDef = dice + npc.evasion[c];

        edamage = npc.atk[i] - enemyDef;
        if (edamage <= 0) { edamage = 0; }

        npc.Hp[c] -= edamage;
        

        if (npc.eActiongage <= 0)
        {
            npc.eActiongage = 0f;
            npc.eAction = false;
            npc.action = true;
            Debug.Log("턴 완료");
            if (npc.action == true)
            {
                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                npc.actiongage = 10.1f;
                npc.eActiongage = 10f;
            }
        }
    }
    


    // Use this for initialization
    void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.C)&& npc.Hp[1] > 0) // 체인지 게타원
        {
            c = 1;
            Debug.Log("현재 활동하는 캐릭터는  " + npc.name[c] + "다");
        }

        if (Input.GetKeyDown(KeyCode.D) && npc.Hp[4] > 0) // 체인지 게타투
        {
            c = 4;
            Debug.Log("현재 활동하는 캐릭터는  " + npc.name[c] + "다");
        }

        








        if (battleaction == true)
        {
            if (Input.GetKeyDown(KeyCode.A)&& npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
            {
                playerAttak();
                Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
                Debug.Log(npc.name[c] + "은 " + npc.name[i] + "에게 " + pdamage + "를 가했다.");
                Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
                Debug.Log(npc.action);
            }

            if (Input.GetKeyDown(KeyCode.S) && npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
            {
                skillAttak();
                Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
                Debug.Log(npc.name[c] + "은 " + npc.name[i] + "에게 염구를 던진다." + pdamage + "의 충격을 가한다.");
                Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
                Debug.Log(npc.action);
            }

            if (Input.GetKeyDown(KeyCode.Space) && npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
            {
                skip();
                Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
                Debug.Log(npc.name[c] + "는 턴을 종료한다.");
                Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
                Debug.Log(npc.action);
            }



            

            if (npc.eAction == true ) // 적 공격
            {
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("적의 턴입니다.");
                    eTime += 10f;
                }




                if (npc.Hp[i] > 0 && eTime >= 20.0f)
                {
                    enemyAttak();
                    Debug.Log("현재 남은 액션 게이지 = " + npc.eActiongage + "다");
                    Debug.Log(npc.name[i] + "은 " + npc.name[c] + "에게 " + edamage + "를 가했다.");
                    Debug.Log(npc.name[c] + "은 " + npc.Hp[c] + "가 남았다.");
                    Debug.Log(npc.eAction);
                    eTime = 0f;
                }
            }

            if (npc.Hp[1] <= 0  && npc.Hp[4] <= 0)
            {
                Debug.Log("플레이어 패배");
                npc.action = false;
                npc.eAction = false;
                battleaction = false;
            }

            if (npc.Hp[i] <= 0)
            {
                Debug.Log("플레이어 승리");
                npc.action = false;
                npc.eAction = false;
                battleaction = false;
                npc.huntCount[i]++;
                npc.actiongage = 10f;
                npc.eActiongage = 10f;


                Debug.Log(npc.name[i]+"를 총"+ npc.huntCount[i] + "마리 해치웠다.");
                npc.Hp[2] = 50;
                npc.Hp[3] = 70;

            }
        }

    }
}
