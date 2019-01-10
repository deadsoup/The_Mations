using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharInfo : MonoBehaviour
{
    
    public GameObject Point;

    public GameObject Hp;
    public GameObject Mp;
    public GameObject Str;
    public GameObject Wis;

    SlotChange slotChange;


    // Start is called before the first frame update
    public void StrUp()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == battle.c)
            {
                if (npc.SkillPoint >= 1)
                {
                    npc.Str[battle.c]++;
                    npc.SkillPoint += -1;
                }
            }
        }
        
    }
    public void WisUP()
    {

        for (int i = 0; i < 10; i++)
        {
            if (i == battle.c)
            {
                if (npc.SkillPoint >= 1)
                {
                    npc.Wis[battle.c]++;
                    npc.SkillPoint += -1;
                }
            }
        }

    }
    public void HpUP()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == battle.c)
            {

                if (npc.ArchivePoint[0] >= 1)
                {
                    npc.Hp[battle.c] += 10;
                    npc.SkillPoint += -1;
                }
            }
        }

    }
    public void MpUP()
    {

        for (int i = 0; i < 10; i++)
        {
            if (i == battle.c)
            {

                if (npc.ArchivePoint[0] >= 1)
                {
                    npc.Mp[battle.c] += 10;
                    npc.ArchivePoint[0] += -1;
                }
            }
        }
    }

    void Start()
    {
        slotChange = GameObject.Find("PartySystem").GetComponent<SlotChange>();

        Hp = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Stat").GetChild(0).gameObject;
        Mp = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Stat").GetChild(1).gameObject;
        Str = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Stat").GetChild(2).gameObject;
        Wis = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Stat").GetChild(3).gameObject;
        Point = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Stat").GetChild(4).gameObject;



        /*
        Hp.GetComponent<Text>().text = "체력 : " + (npc.Hp[slotChange.ChangeChar] + npc.Equip_MaxHp[slotChange.ChangeChar]);
        Mp.GetComponent<Text>().text = "마나 : " + (npc.Mp[slotChange.ChangeChar] + npc.Equip_MaxMp[slotChange.ChangeChar]);
        Str.GetComponent<Text>().text = "힘 : " + (npc.Str[slotChange.ChangeChar] + npc.Equip_Str[slotChange.ChangeChar]);
        Wis.GetComponent<Text>().text = "지능 : " + (npc.Wis[slotChange.ChangeChar] + npc.Equip_Wis[slotChange.ChangeChar]);
        Point.GetComponent<Text>().text = "포인트 : " + npc.SkillPoint;
        */

    }

    // Update is called once per frame
    void Update()
    {


    }
}
