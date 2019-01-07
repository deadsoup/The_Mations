using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {


    public GameObject battle;
    public GameObject battlebutton;


    public static void hpMpRegen() // 10% 회복
    {
        Debug.Log((int)(npc.MaxHp[0] * 0.1f) + "체력 회복 ");
        Debug.Log(npc.Hp[0] + "체력 존재 ");
        npc.Hp[0] += (int)(npc.MaxHp[0] * 0.1f);
        npc.Mp[0] += (int)(npc.MaxMp[0] * 0.1f);
        if (npc.Hp[0] >= npc.MaxHp[0]) { npc.Hp[0] = npc.MaxHp[0]; }
        if (npc.Mp[0] >= npc.MaxMp[0]) { npc.Mp[0] = npc.MaxMp[0]; }


    }

    public  void battleStart()
    {
        battle.SetActive(true);
        battlebutton.SetActive(false);
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
