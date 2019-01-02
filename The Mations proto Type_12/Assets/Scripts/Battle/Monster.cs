using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;


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
    public int ArchivePoint;

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
    public int ArchivePoint2;


    [System.Serializable]
    class MonsterScript
    {
        public MonsterScriptData[] data;
    }

    [System.Serializable]
    class MonsterScriptData
    {
        public int Id;
        public string Name;
        public int MaxHp;
        public int Hp;
        public int MaxMp;
        public int Mp;
        public int evasion;
        public int atk;
    }

    MonsterScript monster;

    private void Awake()
    {
        monster = JsonUtility.FromJson<MonsterScript>(File.ReadAllText(Application.dataPath + "/PlayerInfoData.json"));
    }



    // Use this for initialization
    void Start ()
    {
        
        npc.name[10] = name;
        npc.MaxHp[10] = MaxHp;
        npc.Hp[10] = Hp;
        npc.MaxMp[10] = MaxMp;
        npc.Mp[10] = Mp;
        npc.atk[10] = atk;
        npc.ArchivePoint[10] = ArchivePoint;

        npc.huntCount[11] = huntCount;
        
        npc.name[11] = name2;
        npc.MaxHp[11] = MaxHp2;
        npc.Hp[11] = Hp2;
        npc.MaxMp[11] = MaxMp2;
        npc.Mp[11] = Mp2;
        npc.atk[11] = atk2;
        npc.ArchivePoint[11] = ArchivePoint2;

        npc.huntCount[11] = huntCount2;


    }
	

	void Update ()
    { 
	}
}
