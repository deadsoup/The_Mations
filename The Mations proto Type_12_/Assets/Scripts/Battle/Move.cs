using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    battle starbattle;

    Player player;

    GameObject[] playerSlot = new GameObject[3];

    int move;
    int battlecount;

    public Inven inven;

    int TheBT;

    public static int i;
    public static int i2;
    public static int i3;

    public Slider Char_1_HpSlider;
    public Slider Char_1_MpSlider;

    public Slider Char_2_HpSlider;
    public Slider Char_2_MpSlider;

    public Slider Char_3_HpSlider;
    public Slider Char_3_MpSlider;

    public GameObject charHp;
    public GameObject charMp;

    public GameObject charHp2;
    public GameObject charMp2;

    public GameObject charHp3;
    public GameObject charMp3;

    public static int mobIdx;


    GameObject mobHp;

    void Test()
    {
        print("Test");
        int i = Random.Range(1000,5000);
        FloatingTextController.CreateFloatingText(i.ToString(), transform);
        FloatingTextController.CreateFloatingText2(i.ToString(), transform);

    }


    // Use this for initialization
    void Start ()
    {
        playerSlot[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
        playerSlot[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
        playerSlot[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;
        starbattle = GetComponent<battle>();
        player = GetComponent<Player>();
        battle.battleaction = false;


        mobHp = GameObject.Find("mobHp");

        //int random = Random.Range(10,20);
        //battleEvent(random);

        mobIdx = Random.Range(10, 20);

        battleEvent(mobIdx);


    }
	
    void Hpslider(int i)
    {
        Char_1_HpSlider.maxValue = (npc.MaxHp[i] + npc.Equip_MaxHp[i]);

        Char_1_HpSlider.value = (npc.Hp[i] + npc.Equip_MaxHp[i]);

    }

    void Mpslider(int i)
    {
        Char_1_MpSlider.maxValue = (npc.MaxMp[i] + npc.Equip_MaxMp[i]);


        Char_1_MpSlider.value = (npc.Mp[i] + npc.Equip_MaxMp[i]);
    }

    void Hpslider2(int i2)
    {
        Char_2_HpSlider.maxValue = (npc.MaxHp[i2] + npc.Equip_MaxHp[i2]);

        Char_2_HpSlider.value = (npc.Hp[i2] + npc.Equip_MaxHp[i2]);

    }

    void Mpslider2(int i2)
    {
        Char_2_MpSlider.maxValue = (npc.MaxMp[i2] + npc.Equip_MaxMp[i2]);


        Char_2_MpSlider.value = (npc.Mp[i2] + npc.Equip_MaxMp[i2]);
    }

    void Hpslider3(int i3)
    {
        Char_3_HpSlider.maxValue = (npc.MaxHp[i3] + npc.Equip_MaxHp[i3]);

        Char_3_HpSlider.value = (npc.Hp[i3] + npc.Equip_MaxHp[i3]);

    }

    void Mpslider3(int i3)
    {
        Char_3_MpSlider.maxValue = (npc.MaxMp[i3] + npc.Equip_MaxMp[i3]);


        Char_3_MpSlider.value = (npc.Mp[i3] + npc.Equip_MaxMp[i3]);
    }




    void battleEvent(int random)
    {
            battle.i = random;
            Debug.Log("전투 시작");
            Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
            battle.battleaction = true;
            npc.action = true;


        

    }

    // Update is called once per frame
    void Update ()
    {
        FloatingTextController.Initialize();
        FloatingTextController.Initialize2();
        FloatingTextController.Initialize3();
        FloatingTextController.Initialize4();

        i = battle.switching[0];
        i2 = battle.switching[1];
        i3 = battle.switching[2];

        if (playerSlot[0].activeSelf == true)
        {
            Hpslider(i);
            Mpslider(i);

            charHp.GetComponent<Text>().text = " HP : " + (npc.Hp[i] + npc.Equip_MaxHp[i]) + " / " + (npc.MaxHp[i] + npc.Equip_MaxHp[i]).ToString();
            charMp.GetComponent<Text>().text = " Mp : " + (npc.Mp[i] + npc.Equip_MaxMp[i]) + " / " + (npc.MaxMp[i] + npc.Equip_MaxMp[i]).ToString();
        }

        if (playerSlot[1].activeSelf == true)
        {
            Hpslider2(i2);
            Mpslider2(i2);

            charHp2.GetComponent<Text>().text = " HP : " + (npc.Hp[i2] + npc.Equip_MaxHp[i2]) + " / " + (npc.MaxHp[i2] + npc.Equip_MaxHp[i2]).ToString();
            charMp2.GetComponent<Text>().text = " Mp : " + (npc.Mp[i2] + npc.Equip_MaxMp[i2]) + " / " + (npc.MaxMp[i2] + npc.Equip_MaxMp[i2]).ToString();
        }

        if (playerSlot[2].activeSelf == true)
        {
            Hpslider3(i3);
            Mpslider3(i3);

            charHp3.GetComponent<Text>().text = " HP : " + (npc.Hp[i3] + npc.Equip_MaxHp[i3]) + " / " + (npc.MaxHp[i3] + npc.Equip_MaxHp[i3]).ToString();
            charMp3.GetComponent<Text>().text = " Mp : " + (npc.Mp[i3] + npc.Equip_MaxMp[i3]) + " / " + (npc.MaxMp[i3] + npc.Equip_MaxMp[i3]).ToString();
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            Test();
            GameEvent.hpMpRegen();
        }


            if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("***********" + npc.name[1] + "의 정보입니다"+"***********");
            Debug.Log("***********"+"현재 최대 체력은  " + npc.MaxHp[1] + "***********");
            Debug.Log("***********" + "현재 현재 체력은  " + npc.Hp[1] + "***********");
            Debug.Log("***********" + "현재 최대 마나는  " + npc.MaxMp[1] + "***********");
            Debug.Log("***********" + "현재 현재 마나는  " + npc.Mp[1] + "***********");
            Debug.Log("***********" + "현재 힘은  " + npc.Str[1] + "***********");
            Debug.Log("***********" + "현재 민첩은  " + npc.Dex[1] + "***********");
            Debug.Log("***********" + "현재 지능은  " + npc.Wis[1] + "***********");



            Debug.Log("***********" + npc.name[4] + "의 정보입니다" + "***********");
            Debug.Log("***********" + "현재 최대 체력은  " + npc.MaxHp[4] + "***********");
            Debug.Log("***********" + "현재 현재 체력은  " + npc.Hp[4] + "***********");
            Debug.Log("***********" + "현재 최대 마나는  " + npc.MaxMp[4] + "***********");
            Debug.Log("***********" + "현재 현재 마나는  " + npc.Mp[4] + "***********");
            Debug.Log("***********" + "현재 힘은  " + npc.Str[4] + "***********");
            Debug.Log("***********" + "현재 민첩은  " + npc.Dex[4] + "***********");
            Debug.Log("***********" + "현재 지능은  " + npc.Wis[4] + "***********");




        }
    }
}
