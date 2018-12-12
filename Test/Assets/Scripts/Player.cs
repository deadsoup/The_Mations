using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("1번 캐릭터")]
    public string name;
    public int MaxHp;
    public int Hp;
    public int MaxMp;
    public int Mp;
    public int evasion;
    public float actiongage;
    public int atk;

    public int item1;
    public int item2;

    public int skill1;
    public int skill2;
    public int skill3;
    public int skill4;



    [Header("2번 캐릭터")]

    public string name2;
    public int MaxHp2;
    public int Hp2;
    public int MaxMp2;
    public int Mp2;
    public int evasion2;
    public float actiongage2;
    public int atk2;

    public int item1_2;
    public int item2_2;

    public int skill1_2;
    public int skill2_2;
    public int skill3_2;
    public int skill4_2;


    bool action = true;


    public void getActionGage()
    {
        npc.actiongage -= actiongage;
        
    }

    public float setActionGage()
    {
        return npc.actiongage;
    }

    


    // Use this for initialization
    void Start ()
    {
        npc.name[1] =name;
        npc.MaxHp[1] = MaxHp;
        npc.Hp[1] = Hp;
        npc.MaxMp[1] = MaxMp;
        npc.Mp[1] = Mp;
        npc.evasion[1] = evasion;
        npc.atk[1] = atk;

        npc.name[4] = name2;
        npc.MaxHp[4] = MaxHp2;
        npc.Hp[4] = Hp2;
        npc.MaxMp[4] = MaxMp2;
        npc.Mp[4] = Mp2;
        npc.evasion[4] = evasion2;
        npc.atk[4] = atk2;


    }
	
	// Update is called once per frame
	void Update ()
    {/*
        if (npc.actiongage >= 3.0f && action == true && Hp > 0)
        {
            Attak();
            Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
            Debug.Log(name + "은 " + npc.name[2] + "에게 " + damage + "를 가했다.");
            Debug.Log(npc.name[2] + "은 " + npc.Hp[2] + "가 남았다.");
            Debug.Log(action);
        }*/
    }
}
