using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour {


    public static int[] Id = new int[6];
    public static string[] name = new string[6];
    public static int[] MaxHp = new int[6];
    public static int[] Hp = new int[6];
    public static int[] MaxMp = new int[6];
    public static int[] Mp = new int[6];
    public static int[] Str = new int[6];
    public static int[] Dex = new int[6];
    public static int[] Wis = new int[6];



    public static int[] atk = new int[6];


    public static int[] huntCount = new int[6];

    public static int[] item1 = new int[6];
    public static int[] item2 = new int[6];

    public static int[] skill1 = new int[6];
    public static int[] skill2 = new int[6];
    public static int[] skill3 = new int[6];
    public static int[] skill4 = new int[6];

    public static List<int> Equip_MaxHp = new List<int>();
    public static List<int> Equip_MaxMp = new List<int>();
    public static List<int> Equip_Str = new List<int>();
    public static List<int> Equip_Dex = new List<int>();
    public static List<int> Equip_Wis = new List<int>();

    ItemDatabase database;








    public static float actiongage = 10.0f;
    public static float eActiongage = 10.0f;


    public static bool action = true;
    public static bool eAction;


    // Use this for initialization
    void Start ()
    {
        database = GetComponent<ItemDatabase>();
        Debug.Log(database.database[1].Str);

    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
