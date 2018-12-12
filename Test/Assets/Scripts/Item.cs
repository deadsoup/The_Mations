using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    


    public static void getItem()
    {
        int i = Random.Range(1, 5);
        Debug.Log("1번 캐릭터에게 아이템을 장착시키겠습니까? --- 1번 클릭 ---");
        Debug.Log("2번 캐릭터에게 아이템을 장착시키겠습니까? --- 2번 클릭 ---");
        Debug.Log(i);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("나는 피카츄다");
            Debug.Log(npc.item1[1]);
            npc.item1[1] = i;
            
            if (i == 1)
            {
                Debug.Log("착용 중");
                bool setItme = false;

                if (setItme == false)
                {
                    npc.MaxHp[1] += 10;
                    Debug.Log("1번 착용 최대 체력 증가");
                    setItme = true;
                }
            }

            if (i == 2)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.MaxHp[1] += 15;
                    Debug.Log("2번 착용 최대 체력 증가");
                    setItme = true;
                }

            }

            if (i == 3)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.atk[1] += 5;
                    Debug.Log("3번 착용 공격력 증가");
                    setItme = true;
                }

            }

            if (i == 4)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.evasion[1] += 1;
                    Debug.Log("4번 착용 회피율 증가");
                    setItme = true;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(npc.item1[4]);
            npc.item1[4] = i;

            if (i == 1)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.MaxHp[4] += 10;
                    Debug.Log("1번 착용 최대 체력 증가");
                    setItme = true;
                }
            }

            if (i == 2)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.MaxHp[4] += 15;
                    Debug.Log("2번 착용 최대 체력 증가");
                    setItme = true;
                }

            }

            if (i == 3)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.atk[4] += 5;
                    Debug.Log("3번 착용 공격력 증가");
                    setItme = true;
                }

            }

            if (i == 4)
            {
                Debug.Log("착용 중");
                bool setItme = false;
                if (setItme == false)
                {
                    npc.evasion[4] += 1;
                    Debug.Log("4번 착용 회피율 증가");
                    setItme = true;
                }

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

    }
}
