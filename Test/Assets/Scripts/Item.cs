using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public static int i;
    public static int Q;


    public static bool setItem = false;
    public static bool c = false;
    static bool get1;
    static bool get2;
    static bool get3;
    static bool get4;

    static bool get1_2;
    static bool get2_2;
    static bool get3_2;
    static bool get4_2;



    public static void getItem()
    {
        
        if (Input.GetKeyDown(KeyCode.Q) && setItem == false)
        {
            
            Debug.Log(npc.item1[1]);
            npc.item1[1] = i;
            Debug.Log(get1);
            if (i == 1)
            {
                if (get1 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[1] + "착용 중");



                    npc.MaxHp[1] += 10;
                    Debug.Log("1번 착용 최대 체력 증가");

                    get1 = true;
                    setItem = true;
                }
            }

            if (i == 2)
            {
                if (get2 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[1] + "착용 중");



                    npc.MaxHp[1] += 15;
                    Debug.Log("2번 착용 최대 체력 증가");

                    get2 = true;
                    setItem = true;
                }
            }

            if (i == 3)
            {
                if (get3 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[1] + "착용 중");



                    npc.atk[1] += 5;
                    Debug.Log("3번 착용 공격력 증가");

                    get3 = true;
                    setItem = true;
                }

            }

            if (i == 4)
            {
                if (get4 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[1] + "착용 중");



                    Debug.Log("4번 착용 회피율 증가");

                    get4 = true;
                    setItem = true;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.W) && setItem == false)
        {


            Debug.Log(npc.item1[4]);
            npc.item1[4] = i;

            if (i == 1)
            {
                if (get1_2 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[4] + "착용 중");



                    npc.MaxHp[4] += 10;
                    Debug.Log("1번 착용 최대 체력 증가");

                    get1_2 = true;
                    setItem = true;
                }
            }

            if (i == 2)
            {
                if (get2_2 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[4] + "착용 중");



                    npc.MaxHp[4] += 15;
                    Debug.Log("2번 착용 최대 체력 증가");

                    get2_2 = true;
                    setItem = true;
                }
            }

            if (i == 3)
            {
                if (get3_2 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[4] + "착용 중");



                    npc.atk[4] += 5;
                    Debug.Log("3번 착용 공격력 증가");

                    get3_2 = true;
                    setItem = true;
                }

            }

            if (i == 4)
            {
                if (get4_2 == true)
                {
                    Debug.Log("이미 착용한 장비입니다.");
                }

                else
                {
                    Debug.Log(npc.name[4] + "착용 중");



                    Debug.Log("4번 착용 회피율 증가");

                    get4_2 = true;
                    setItem = true;
                }

            }


        }
        else if (setItem == true && c == false)
        {
            Debug.Log("아이템 획득 완료");
            c = true;
        }


    }





	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Q == 10)
        {
            getItem();
        }
    }
}
