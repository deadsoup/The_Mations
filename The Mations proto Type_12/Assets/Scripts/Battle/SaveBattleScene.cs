using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveBattleScene : MonoBehaviour
{
    public List<BattleInfo> battleSave = new List<BattleInfo>();
    public List<BattleInfo> battleLoad = new List<BattleInfo>();

    private JsonData battle_Load_System;

    Party party;
    battle Battle;
    Inven inven;
    GameObject[] invenslot = new GameObject[12];
    GameObject[] Skillslot = new GameObject[3];
    SKillManager skill;
    npc Npc;
    //GameObject invenslot;

    int[] P1_skillID = new int[3];
    int[] P2_skillID = new int[3];
    int[] P3_skillID = new int[3];


    bool[] P1_skilldata = new bool[15];
    bool[] P2_skilldata = new bool[15];
    bool[] P3_skilldata = new bool[15];



    public void saveJson()
    {
        int invenslots1_ID = -1;
        int invenslots1_Amount = 0;

        int invenslots2_ID = -1;
        int invenslots2_Amount = 0;

        int invenslots3_ID = -1;
        int invenslots3_Amount = 0;

        int invenslots4_ID = -1;
        int invenslots4_Amount = 0;


        int P2_invenslots1_ID = -1;
        int P2_invenslots1_Amount = 0;

        int P2_invenslots2_ID = -1;
        int P2_invenslots2_Amount = 0;

        int P2_invenslots3_ID = -1;
        int P2_invenslots3_Amount = 0;

        int P2_invenslots4_ID = -1;
        int P2_invenslots4_Amount = 0;


        int P3_invenslots1_ID = -1;
        int P3_invenslots1_Amount = 0;

        int P3_invenslots2_ID = -1;
        int P3_invenslots2_Amount = 0;

        int P3_invenslots3_ID = -1;
        int P3_invenslots3_Amount = 0;

        int P3_invenslots4_ID = -1;
        int P3_invenslots4_Amount = 0;

        if (invenslot[0].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 1저장");
            invenslots1_ID = invenslot[0].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            invenslots1_Amount = invenslot[0].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[1].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 2저장");
            invenslots2_ID = invenslot[1].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            invenslots2_Amount = invenslot[1].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[2].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 3저장");
            invenslots3_ID = invenslot[2].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            invenslots3_Amount = invenslot[2].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[3].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 4저장");
            invenslots4_ID = invenslot[3].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            invenslots4_Amount = invenslot[3].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        //
        // 플레이어 2의 인벤 저장
        //
        if (invenslot[4].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 1저장");
            P2_invenslots1_ID = invenslot[4].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P2_invenslots1_Amount = invenslot[4].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[5].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 2저장");
            P2_invenslots2_ID = invenslot[5].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P2_invenslots2_Amount = invenslot[5].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[6].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 3저장");
            P2_invenslots3_ID = invenslot[6].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P2_invenslots3_Amount = invenslot[6].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[7].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 4저장");
            P2_invenslots4_ID = invenslot[7].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P2_invenslots4_Amount = invenslot[7].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        //
        // 플레이어 3의 인벤 저장
        //
        if (invenslot[8].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 1저장");
            P3_invenslots1_ID = invenslot[8].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P3_invenslots1_Amount = invenslot[8].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[9].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 2저장");
            P3_invenslots2_ID = invenslot[9].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P3_invenslots2_Amount = invenslot[9].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[10].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 3저장");
            P3_invenslots3_ID = invenslot[10].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P3_invenslots3_Amount = invenslot[10].transform.GetChild(0).GetComponent<ItemData>().amount;
        }
        if (invenslot[11].GetComponentInChildren<ItemData>() != null)
        {
            Debug.Log("인벤슬롯 4저장");
            P3_invenslots4_ID = invenslot[11].transform.GetChild(0).GetComponent<ItemData>().equip.Id;
            P3_invenslots4_Amount = invenslot[11].transform.GetChild(0).GetComponent<ItemData>().amount;
        }

        for (int i = 0; i < 15; i++)
        {
            if (Npc.SkillTriggers[battle.switching[0]].skill[i] == true)
            {
                P1_skilldata[i] = Npc.SkillTriggers[battle.switching[0]].skill[i];
                if (P1_skillID[0] == -1)
                {
                    P1_skillID[0] = i;
                    Debug.Log(0 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P1_skilldata[i]);
                    continue;
                }
                if (P1_skillID[0] != -1 && P1_skillID[1] == -1)
                {
                    P1_skillID[1] = i;
                    Debug.Log(1 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P1_skilldata[i]);
                    continue;
                }
                if (P1_skillID[0] != -1 && P1_skillID[1] != -1 && P1_skillID[2] == -1)
                {
                    P1_skillID[2] = i;
                    Debug.Log(2 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P1_skilldata[i]);
                    continue;
                }
                Debug.Log(i + "번의 스킬은 현재 :" + P1_skilldata[i]);
            }
            Debug.Log("포문");
            ///
            /// 플레이어 2의 스킬 저장
            ///
            if (Npc.SkillTriggers[battle.switching[1]].skill[i] == true)
            {
                P1_skilldata[i] = Npc.SkillTriggers[battle.switching[1]].skill[i];
                if (P2_skillID[0] == -1)
                {
                    P2_skillID[0] = i;
                    Debug.Log(0 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P2_skilldata[i]);
                    continue;
                }
                if (P2_skillID[0] != -1 && P2_skillID[1] == -1)
                {
                    P2_skillID[1] = i;
                    Debug.Log(1 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P2_skilldata[i]);
                    continue;
                }
                if (P2_skillID[0] != -1 && P2_skillID[1] != -1 && P2_skillID[2] == -1)
                {
                    P2_skillID[2] = i;
                    Debug.Log(2 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P2_skilldata[i]);
                    continue;
                }
            }
            ///
            /// 플레이어 3의 스킬 저장
            ///
            if (Npc.SkillTriggers[battle.switching[2]].skill[i] == true)
            {
                P1_skilldata[i] = Npc.SkillTriggers[battle.switching[2]].skill[i];
                if (P3_skillID[0] == -1)
                {
                    P3_skillID[0] = i;
                    Debug.Log(0 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P3_skilldata[i]);
                    continue;
                }
                if (P3_skillID[0] != -1 && P3_skillID[1] == -1)
                {
                    P3_skillID[1] = i;
                    Debug.Log(1 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P3_skilldata[i]);
                    continue;
                }
                if (P3_skillID[0] != -1 && P3_skillID[1] != -1 && P3_skillID[2] == -1)
                {
                    P3_skillID[2] = i;
                    Debug.Log(2 + "번의 슬롯 스킬의 아이디는 :" + i);
                    Debug.Log(i + "번의 스킬은 현재 :" + P3_skilldata[i]);
                    continue;
                }
            }
        }



        Debug.Log("저장");
        battleSave.Add(new BattleInfo(npc.Id[battle.switching[0]], npc.name[battle.switching[0]], npc.MaxHp[battle.switching[0]], npc.Hp[battle.switching[0]],
                        npc.MaxMp[battle.switching[0]], npc.Mp[battle.switching[0]], npc.Str[battle.switching[0]], npc.Wis[battle.switching[0]],
                        npc.ArchivePoint[0],
                        npc.Equip_MaxHp[battle.switching[0]], npc.Equip_MaxMp[battle.switching[0]], npc.Equip_Str[battle.switching[0]], npc.Equip_Wis[battle.switching[0]],
                        invenslots1_ID, invenslots1_Amount,
                        invenslots2_ID, invenslots2_Amount,
                        invenslots3_ID, invenslots3_Amount,
                        invenslots4_ID, invenslots4_Amount,
                        P1_skillID[0],
                        P1_skillID[1],
                        P1_skillID[2]
                        ));
        battleSave.Add(new BattleInfo(npc.Id[battle.switching[1]], npc.name[battle.switching[1]], npc.MaxHp[battle.switching[1]], npc.Hp[battle.switching[1]],
                            npc.MaxMp[battle.switching[1]], npc.Mp[battle.switching[1]], npc.Str[battle.switching[1]], npc.Wis[battle.switching[1]],
                            npc.ArchivePoint[0],
                            npc.Equip_MaxHp[battle.switching[1]], npc.Equip_MaxMp[battle.switching[1]], npc.Equip_Str[battle.switching[1]], npc.Equip_Wis[battle.switching[1]],
                            P2_invenslots1_ID, P2_invenslots1_Amount,
                            P2_invenslots2_ID, P2_invenslots2_Amount,
                            P2_invenslots3_ID, P2_invenslots3_Amount,
                            P2_invenslots4_ID, P2_invenslots4_Amount,
                            P2_skillID[0],
                            P2_skillID[1],
                            P2_skillID[2]
                            ));
        battleSave.Add(new BattleInfo(npc.Id[battle.switching[2]], npc.name[battle.switching[2]], npc.MaxHp[battle.switching[2]], npc.Hp[battle.switching[2]],
                            npc.MaxMp[battle.switching[2]], npc.Mp[battle.switching[2]], npc.Str[battle.switching[2]], npc.Wis[battle.switching[2]],
                            npc.ArchivePoint[0],
                            npc.Equip_MaxHp[battle.switching[2]], npc.Equip_MaxMp[battle.switching[2]], npc.Equip_Str[battle.switching[2]], npc.Equip_Wis[battle.switching[2]],
                            P3_invenslots1_ID, P3_invenslots1_Amount,
                            P3_invenslots2_ID, P3_invenslots2_Amount,
                            P3_invenslots3_ID, P3_invenslots3_Amount,
                            P3_invenslots4_ID, P3_invenslots4_Amount,
                            P3_skillID[0],
                            P3_skillID[1],
                            P3_skillID[2]
                            ));


        JsonData jsonData = JsonMapper.ToJson(battleSave);

        File.WriteAllText(Application.dataPath + "/battleSaveData.json", jsonData.ToString());

    }

    void loadJson()
    {
        for (int i = 0; i < battle_Load_System.Count; i++)
        {
            battleLoad.Add
                (new BattleInfo(
                    (int)battle_Load_System[i]["Id"],
                    battle_Load_System[i]["Name"].ToString(),
                    (int)battle_Load_System[i]["MaxHp"],
                    (int)battle_Load_System[i]["Hp"],
                    (int)battle_Load_System[i]["MaxMp"],
                    (int)battle_Load_System[i]["Mp"],
                    (int)battle_Load_System[i]["Str"],
                    (int)battle_Load_System[i]["Wis"],
                    (int)battle_Load_System[i]["ArchivePoint"],
                    (int)battle_Load_System[i]["Equip_MaxHp"],
                    (int)battle_Load_System[i]["Equip_MaxMp"],
                    (int)battle_Load_System[i]["Equip_Str"],
                    (int)battle_Load_System[i]["Equip_Wis"],
                    (int)battle_Load_System[i]["Inven1"],
                    (int)battle_Load_System[i]["Inven1_Amount"],
                    (int)battle_Load_System[i]["Inven2"],
                    (int)battle_Load_System[i]["Inven2_Amount"],
                    (int)battle_Load_System[i]["Inven3"],
                    (int)battle_Load_System[i]["Inven3_Amount"],
                    (int)battle_Load_System[i]["Inven4"],
                    (int)battle_Load_System[i]["Inven4_Amount"],
                    (int)battle_Load_System[i]["Skill1_ID"],
                    (int)battle_Load_System[i]["Skill2_ID"],
                    (int)battle_Load_System[i]["Skill3_ID"]
                    ));
        }
        npc.Id[battle.switching[0]] = battleLoad[0].Id;
        npc.MaxHp[battle.switching[0]] = battleLoad[0].MaxHp;
        npc.Hp[battle.switching[0]] = battleLoad[0].Hp;
        npc.MaxMp[battle.switching[0]] = battleLoad[0].MaxMp;
        npc.Mp[battle.switching[0]] = battleLoad[0].Mp;
        npc.Str[battle.switching[0]] = battleLoad[0].Str;
        npc.Wis[battle.switching[0]] = battleLoad[0].Wis;
        npc.ArchivePoint[0] = battleLoad[0].ArchivePoint;
        /*
        npc.Equip_MaxHp[battle.switching[0]] = battleLoad[0].Equip_MaxHp;
        npc.Equip_MaxMp[battle.switching[0]] = battleLoad[0].Equip_MaxMp;
        npc.Equip_Str[battle.switching[0]] = battleLoad[0].Equip_Str;
        npc.Equip_Wis[battle.switching[0]] = battleLoad[0].Equip_Wis;
        */

        if (battleLoad[0].Inven1 > 30)
        {
            for (int i = 0; i < battleLoad[0].Inven1_Amount; i++)
            {
                inven.AddItem(battleLoad[0].Inven1);
                Debug.Log("아이템 생성");
            }
        }
        else if (battleLoad[0].Inven1 == -1)
        {
            Debug.Log("아이템 없음");
        }
        else
        {
            inven.AddItem(battleLoad[0].Inven1);
            Debug.Log("아이템 생성");
        }

        if (battleLoad[0].Inven2 > 30)
        {
            for (int i = 0; i < battleLoad[0].Inven2_Amount; i++)
            {
                inven.AddItem(battleLoad[0].Inven2);
                Debug.Log("아이템 생성2");
            }
        }
        else if (battleLoad[0].Inven2 == -1)
        {
            Debug.Log("아이템 없음");
        }
        else
        {
            inven.AddItem(battleLoad[0].Inven2);
            Debug.Log("아이템 생성2");

        }

        if (battleLoad[0].Inven3 > 30)
        {
            for (int i = 0; i < battleLoad[0].Inven3_Amount; i++)
            {
                inven.AddItem(battleLoad[0].Inven3);
                Debug.Log("아이템 생성3");
            }
        }
        else if (battleLoad[0].Inven3 == -1)
        {
            Debug.Log("아이템 없음");
        }
        else
        {
            inven.AddItem(battleLoad[0].Inven3);
            Debug.Log("아이템 생성3");

        }


        if (battleLoad[0].Inven4 > 30)
        {
            for (int i = 0; i < battleLoad[0].Inven4_Amount; i++)
            {
                inven.AddItem(battleLoad[0].Inven4);
                Debug.Log("아이템 생성4");
            }
        }
        else if (battleLoad[0].Inven4 == -1)
        {
            Debug.Log("아이템 없음");
        }
        else
        {
            inven.AddItem(battleLoad[0].Inven4);
            Debug.Log("아이템 생성4");

        }



        Debug.Log(battleLoad[0].Skill1_ID);
        Debug.Log(battleLoad[0].Skill2_ID);
        Debug.Log(battleLoad[0].Skill3_ID);
        if (battleLoad[0].Skill1_ID > -1)
            Npc.SkillTriggers[0].skill[battleLoad[0].Skill1_ID] = true;
        if (battleLoad[0].Skill2_ID > -1)
            Npc.SkillTriggers[0].skill[battleLoad[0].Skill2_ID] = true;
        if (battleLoad[0].Skill3_ID > -1)
            Npc.SkillTriggers[0].skill[battleLoad[0].Skill3_ID] = true;

        if (party.player[battle.switching[0]] == true)
        {
            party.selectPlayer(0);

        }


    }




    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("Canvas").transform.Find("Inven").GetComponent<Inven>();
        skill = GameObject.Find("SKillManager").GetComponent<SKillManager>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();
        Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();
        party = GameObject.Find("PartySystem").GetComponent<Party>();

        invenslot[0] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots0").gameObject;
        invenslot[1] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots1").gameObject;
        invenslot[2] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots2").gameObject;
        invenslot[3] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots3").gameObject;

        invenslot[4] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel2").transform.Find("slots4").gameObject;
        invenslot[5] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel2").transform.Find("slots5").gameObject;
        invenslot[6] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel2").transform.Find("slots6").gameObject;
        invenslot[7] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel2").transform.Find("slots7").gameObject;

        invenslot[8] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel3").transform.Find("slots8").gameObject;
        invenslot[9] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel3").transform.Find("slots9").gameObject;
        invenslot[10] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel3").transform.Find("slots10").gameObject;
        invenslot[11] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel3").transform.Find("slots11").gameObject;



        Skillslot[0] = GameObject.Find("Canvas").transform.Find("SkillSlot").transform.Find("Panel").transform.Find("slotPanel").transform.Find("skillSlot2").gameObject;
        Skillslot[1] = GameObject.Find("Canvas").transform.Find("SkillSlot").transform.Find("Panel").transform.Find("slotPanel").transform.Find("skillSlot3").gameObject;
        Skillslot[2] = GameObject.Find("Canvas").transform.Find("SkillSlot").transform.Find("Panel").transform.Find("slotPanel").transform.Find("skillSlot4").gameObject;

        P1_skillID[0] = -1;
        P1_skillID[1] = -1;
        P1_skillID[2] = -1;

        battle_Load_System = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/battleSaveData.json"));

        loadJson();
        Battle.chaneGetta1();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Keypad6))
        // {
        // saveJson();
        //}
    }

}
[System.Serializable]
public class BattleInfo // 캐릭터 슬롯칸에 저장시킬 것
{
    public int Id; // 저장시킬 캐릭터의 아이디
    public string Name; // 캐릭터의 명칭
    public int MaxHp; // 캐릭터의 최대 체력
    public int Hp; // 캐릭터의 체력
    public int MaxMp;
    public int Mp;
    public int Str;
    public int Wis;
    public int ArchivePoint; // 플레이어의 소지 업적 포인트 [0]에다 저장함

