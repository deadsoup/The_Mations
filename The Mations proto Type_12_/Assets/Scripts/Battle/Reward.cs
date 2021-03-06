﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Reward : MonoBehaviour
{
    GameObject Rewardpanel;
    GameObject Slotpanel;


    GameObject[] player = new GameObject[3];


    RewardDatabase rewardBase;
    battle Battle;
    npc Npc;
    Inven inven;
    SKillManager skill;
    GameObject AchievementsText;
    public GameObject RewardSlot;
    public GameObject RewardItem;

    int slotAmount;
    

    public List<Equip> rewardItems = new List<Equip>();
    public List<GameObject> slots = new List<GameObject>();

    public static int reward1, reward2, reward3, skillreward1, skillreward2, skillreward3;

    public GameObject add1, add2, add3;
    public GameObject Panel1, Panel2, Panel3;

    // 스킬 보상
    int SKillslotAmount;

    public GameObject S_RewardSlot;
    public GameObject RewardSkill;

    public List<Skill> rewardSkills = new List<Skill>();
    public List<GameObject> skillslots = new List<GameObject>();

    public GameObject skilladd1, skilladd2, skilladd3;
    public GameObject Panel4, Panel5, Panel6;

    void Start()
    {

        player[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
        player[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
        player[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;
        slotAmount = 3;
        SKillslotAmount = 3;
        /*
        reward1 = Random.Range(1, 6); reward2 = Random.Range(1, 6); reward3 = Random.Range(1, 6); reward4 = Random.Range(1, 6);
        reward5 = Random.Range(1, 6); reward6 = Random.Range(1, 6); reward7 = Random.Range(1, 6); reward8 = Random.Range(1, 6); reward9 = Random.Range(1, 6);*/

        rewardBase = GetComponent<RewardDatabase>();


        AchievementsText = GameObject.Find("Canvas").transform.Find("Reward").transform.Find("RewardPanel").transform.Find("Achive").transform.Find("Text").gameObject;
        inven = GameObject.Find("Canvas").transform.Find("Inven").GetComponent<Inven>();
        skill =GameObject.Find("SKillManager").GetComponent<SKillManager>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();
        Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();

        Rewardpanel = GameObject.Find("Canvas").transform.Find("Reward").transform.Find("RewardPanel").gameObject;
        Slotpanel = Rewardpanel.transform.Find("Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            rewardItems.Add(new Equip());
            slots.Add(Instantiate(RewardSlot));
            slots[i].GetComponent<slot>().id = i;
            slots[i].name = "RewardSlots" + i.ToString();
            slots[i].transform.SetParent(Slotpanel.transform);

            rewardSkills.Add(new Skill());
            skillslots[i].GetComponent<skillSlot>().id = i;

        }

        /*
        for (int i = 0; i < rewardItems.Count; i++)
        {
            deleteItem(i);
        }
        */
    }

    void Update()
    {
        addadd();
        
        
    }

    public void addadd()
    {
        if (battle.reItems == 1)
        {
            //몬스터 수 만큼 설정한다.
            if (battle.i == 0)
            {
                int item_per = 30;
                int item_per2 = 30;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(0);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(1);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(54);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 5;
                int per2 = 5;
                int per3 = 0;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(skillreward3);
                }
            }
            if (battle.i == 1)
            {
                int item_per = 30;
                int item_per2 = 30;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(31);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(32);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 5;
                int per2 = 5;
                int per3 = 0;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(skillreward3);
                }
            }
            if (battle.i == 2)
            {
                int item_per = 15;
                int item_per2 = 15;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(4);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(54);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 5;
                int per2 = 5;
                int per3 = 0;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(skillreward3);
                }
            }
            if (battle.i == 3)
            {
                int item_per = 20;
                int item_per2 = 15;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(5);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(53);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 8;
                int per2 = 8;
                int per3 = 5;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(2);
                }
            }
            if (battle.i == 4)
            {
                int item_per = 25;
                int item_per2 = 20;
                int item_per3 = 20;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(34);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(52);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(54);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 5;
                int per2 = 5;
                int per3 = 5;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(3);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(4);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(5);
                }
            }
            if (battle.i == 5)
            {
                int item_per = 30;
                int item_per2 = 20;
                int item_per3 = 30;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(6);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(35);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(37);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 13;
                int per2 = 10;
                int per3 = 8;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(8);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(3);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(5);
                }
            }
            if (battle.i == 6)
            {
                int item_per = 15;
                int item_per2 = 15;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(2);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(53);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 5;
                int per2 = 5;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
            }
            if (battle.i == 7)
            {
                int item_per = 20;
                int item_per2 = 15;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(1);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(53);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 5;
                int per2 = 5;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
            }
            if (battle.i == 8)
            {
                int item_per = 20;
                int item_per2 = 15;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(3);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(53);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 8;
                int per2 = 8;
                int per3 = 5;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(2);
                }
            }
            if (battle.i == 9)
            {
                int item_per = 20;
                int item_per2 = 20;
                int item_per3 = 20;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(7);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(52);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(54);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 8;
                int per2 = 5;
                int per3 = 5;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(2);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(3);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(4);
                }
            }
            if (battle.i == 10)
            {
                int item_per = 10;
                int item_per2 = 20;
                int item_per3 = 15;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(4);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(33);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(51);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 10;
                int per2 = 10;
                int per3 = 8;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(0);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(1);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(5);
                }
            }
            if (battle.i == 11)
            {
                int item_per = 20;
                int item_per2 = 25;
                int item_per3 = 20;

                if (item_per >= Random.Range(1, 101))
                {
                    AddItem(34);
                }
                if (item_per2 >= Random.Range(1, 101))
                {
                    AddItem(36);
                }
                if (item_per3 >= Random.Range(1, 101))
                {
                    AddItem(35);
                }

                add1.SetActive(true);
                add2.SetActive(true);
                add3.SetActive(true);

                int per = 20;
                int per2 = 10;
                int per3 = 10;

                /// 스킬 드랍 확률
                if (per >= Random.Range(1, 101))
                {
                    AddSkill(2);
                }
                if (per2 >= Random.Range(1, 101))
                {
                    AddSkill(3);
                }
                if (per3 >= Random.Range(1, 101))
                {
                    AddSkill(5);
                }
            }
            AchievementsText.GetComponent<Text>().text = "획득 업적포인트 : " + npc.ArchivePoint[battle.i];

            battle.reItems = 0;
        }
    }

    /// <summary>
    /// 아이템 전달
    /// </summary>
    public void charAddItem_slot1() // 보상 1슬롯의 플레이어1 전달
    {if (player[0].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if (inven.items[i].Id == -1)
                {
                    charAddItem("RewardSlots0");
                    inven.AddItem(reward1);
                    add1.SetActive(false);
                    break;
                }
                if (inven.items[i].Id != -1)
                {
                    add1.SetActive(true);
                }
            }
        }
    }
    public void char2AddItem_slot1()// 보상 1슬롯의 플레이어2 전달
    {
        if (player[1].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items2.Count; i++)
            {
                if (inven.items2[i].Id == -1)
                {
                    charAddItem("RewardSlots0");
                    inven.AddItem2(reward1);
                    add1.SetActive(false);
                    break;
                }
                if (inven.items2[i].Id != -1)
                {
                    add1.SetActive(true);
                }
            }
        }
    }
    public void char3AddItem_slot1()// 보상 1슬롯의 플레이어3 전달
    {
        if (player[2].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items3.Count; i++)
            {
                if (inven.items3[i].Id == -1)
                {
                    charAddItem("RewardSlots0");
                    inven.AddItem3(reward1);
                    add1.SetActive(false);
                    break;
                }
                if (inven.items3[i].Id != -1)
                {
                    add1.SetActive(true);
                }
            }
        }
    }
    /// <summary>
    /// ////////////
    /// </summary>
    public void charAddItem_slot2()// 보상 2슬롯의 플레이어1 전달
    {
        if (player[0].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].Id == -1)
            {
                charAddItem("RewardSlots1");
                inven.AddItem(reward2);
                add2.SetActive(false);
                break;
            }
                if (inven.items[i].Id != -1)
                {
                    add2.SetActive(true);

                }
            }
        }
    }
    public void char2AddItem_slot2()// 보상 2슬롯의 플레이어2 전달
    {
        if (player[1].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items2.Count; i++)
            {
                if (inven.items2[i].Id == -1)
                {
                    charAddItem("RewardSlots1");
                    inven.AddItem2(reward2);
                    add2.SetActive(false);
                    break;
                }
                if (inven.items2[i].Id != -1)
                {
                    add2.SetActive(true);
                }
            }
        }
    }
    public void char3AddItem_slot2()// 보상 2슬롯의 플레이어3 전달
    {
        if (player[2].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items3.Count; i++)
            {
                if (inven.items3[i].Id == -1)
                {
                    charAddItem("RewardSlots1");
                    inven.AddItem3(reward2);
                    add2.SetActive(false);
                    break;
                }
                if (inven.items3[i].Id != -1)
                {
                    add2.SetActive(true);
                }
            }
        }
    }
    /// <summary>
    /// //////////////
    /// </summary>
    public void charAddItem_slot3()// 보상 3슬롯의 플레이어1 전달
    {
        if (player[0].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items.Count; i++)
            {
                if (inven.items[i].Id == -1)
                {
                    charAddItem("RewardSlots2");
                    inven.AddItem(reward3);
                    add3.SetActive(false);
                    break;
                }
                if (inven.items[i].Id != -1)
                {
                    add3.SetActive(true);
                }
            }
        }
    }
    public void char2AddItem_slot3()// 보상 3슬롯의 플레이어2 전달
    {
        if (player[1].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items2.Count; i++)
            {
                if (inven.items2[i].Id == -1)
                {
                    charAddItem("RewardSlots2");
                    inven.AddItem2(reward3);
                    add3.SetActive(false);
                    break;
                }
                if (inven.items2[i].Id != -1)
                {
                    add3.SetActive(true);
                }
            }
        }
    }
    public void char3AddItem_slot3()// 보상 3슬롯의 플레이어3 전달
    {
        if (player[2].activeInHierarchy == true)
        {
            for (int i = 0; i < inven.items3.Count; i++)
            {
                if (inven.items3[i].Id == -1)
                {
                    charAddItem("RewardSlots2");
                    inven.AddItem3(reward3);
                    add3.SetActive(false);
                    break;
                }
                if (inven.items3[i].Id != -1)
                {
                    add3.SetActive(true);
                }
            }
        }
    }



    public void charAddSkill_slot(int num)
    {
        if (player[0].activeInHierarchy == true)
        {
            if (num == 1)
            {
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {
                        if (Npc.SkillTriggers[battle.switching[0]].skill[skillreward1] == true)
                        {
                            skilladd1.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot");
                            Npc.SkillTriggers[battle.switching[0]].skill[skillreward1] = true;
                            if (battle.switching[0] == battle.c && npc.Hp[battle.switching[0]] > 0)
                            {
                                skill.AddSkill(skillreward1);
                                Debug.Log(skillreward1);
                            }
                            skilladd1.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd1.SetActive(true);
                    }
                }
            }
            if (num == 2)
            {
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {

                        if (Npc.SkillTriggers[battle.switching[0]].skill[skillreward2] == true)
                        {
                            skilladd2.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot1");
                            Npc.SkillTriggers[battle.switching[0]].skill[skillreward2] = true;
                            if (battle.switching[0] == battle.c && npc.Hp[battle.switching[0]] > 0)
                            {
                                skill.AddSkill(skillreward2);
                                Debug.Log(skillreward2);
                            };
                            skilladd2.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd2.SetActive(true);
                    }
                }
            }
            if (num == 3)
            {
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {

                        if (Npc.SkillTriggers[battle.switching[0]].skill[skillreward3] == true)
                        {
                            skilladd3.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot2");
                            Npc.SkillTriggers[battle.switching[0]].skill[skillreward3] = true;
                            if (battle.switching[0] == battle.c && npc.Hp[battle.switching[0]] > 0)
                            {
                                skill.AddSkill(skillreward3);
                                Debug.Log(skillreward3);
                            }
                            skilladd3.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd3.SetActive(true);
                    }
                }
            }
        }

        if (player[1].activeInHierarchy == true)
        {
            if (num == 4)
            {
                Battle.chaneGetta2();
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {
                        if (Npc.SkillTriggers[battle.switching[1]].skill[skillreward1] == true)
                        {
                            skilladd1.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot");
                            Npc.SkillTriggers[battle.switching[1]].skill[skillreward1] = true;
                            if (battle.switching[1] == battle.c && npc.Hp[battle.switching[1]] > 0)
                            {
                                skill.AddSkill(skillreward1);
                                Debug.Log(skillreward1);
                            }
                            skilladd1.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd1.SetActive(true);
                    }
                }
            }
            if (num == 5)
            {
                Battle.chaneGetta2();
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {

                        if (Npc.SkillTriggers[battle.switching[1]].skill[skillreward2] == true)
                        {
                            skilladd2.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot1");
                            Npc.SkillTriggers[battle.switching[1]].skill[skillreward2] = true;
                            if (battle.switching[1] == battle.c && npc.Hp[battle.switching[1]] > 0)
                            {
                                skill.AddSkill(skillreward2);
                                Debug.Log(skillreward2);
                            };
                            skilladd2.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd2.SetActive(true);
                    }
                }
            }
            if (num == 6)
            {
                Battle.chaneGetta2();
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {

                        if (Npc.SkillTriggers[battle.switching[1]].skill[skillreward3] == true)
                        {
                            skilladd3.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot2");
                            Npc.SkillTriggers[battle.switching[1]].skill[skillreward3] = true;
                            if (battle.switching[1] == battle.c && npc.Hp[battle.switching[1]] > 0)
                            {
                                skill.AddSkill(skillreward3);
                                Debug.Log(skillreward3);
                            }
                            skilladd3.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd3.SetActive(true);
                    }
                }
            }
        }

        if (player[2].activeInHierarchy == true)
        {
            if (num == 7)
            {
                Battle.chaneGetta3();
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {
                        if (Npc.SkillTriggers[battle.switching[2]].skill[skillreward1] == true)
                        {
                            skilladd1.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot");
                            Npc.SkillTriggers[battle.switching[2]].skill[skillreward1] = true;
                            if (battle.switching[2] == battle.c && npc.Hp[battle.switching[2]] > 0)
                            {
                                skill.AddSkill(skillreward1);
                                Debug.Log(skillreward1);
                            }
                            skilladd1.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd1.SetActive(true);
                    }
                }
            }
            if (num == 8)
            {
                Battle.chaneGetta3();
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {

                        if (Npc.SkillTriggers[battle.switching[2]].skill[skillreward2] == true)
                        {
                            skilladd2.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot1");
                            Npc.SkillTriggers[battle.switching[2]].skill[skillreward2] = true;
                            if (battle.switching[2] == battle.c && npc.Hp[battle.switching[2]] > 0)
                            {
                                skill.AddSkill(skillreward2);
                                Debug.Log(skillreward2);
                            };
                            skilladd2.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd2.SetActive(true);
                    }
                }
            }
            if (num == 9)
            {
                Battle.chaneGetta3();
                for (int i = 0; i < skill.skills.Count; i++)
                {
                    if (skill.skills[i].Id == -1)
                    {

                        if (Npc.SkillTriggers[battle.switching[2]].skill[skillreward3] == true)
                        {
                            skilladd3.SetActive(true);
                            break;
                        }
                        else
                        {
                            charAddskill("S_rewardSlot2");
                            Npc.SkillTriggers[battle.switching[2]].skill[skillreward3] = true;
                            if (battle.switching[2] == battle.c && npc.Hp[battle.switching[2]] > 0)
                            {
                                skill.AddSkill(skillreward3);
                                Debug.Log(skillreward3);
                            }
                            skilladd3.SetActive(false);
                            break;
                        }
                    }
                    if (skill.skills[i].Id != -1)
                    {
                        skilladd3.SetActive(true);
                    }
                }
            }
        }
    }

    public void charAddItem(string name)
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (slots[i].name == name)
            {

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                rewardItems[i] = new Equip();
                break;
            }

        }

    }

    public void charAddskill(string name)
    {
        for (int i = 0; i < rewardSkills.Count; i++)
        {
            if (skillslots[i].name == name)
            {
                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = skillslots[i].GetComponentInChildren<SkillData>();
                Debug.Log(children);
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                rewardSkills[i] = new Skill();
                break;
            }

        }

    }



    public void Alldelete()
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            deleteItem(i); deleteSkill(i);
            deleteItem(i); deleteSkill(i);
            deleteItem(i); deleteSkill(i);
            
            Panel1.SetActive(false); Panel2.SetActive(false); Panel3.SetActive(false); //Panel4.SetActive(false); Panel5.SetActive(false);
           // Panel6.SetActive(false); Panel7.SetActive(false); Panel8.SetActive(false); Panel9.SetActive(false);
        }
    }

    public void deleteItem(int id)
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (rewardItems[i].Id == id)
            {

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                rewardItems[i] = new Equip();

                break;
            }

        }

    }

    public void deleteSkill(int id)
    {
        for (int i = 0; i < rewardSkills.Count; i++)
        {
            if (rewardSkills[i].Id == id)
            {
                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = skillslots[i].GetComponentInChildren<SkillData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                rewardSkills[i] = new Skill();
                break;
            }
        }

    }



    public void AddItem(int id)
    {
        Equip itemToAdd = rewardBase.FetchItemByID(id);

        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (rewardItems[i].Id == -1)
            {
                rewardItems[i] = itemToAdd;
                GameObject itemObj = Instantiate(RewardItem);
                itemObj.GetComponent<ItemData>().equip = itemToAdd;
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.transform.SetParent(slots[i].transform);

                itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;

                itemObj.transform.position = slots[i].transform.position;
                itemObj.name = itemToAdd.Name;
                Debug.Log("없는 대상" + i);

                break;
            }
        }
    }

    bool Check_Item_In_Inventory(Equip equip)
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (rewardItems[i].Id == equip.Id)
                return true;

        }
        return false;
    }

    public void AddSkill(int id)
    {
        Skill skillToAdd = skill.SkillByID(id);
        for (int i = 0; i < rewardSkills.Count; i++)
        {
            if (rewardSkills[i].Id == -1)
            {
                Debug.Log("진입");
                rewardSkills[i] = skillToAdd;
                GameObject itemObj = Instantiate(RewardSkill);
                itemObj.GetComponent<SkillData>().skill = skillToAdd;
                itemObj.GetComponent<SkillData>().slot = i;
                itemObj.transform.SetParent(skillslots[i].transform);

                itemObj.GetComponent<Image>().sprite = skillToAdd.sprite;
                itemObj.transform.position = skillslots[i].transform.position;
                itemObj.name = "획득 스킬" + id.ToString();

                Debug.Log("없는 대상" + i);
                break;

            }

        }
    }

    




}
