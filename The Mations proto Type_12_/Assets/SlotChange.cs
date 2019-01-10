using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlotChange : MonoBehaviour
{
    bool[] playerDeactivate = new bool[3];

    public int ChangeChar;

    public  int[] switching = new int[3];

    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    
    public Inven inven;

    public GameObject Hp;
    public GameObject Mp;
    public GameObject Str;
    public GameObject Wis;

    GameObject Status;

    internal SKillManager sKillManager;
    internal npc Npc;


    internal GameObject Invenpanel;

    internal GameObject[] touchProtect = new GameObject[3];


    public void chaneGetta1()
    {

        if (npc.Hp[switching[0]] > 0 && playerDeactivate[0] == false) // 체인지 게타원
        {
            ChangeChar = switching[0];

            Char1.SetActive(true);
            Char2.SetActive(false);
            Char3.SetActive(false);


            Debug.Log(ChangeChar);
            sKillManager.UniqueSkill_Set(ChangeChar);
            sKillManager.resetSkill("skillSlot2");
            sKillManager.resetSkill("skillSlot3");
            sKillManager.resetSkill("skillSlot4");

            Invenpanel.transform.GetChild(0).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(1).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(2).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(3).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(4).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(5).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(6).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(7).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(8).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(9).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(10).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(11).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(12).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(13).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(14).gameObject.SetActive(false);


            for (int i = 0; i < Npc.SkillTriggers[ChangeChar].skill.Length; i++)
            {
                if (Npc.SkillTriggers[ChangeChar].skill[i] == true)
                {
                    sKillManager.AddSkill(i);
                    Debug.Log(i);
                }
            }

            Debug.Log("현재 활동하는 캐릭터는  " + npc.name[switching[0]] + "다");
        }




    }

    public void chaneGetta2()
    {

        if (npc.Hp[switching[1]] > 0 && playerDeactivate[1] == false) // 체인지 게타투
        {
            ChangeChar = switching[1];

            Char1.SetActive(false);
            Char2.SetActive(true);
            Char3.SetActive(false);
            sKillManager.UniqueSkill_Set(ChangeChar);
            sKillManager.resetSkill("skillSlot2");
            sKillManager.resetSkill("skillSlot3");
            sKillManager.resetSkill("skillSlot4");

            Invenpanel.transform.GetChild(1).gameObject.SetActive(true);

            Invenpanel.transform.GetChild(0).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(2).gameObject.SetActive(false);

            Invenpanel.transform.GetChild(3).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(4).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(5).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(6).gameObject.SetActive(false);

            Invenpanel.transform.GetChild(7).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(8).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(9).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(10).gameObject.SetActive(true);

            Invenpanel.transform.GetChild(11).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(12).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(13).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(14).gameObject.SetActive(false);


            for (int i = 0; i < Npc.SkillTriggers[ChangeChar].skill.Length; i++)
            {
                if (Npc.SkillTriggers[ChangeChar].skill[i] == true)
                {
                    sKillManager.AddSkill(i);
                    Debug.Log(i);
                }
            }



            Debug.Log("현재 활동하는 캐릭터는  " + npc.name[switching[1]] + "다");
        }
    }

    public void chaneGetta3()
    {

        if (npc.Hp[switching[2]] > 0 && playerDeactivate[2] == false) // 체인지 게타3
        {
            ChangeChar = switching[2];

            Char1.SetActive(false);
            Char2.SetActive(false);
            Char3.SetActive(true);
            sKillManager.UniqueSkill_Set(ChangeChar);
            sKillManager.resetSkill("skillSlot2");
            sKillManager.resetSkill("skillSlot3");
            sKillManager.resetSkill("skillSlot4");

            Invenpanel.transform.GetChild(2).gameObject.SetActive(true);

            Invenpanel.transform.GetChild(0).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(1).gameObject.SetActive(false);

            Invenpanel.transform.GetChild(3).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(4).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(5).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(6).gameObject.SetActive(false);

            Invenpanel.transform.GetChild(7).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(8).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(9).gameObject.SetActive(false);
            Invenpanel.transform.GetChild(10).gameObject.SetActive(false);

            Invenpanel.transform.GetChild(11).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(12).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(13).gameObject.SetActive(true);
            Invenpanel.transform.GetChild(14).gameObject.SetActive(true);


            for (int i = 0; i < Npc.SkillTriggers[ChangeChar].skill.Length; i++)
            {
                if (Npc.SkillTriggers[ChangeChar].skill[i] == true)
                {
                    sKillManager.AddSkill(i);
                    Debug.Log(i);
                }
            }


            Debug.Log("현재 활동하는 캐릭터는  " + npc.name[switching[2]] + "다");
        }
    }



    // Start is called before the first frame update
    void Start()
    {

        //switching[0] = 0; switching[1] = 1; switching[2] = 2;
        /*
        Hp.GetComponent<Text>().text = "체력 : " + (npc.Hp[switching[0]] + npc.Equip_MaxHp[switching[0]]);
        Mp.GetComponent<Text>().text = "마나 : " + (npc.Mp[switching[0]] + npc.Equip_MaxMp[switching[0]]);
        Str.GetComponent<Text>().text = "힘 : " + (npc.Str[switching[0]] + npc.Equip_Str[switching[0]]);
        Wis.GetComponent<Text>().text = "지능 : " + (npc.Wis[switching[0]] + npc.Equip_Wis[switching[0]]);
        */
        
        sKillManager = GameObject.Find("SKillManager").GetComponent<SKillManager>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();

        Invenpanel = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Inven").transform.Find("BackPanel").gameObject;

        Status = GameObject.Find("Canvas").transform.Find("Status").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
