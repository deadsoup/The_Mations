﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {


    public static string[] name = new string[6];
    public static int[] MaxHp = new int[6];
    public static int[] Hp = new int[6];
    public static int[] MaxMp = new int[6];
    public static int[] Mp = new int[6];
    public static int[] evasion = new int[6];
    public static int[] atk = new int[6];


    public static int[] huntCount = new int[6];

    public static int[] item1 = new int[6];
    public static int[] item2 = new int[6];

    public static int[] skill1 = new int[6];
    public static int[] skill2 = new int[6];
    public static int[] skill3 = new int[6];
    public static int[] skill4 = new int[6];
    





    public static float actiongage = 10.0f;
    public static float eActiongage = 10.0f;


    public static bool action = true;
    public static bool eAction;


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
