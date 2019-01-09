﻿using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SaveBattleScene : MonoBehaviour
{
    public List<BattleInfo> battleSave = new List<BattleInfo>();
    public List<BattleInfo> battleLoad = new List<BattleInfo>();

    private JsonData battle_Load_System;

    GameObject[] player = new GameObject[3];

    int Player1_ID;
    int Player2_ID;
    int Player3_ID;

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

        if (player[0].activeSelf == true)
        {
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
                    else { break; }
                }

                Debug.Log("포문");
            }
        }
        ///
        /// 플레이어 2의 스킬 저장
        ///
        if (player[1].activeSelf == true)
        {
            for (int i = 0; i < 15; i++)
            {
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
                    else if (P2_skillID[0] != -1 && P2_skillID[1] == -1)
                    {
                        P2_skillID[1] = i;
                        Debug.Log(1 + "번의 슬롯 스킬의 아이디는 :" + i);
                        Debug.Log(i + "번의 스킬은 현재 :" + P2_skilldata[i]);
                        continue;
                    }
                    else if (P2_skillID[0] != -1 && P2_skillID[1] != -1 && P2_skillID[2] == -1)
                    {
                        P2_skillID[2] = i;
                        Debug.Log(2 + "번의 슬롯 스킬의 아이디는 :" + i);
                        Debug.Log(i + "번의 스킬은 현재 :" + P2_skilldata[i]);
                        continue;
                    }
                    else { break; }

                }
            }
        }
        ///
        /// 플레이어 3의 스킬 저장
        ///
        if (player[2].activeSelf == true)
        {
            for (int i = 0; i < 15; i++)
            {
                if (Npc.SkillTriggers[battle.switching[2]].skill[i] == true)
                {
                    P1_skilldata[i] = Npc.SkillTriggers[battle.switching[2]].skill[i];
                    if (P3_skillID[0] == -1)
                    {
                        P3_skillID[0] = i;
                        Debug.Log(0 + "번의 슬롯 스킬의 아이디는 :" + i);
                        continue;
                    }
                    else if (P3_skillID[0] != -1 && P3_skillID[1] == -1)
                    {
                        P3_skillID[1] = i;
                        Debug.Log(1 + "번의 슬롯 스킬의 아이디는 :" + i);
                        Debug.Log(i + "번의 스킬은 현재 :" + P3_skilldata[i]);
                        continue;
                    }
                    else if (P3_skillID[0] != -1 && P3_skillID[1] != -1 && P3_skillID[2] == -1)
                    {
                        P3_skillID[2] = i;
                        Debug.Log(2 + "번의 슬롯 스킬의 아이디는 :" + i);
                        Debug.Log(i + "번의 스킬은 현재 :" + P3_skilldata[i]);
                        continue;
                    }
                    else { break; }
                }
            }
        }
        

        Debug.Log("저장");
        if (player[0].activeSelf == true)
        {
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
                        P1_skillID[2],
                        npc.SkillPoint
                        ));
        }
        else if (player[0].activeSelf == false)
        {
            battleSave.Add(new BattleInfo(9, "없음", 0, 0,0,0,0,0,
                        npc.ArchivePoint[0],
                        0,0,0 , 0,0,-1,0, 0, -1, 0, -1,0,0,0,0, npc.SkillPoint
                        ));

        }

        if (player[1].activeSelf == true)
        {
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
                                P2_skillID[2],
                                npc.SkillPoint
                                ));
        }
        else if (player[1].activeSelf == false)
        {
            battleSave.Add(new BattleInfo(9, "없음", 0, 0, 0, 0, 0, 0,
                        npc.ArchivePoint[0],
                        0, 0, 0, 0, 0, -1, 0, 0, -1, 0, -1, 0, 0, 0, 0, npc.SkillPoint
                        ));

        }


        if (player[2].activeSelf == true)
        {
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
                            P3_skillID[2],
                            npc.SkillPoint
                            ));
        }
        else if (player[2].activeSelf == false)
        {
            battleSave.Add(new BattleInfo(9, "없음", 0, 0, 0, 0, 0, 0,
                        npc.ArchivePoint[0],
                        0, 0, 0, 0, 0, -1, 0, 0, -1, 0, -1, 0, 0, 0, 0, npc.SkillPoint
                        ));

        }

        if (!Directory.Exists(Application.persistentDataPath + "/Json"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Json");
        }


        JsonData jsonData = JsonMapper.ToJson(battleSave);
        File.WriteAllText(Application.persistentDataPath + "/Json/battleSaveData.json", jsonData.ToString());


        // 통로맵씬 전환
        GameManager.instance.LoadPassaway();


    }

    public void loadJson()
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
                    (int)battle_Load_System[i]["Skill3_ID"],
                    (int)battle_Load_System[i]["SkillPoint"]
                    ));
        }
        //
        /// 
        battle.switching[0] = battleLoad[0].Id;// 캐릭터 슬롯의 데이터값을 캐릭터의 ID로 설정
        battle.switching[1] = battleLoad[1].Id;
        battle.switching[2] = battleLoad[2].Id;

        npc.SkillPoint = battleLoad[0].SkillPoint;

        npc.Equip_Str[battle.switching[0]] = 0; // 장비의 능력치를 0으로 바꾼다.
        npc.Equip_Wis[battle.switching[0]] = 0;

        Player1_ID = battleLoad[0].Id;
        Player2_ID = battleLoad[1].Id;
        Player3_ID = battleLoad[2].Id;

        if (player[1].activeSelf == true)
        {
            npc.Equip_Str[battle.switching[1]] = 0;
            npc.Equip_Wis[battle.switching[1]] = 0;
        }

        if (player[2].activeSelf == true)
        {
            npc.Equip_Str[battle.switching[2]] = 0;
            npc.Equip_Wis[battle.switching[2]] = 0;
        }


        for (int i = 0; i < battleLoad.Count; i++)
        {
            npc.Id[battle.switching[i]] = battleLoad[i].Id; // 능력치 호출
            npc.MaxHp[battle.switching[i]] = battleLoad[i].MaxHp;
            npc.Hp[battle.switching[i]] = battleLoad[i].Hp;
            npc.MaxMp[battle.switching[i]] = battleLoad[i].MaxMp;
            npc.Mp[battle.switching[i]] = battleLoad[i].Mp;
            npc.Str[battle.switching[i]] = battleLoad[i].Str;
            npc.Wis[battle.switching[i]] = battleLoad[i].Wis;
            npc.ArchivePoint[i] = battleLoad[i].ArchivePoint;
        }



        for (int Num = 0; Num < battleLoad.Count; Num++) // 0번 1번 2번
        {
            //인벤토리1번
            if (battleLoad[Num].Inven1 > 56) //
            {
                for (int i = 0; i < battleLoad[Num].Inven1_Amount; i++)
                {
                    if (Num == 0) inven.AddItem(battleLoad[Num].Inven1);
                    if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven1); }
                    if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven1); }
                    Debug.Log("아이템 생성");
                }
            }
            else if (battleLoad[Num].Inven1 == -1) { Debug.Log("아이템 없음"); }
            else
            {
                if (Num == 0) inven.AddItem(battleLoad[Num].Inven1);
                if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven1); }
                if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven1); }
                Debug.Log("아이템 생성");
            }


            //인벤토리2번
            if (battleLoad[Num].Inven2 > 56)
            {
                for (int i = 0; i < battleLoad[Num].Inven2_Amount; i++)
                {
                    if (Num == 0) inven.AddItem(battleLoad[Num].Inven2);
                    if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven2); }
                    if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven2); }
                    Debug.Log("아이템 생성2");
                }
            }
            else if (battleLoad[Num].Inven2 == -1) { Debug.Log("아이템 없음"); }
            else
            {
                if (Num == 0) inven.AddItem(battleLoad[Num].Inven2);
                if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven2); }
                if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven2); }
                Debug.Log("아이템 생성2");

            }


            //인벤토리3번
            if (battleLoad[Num].Inven3 > 56)
            {
                for (int i = 0; i < battleLoad[Num].Inven3_Amount; i++)
                {
                    if (Num == 0) inven.AddItem(battleLoad[Num].Inven3);
                    if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven3); }
                    if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven3); }
                    Debug.Log("아이템 생성3");
                }
            }
            else if (battleLoad[Num].Inven3 == -1) { Debug.Log("아이템 없음"); }
            else
            {
                if (Num == 0) inven.AddItem(battleLoad[Num].Inven3);
                if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven3); }
                if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven3); }
                Debug.Log("아이템 생성3");

            }


            //인벤토리4번
            if (battleLoad[Num].Inven4 > 56)
            {
                for (int i = 0; i < battleLoad[Num].Inven4_Amount; i++)
                {
                    if (Num == 0) inven.AddItem(battleLoad[Num].Inven4);
                    if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven4); }
                    if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven4); }
                    Debug.Log("아이템 생성4");
                }
            }
            else if (battleLoad[Num].Inven4 == -1) { Debug.Log("아이템 없음"); }
            else
            {
                if (Num == 0) inven.AddItem(battleLoad[Num].Inven4);
                if (Num == 1) { inven.AddItem2(battleLoad[Num].Inven4); }
                if (Num == 2) { inven.AddItem3(battleLoad[Num].Inven4); }
                Debug.Log("아이템 생성4");

            }
        }


        Debug.Log(battleLoad[0].Equip_Str);
        Debug.Log(npc.Equip_Str[battle.switching[0]]);
        //Debug.Log(battleLoad[0].Skill1_ID);

        for (int Num = 0; Num < battleLoad.Count; Num++)
        {
            if (Num == 0)
            {
                if (battleLoad[Num].Skill1_ID > -1)
                { Npc.SkillTriggers[battle.switching[0]].skill[battleLoad[Num].Skill1_ID] = true; }
                if (battleLoad[Num].Skill2_ID > -1)
                { Npc.SkillTriggers[battle.switching[0]].skill[battleLoad[Num].Skill2_ID] = true; }
                if (battleLoad[Num].Skill3_ID > -1)
                { Npc.SkillTriggers[battle.switching[0]].skill[battleLoad[Num].Skill3_ID] = true; }
            }
            if (player[1].activeSelf == true)
            {
                if (Num == 1)
                {
                    if (battleLoad[Num].Skill1_ID > -1)
                    { Npc.SkillTriggers[battle.switching[1]].skill[battleLoad[Num].Skill1_ID] = true; }
                    if (battleLoad[Num].Skill2_ID > -1)
                    { Npc.SkillTriggers[battle.switching[1]].skill[battleLoad[Num].Skill2_ID] = true; }
                    if (battleLoad[Num].Skill3_ID > -1)
                    { Npc.SkillTriggers[battle.switching[1]].skill[battleLoad[Num].Skill3_ID] = true; }
                }
            }
            if (player[2].activeSelf == true)
            {
                if (Num == 2)
                {
                    if (battleLoad[Num].Skill1_ID > -1)
                    { Npc.SkillTriggers[battle.switching[2]].skill[battleLoad[Num].Skill1_ID] = true; }
                    if (battleLoad[Num].Skill2_ID > -1)
                    { Npc.SkillTriggers[battle.switching[2]].skill[battleLoad[Num].Skill2_ID] = true; }
                    if (battleLoad[Num].Skill3_ID > -1)
                    { Npc.SkillTriggers[battle.switching[2]].skill[battleLoad[Num].Skill3_ID] = true; }
                }
            }

        }


        /*
        for (int Num = 0; Num < 10; Num++)
        {
            if (party.player[battle.switching[Num]] == true)
            {
                party.selectPlayer(battle.switching[Num]);

            }
        }
        */
    }

    void load()
    {
        string filePath = Application.persistentDataPath + "/Json/battleSaveData.json";
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
        battle_Load_System = JsonMapper.ToObject(jsonString);
    }


    public void playerSelect1(int Adebt)
    {
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            party.player[Adebt] = true;
            if (player[0].GetComponent<PlayerSlot1>().slotCharge == false)
            {
                GameObject Image = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
                Image.SetActive(true);
                player[0].GetComponent<PlayerSlot1>().slotCharge = true;
                battle.switching[0] = Adebt;
                player[0].transform.Find("Char1").GetComponent<Image>().sprite = party.CharSprite[Adebt];

                Battle.chaneGetta1();
            }
        }
    }

    public void playerSelect2(int Adebt)
    {
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            party.player[Adebt] = true;
            if (player[1].GetComponent<PlayerSlot1>().slotCharge == false)
            {
                GameObject Image = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
                Image.SetActive(true);
                player[1].GetComponent<PlayerSlot1>().slotCharge = true;
                battle.switching[1] = Adebt;
                player[1].transform.Find("Char1").GetComponent<Image>().sprite = party.CharSprite[Adebt];

                Battle.chaneGetta1();
            }
        }
    }

    public void playerSelect3(int Adebt)
    {
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            party.player[Adebt] = true;
            if (player[2].GetComponent<PlayerSlot1>().slotCharge == false)
            {
                GameObject Image = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
                Image.SetActive(true);
                player[2].GetComponent<PlayerSlot1>().slotCharge = true;
                battle.switching[2] = Adebt;
                player[2].transform.Find("Char1").GetComponent<Image>().sprite = party.CharSprite[Adebt];

                Battle.chaneGetta1();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("Canvas").transform.Find("Inven").GetComponent<Inven>();
        skill = GameObject.Find("SKillManager").GetComponent<SKillManager>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();

        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();
        }
    
        party = GameObject.Find("PartySystem").GetComponent<Party>();

        player[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
        player[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
        player[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;


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

        P2_skillID[0] = -1;
        P2_skillID[1] = -1;
        P2_skillID[2] = -1;

        P3_skillID[0] = -1;
        P3_skillID[1] = -1;
        P3_skillID[2] = -1;
        battle_Load_System = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/Json/battleSaveData.json"));
        //battle_Load_System = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/Json/battleSaveData.json"));
        //load();
        loadJson();
        print("현재 첫 캐릭터의 아이디는 무엇"+party.num);

        if (Directory.Exists(Application.persistentDataPath + "/Json") == true)
        {
            print("발동");
            playerSelect1(Player1_ID);
            playerSelect2(Player2_ID);
            playerSelect3(Player3_ID);

            if (Player1_ID == 9) { player[0].SetActive(false); }
            if (Player2_ID == 9) { player[1].SetActive(false); }
            if (Player3_ID == 9) { player[2].SetActive(false); }
        }
        //Battle.chaneGetta1();
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

    public int SkillPoint;

    public BattleInfo(int id, string name, int maxhp, int hp, int maxmp, int mp, int str, int wis, int archivepoint, int equip_maxhp, int equip_maxmp, int equip_str, int equip_wis,
                    int inven1, int inven1_amount, int inven2, int inven2_amount, int inven3, int inven3_amount, int inven4, int inven4_amount,
                    int skill1_id, int skill2_id, int skill3_id, int skillpoint)
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

        SkillPoint = skillpoint;

    }


}

