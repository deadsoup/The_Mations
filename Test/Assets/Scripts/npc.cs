﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct UnitCondition
{
    public bool condition_Stun;
    public int left_Stun;

    public bool condition_Sleep;
    public int left_Sleep;
}

public class npc : MonoBehaviour {


    public static int[] Id = new int[50];
    public static string[] name = new string[50];
    public static int[] MaxHp = new int[50];
    public static int[] Hp = new int[50];
    public static int[] MaxMp = new int[50];
    public static int[] Mp = new int[50];
    public static int[] Str = new int[50];
    public static int[] Dex = new int[50];
    public static int[] Wis = new int[50];



    public static int[] atk = new int[50];


    public static int[] huntCount = new int[50];

    public static int[] item1 = new int[6];
    public static int[] item2 = new int[6];

    public struct skillTrigger
    {
        public bool[] skill; // 스킬의 개수
    }

    skillTrigger SkillTrigger;
    public skillTrigger[] SkillTriggers = new skillTrigger[6]; // 캐릭터의 보유 스킬 

    public static int[] Equip_MaxHp = new int[6];
    public static int[] Equip_MaxMp = new int[6];
    public static int[] Equip_Str = new int[6];
    public static int[] Equip_Dex = new int[6];
    public static int[] Equip_Wis = new int[6];

    public  static UnitCondition[] unitCondition = new UnitCondition[50];

    

    

    //\uC544\uB9AC\uC218 아리수


    public static float actiongage = 10.0f;
    public static float eActiongage = 10.0f;


    public static bool action = true;
    public static bool eAction;

    public void skillon()
    {
        for (int i = 0; i < SkillTriggers.Length; i++)
        {
            SkillTriggers[i].skill = new bool[15];
            if (i == 6)
            {
                break;
            }
        }
    }


    // Use this for initialization
    void Start ()
    {
        skillon();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
