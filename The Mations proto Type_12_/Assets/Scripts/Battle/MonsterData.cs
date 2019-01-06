using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
using System;
using System.IO;

public class MonsterData : MonoBehaviour
{
    public List<Monster> MonsterList = new List<Monster>();
    public JsonData MonsterDatabase;

    void load()
    {
        string filePath = Application.streamingAssetsPath + "/MonsterScriptData.json";
        string jsonString;
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            jsonString = reader.text;
        }
        else
        {
            jsonString = File.ReadAllText(filePath);
        }
        MonsterDatabase = JsonMapper.ToObject(jsonString);
    }



    private void Start()
    {
        Debug.Log("느그 이름은 " + npc.name[(0 + 10)]);
        //MonsterDatabase = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/Json/MonsterScriptData.json"));
        load();
        ContructMonsterDatabase();
        UpdateMobdata();
        Debug.Log("느그 이름은 " + npc.name[(0 + 10)]);
    }

    void ContructMonsterDatabase()
    {
        for (int i = 0; i < MonsterDatabase.Count; i++)
        {
            MonsterList.Add
                (new Monster(
                    (int)MonsterDatabase[i]["ID"],
                    MonsterDatabase[i]["Name"].ToString(),
                    (int)MonsterDatabase[i]["MaxHp"],
                    (int)MonsterDatabase[i]["Hp"],
                    (int)MonsterDatabase[i]["MaxMp"],
                    (int)MonsterDatabase[i]["Mp"],
                    (int)MonsterDatabase[i]["atk"],
                    (int)MonsterDatabase[i]["ArchivePoint"],
                    MonsterDatabase[i]["SP_Idle"].ToString()
                    ));


        }
    }

    void UpdateMobdata()
    {
        for (int i = 0; i < MonsterList.Count; i++)
        {
            npc.name[(i+10)] = MonsterList[i].Name;
            npc.MaxHp[(i + 10)] = MonsterList[i].MaxHp;
            npc.Hp[(i + 10)] = MonsterList[i].Hp;
            npc.MaxMp[(i + 10)] = MonsterList[i].MaxMp;
            npc.Mp[(i + 10)] = MonsterList[i].Mp;
            npc.atk[(i + 10)] = MonsterList[i].Atk;
            npc.ArchivePoint[(i + 10)] = MonsterList[i].ArchivePoint;


        }

    }



}

[System.Serializable]
public class Monster
{

    public int Id;
    public string Name;
    public int MaxHp;
    public int Hp;
    public int MaxMp;
    public int Mp;
    public int Atk;
    public int ArchivePoint;
    public string SP_Idle;


    public Sprite idle;
    public Sprite dead;


    public Monster(int id, string name, int maxhp, int hp, int maxmp, int mp, int atk, int archivepoint, string sp_idle)
    {
        Id = id;
        Name = name;
        MaxHp = maxhp;
        Hp = hp;
        MaxMp = maxmp;
        Mp = mp;
        Atk = atk;
        ArchivePoint = archivepoint;
        SP_Idle = sp_idle;

        idle = Resources.Load<Sprite>("Battle_Resource/Monster/" + Id);
        dead = Resources.Load<Sprite>("Battle_Resource/Monster/" + Id);

    }

}
