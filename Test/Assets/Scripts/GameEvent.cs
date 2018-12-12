using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {



    public static void hpMpRegen() // 10% 회복
    {
        Debug.Log((int)(npc.MaxHp[1] * 0.1f) + "체력 회복 ");
        Debug.Log(npc.Hp[1] + "체력 존재 ");
        npc.Hp[1] += (int)(npc.MaxHp[1] * 0.1f);
        npc.Mp[1] += (int)(npc.MaxMp[1] * 0.1f);
        if (npc.Hp[1] >= npc.MaxHp[1]) { npc.Hp[1] = npc.MaxHp[1]; }
        if (npc.Mp[1] >= npc.MaxMp[1]) { npc.Mp[1] = npc.MaxMp[1]; }


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
