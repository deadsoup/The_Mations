using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class Monster : MonoBehaviour {

    
    [Header("1번 몬스터")]
    public string name;
    public int MaxHp;
    public int Hp;
    public int MaxMp;
    public int Mp;
    public int evasion;
    public float actiongage;
    public int atk;

    public int huntCount;


    [Header("2번 몬스터")]
    public string name2;
    public int MaxHp2;
    public int Hp2;
    public int MaxMp2;
    public int Mp2;
    public int evasion2;
    public float actiongage2;
    public int atk2;

    public int huntCount2;




    // Use this for initialization
    void Start ()
    {
        
        npc.name[2] = name;
        npc.MaxHp[2] = MaxHp;
        npc.Hp[2] = Hp;
        npc.MaxMp[2] = MaxMp;
        npc.Mp[2] = Mp;
        npc.evasion[2] = evasion;
        npc.atk[2] = atk;

        npc.huntCount[2] = huntCount;

        npc.name[3] = name2;
        npc.MaxHp[3] = MaxHp2;
        npc.Hp[3] = Hp2;
        npc.MaxMp[3] = MaxMp2;
        npc.Mp[3] = Mp2;
        npc.evasion[3] = evasion2;
        npc.atk[3] = atk2;

        npc.huntCount[3] = huntCount2;


    }
	

	void Update ()
    { 
	}
}