    public int Equip_MaxHp;
    public int Equip_MaxMp;
    public int Equip_Str;
    public int Equip_Wis;

    public int Inven1;
    public int Inven1_Amount;

    public int Inven2;
    public int Inven2_Amount;

    public int Inven3;
    public int Inven3_Amount;

    public int Inven4;
    public int Inven4_Amount;

    public int Skill1_ID;
    //public bool Skill1_Active;

    public int Skill2_ID;
    //public bool Skill2_Active;

    public int Skill3_ID;
    //public bool Skill3_Active;
    public BattleInfo(int id, string name, int maxhp, int hp, int maxmp, int mp, int str, int wis, int archivepoint, int equip_maxhp, int equip_maxmp, int equip_str, int equip_wis,
                    int inven1, int inven1_amount, int inven2, int inven2_amount, int inven3, int inven3_amount, int inven4, int inven4_amount,
                    int skill1_id, int skill2_id, int skill3_id)
    {
        Id = id;
        Name = name;
        MaxHp = maxhp;
        Hp = hp;
        MaxMp = maxmp;
        Mp = mp;
        Str = str;
        Wis = wis;
        ArchivePoint = archivepoint; // 플레이어의 소지 업적 포인트 [0]에다 저장함

        Equip_MaxHp = equip_maxhp;
        Equip_MaxMp = equip_maxmp;
        Equip_Str = equip_str;
        Equip_Wis = equip_wis;

        Inven1 = inven1;
        Inven1_Amount = inven1_amount;

        Inven2 = inven2;
        Inven2_Amount = inven2_amount;

        Inven3 = inven3;
        Inven3_Amount = inven3_amount;

        Inven4 = inven4;
        Inven4_Amount = inven4_amount;

        Skill1_ID = skill1_id;
        //Skill1_Active = skill1_active;

        Skill2_ID = skill2_id;
        //Skill2_Active = skill2_active;

        Skill3_ID = skill3_id;
        //Skill3_Active = skill3_active;

    }


}

