using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    battle starbattle;

    Player player;

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
        starbattle = GetComponent<battle>();
        player = GetComponent<Player>();
        battle.battleaction = false;


        mobHp = GameObject.Find("mobHp");
        int random = Random.Range(10,20);

        battleEvent(random);

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


        i = battle.switching[0];
        i2 = battle.switching[1];
        i3 = battle.switching[2];

        Hpslider(i);
        Mpslider(i);

        Hpslider2(i2);
        Mpslider2(i2);

        charHp.GetComponent<Text>().text = " HP : " + (npc.Hp[i] + npc.Equip_MaxHp[i]) + " / " + (npc.MaxHp[i] + npc.Equip_MaxHp[i]).ToString();
        charMp.GetComponent<Text>().text = " Mp : " + (npc.Mp[i] + npc.Equip_MaxMp[i]) + " / " + (npc.MaxMp[i] + npc.Equip_MaxMp[i]).ToString();


        charHp2.GetComponent<Text>().text = " HP : " + (npc.Hp[i2] + npc.Equip_MaxHp[i2]) + " / " + (npc.MaxHp[i2] + npc.Equip_MaxHp[i2]).ToString();
        charMp2.GetComponent<Text>().text = " Mp : " + (npc.Mp[i2] + npc.Equip_MaxMp[i2]) + " / " + (npc.MaxMp[i2] + npc.Equip_MaxMp[i2]).ToString();

        if (Input.GetKeyDown(KeyCode.U))
        {
            Test();

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




        /*
                if (battle.battleaction == false && Input.GetKeyDown(KeyCode.M))
                {
                    move++;
                    Debug.Log(move + "만큼 이동합니다.");
                    battlecount = Random.Range(1, 6);
                    battle.i = Random.Range(2, 4);
                    Item.setItem = false;
                    Item.c = false;
                    Item.Q = 0;


                    

                    if (battlecount == 2)
                    {
                        bool i = true;
                        Debug.Log("아이템 등장");
                        if (i == true)
                        {
                            Item.Q = 10;
                            Debug.Log("1번 캐릭터에게 아이템을 장착시키겠습니까? --- 1번 클릭 ---");
                            Debug.Log("2번 캐릭터에게 아이템을 장착시키겠습니까? --- 2번 클릭 ---");

                            Item.i = Random.Range(1, 5);
                            Debug.Log(Item.i+"번 아이템 등장");
                            Item.getItem();
                            i = false;
                        }


                    }


                    if (battlecount == 3)
                    {
                        Debug.Log("체력과 마나를 10% 회복합니다.");
                        GameEvent.hpMpRegen();


                    }



                }
                */
    }
}
