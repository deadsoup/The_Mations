using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

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



    [System.Serializable]
    class PlayerScript
    {
        public PlayerScripttData[] data;
    }

    [System.Serializable]
    class PlayerScripttData
    {
        public int Id;
        public string Name;
        public int MaxHp;
        public int Hp;
        public int MaxMp;
        public int Mp;
        public int Str;
        public int Dex;
        public int Wis;
    }

    PlayerScript player;




    /*
    public void getActionGage()
    {
        npc.actiongage -= actiongage;
        
    }

    public float setActionGage()
    {
        return npc.actiongage;
    }
    */


    void Awake()
    {
        player = JsonUtility.FromJson<PlayerScript>(File.ReadAllText(Application.dataPath + "/PlayerInfoData.json"));
    }
    // Use this for initialization
    void Start ()
    {
        npc.Id[0] = player.data[0].Id;
        npc.name[0] = player.data[0].Name;
        npc.MaxHp[0] = player.data[0].MaxHp;
        npc.Hp[0] = player.data[0].Hp;
        npc.MaxMp[0] = player.data[0].MaxMp;
        npc.Mp[0] = player.data[0].Mp;
        npc.Str[0] = player.data[0].Str;
        npc.Dex[0] = player.data[0].Dex;
        npc.Wis[0] = player.data[0].Wis;




        npc.Id[1] = player.data[1].Id;
        npc.name[1] = player.data[1].Name;
        npc.MaxHp[1] = player.data[1].MaxHp;
        npc.Hp[1] = player.data[1].Hp;
        npc.MaxMp[1] = player.data[1].MaxMp;
        npc.Mp[1] = player.data[1].Mp;
        npc.Str[1] = player.data[1].Str;
        npc.Dex[1] = player.data[1].Dex;
        npc.Wis[1] = player.data[1].Wis;




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
