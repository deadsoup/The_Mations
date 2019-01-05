using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battle : MonoBehaviour {

    int pdamage;
    int edamage;

    int PlusDamage;

    float eTime;

    int speed = 1;

    bool diceTriger = true;

    public static bool battleaction;



    public static int i; //몬스터 배열 호출

    public static int c = 0; //공격 전환

    public static int[] switching = new int[3]; // 캐릭터 전환


    public static int reItems;


    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;

    public GameObject attackButton;

    public GameObject skillButton;
    public GameObject unSkillButton;

    public GameObject skipButton;
    public GameObject targetButton;

    public GameObject reward;



    public GameObject Dice;
    public GameObject actionGage;
    public GameObject eActionGage;

    public Inven inven;

    public GameObject mob1;
    public GameObject mob2;

    public GameObject mobHp;
    public Slider mob_HpSlider_1;

    public GameObject Hp1;
    public GameObject Mp1;
    public GameObject Str1;
    public GameObject Dex1;
    public GameObject Wis1;


    SKillManager sKillManager;
    npc Npc;

    GameObject player1;
    GameObject player2;
    GameObject player3;

    GameObject Invenpanel;

    Animator Player1;

    Animator Player2;

    Animator Player3;

    Animator Monster;
    RuntimeAnimatorController Idol;
    RuntimeAnimatorController Nerd;

    GameObject EffectSystem;



    public void nomalDice()
    {
        if (npc.action == true && npc.Hp[c] > 0 && npc.actiongage >= 3.0f && diceTriger == true)
        {
            int dice = Random.Range(1, 7);
            if (dice == 1) { PlusDamage = -2; }
            if (dice == 2) { PlusDamage = -1; }
            if (dice == 3) { PlusDamage = 0; }
            if (dice == 4) { PlusDamage = 1; }
            if (dice == 5) { PlusDamage = 2; }
            if (dice == 6) { PlusDamage = 3; }
            diceTriger = false;
            Dice.SetActive(false);
            print(dice);
        }
    }


    public void playerAttak()
    {
        if (npc.action == true && npc.Hp[c] > 0 && npc.actiongage >= 3.0f)
        {
            npc.actiongage -= 3.0f;
            actionGage.GetComponent<Image>().fillAmount -= 0.3f;

            pdamage = npc.Str[c]+ npc.Equip_Str[c] + PlusDamage;
            if (pdamage <= 0) { pdamage = 0; }

            npc.Hp[i] -= pdamage;

            PlusDamage = 0;

            if (c == 0)
            {
                Debug.Log("모션 진입");
                Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                Char1.GetComponent<Animator>().runtimeAnimatorController = Idol;
                Player1.SetTrigger("Atk");
                FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
            }
            if (c == 1)
            {
                Debug.Log("모션 진입");
                Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                Char2.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                Player2.SetTrigger("Atk");
                FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
            }




            EffectSystem.GetComponentInChildren<Animator>().SetTrigger("Active");

            if (npc.actiongage <= 0)
            {
                npc.actiongage = 0f;
                actionGage.GetComponent<Image>().fillAmount = 0f;
                npc.action = false;
                npc.eAction = true;
                npc.eActiongage = 10f;

            }

            Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
            Debug.Log(npc.name[c] + "은 " + npc.name[i] + "에게 " + pdamage + "를 가했다.");
            Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
            Debug.Log(npc.action);

            diceTriger = true;

        }

        else { Debug.Log("공격 불가"); }

    }

    public void skillStart()
    {
        attackButton.SetActive(false);
        targetButton.SetActive(true);
        unSkillButton.SetActive(true);

    }

    public void unSkillStart()
    {
        attackButton.SetActive(true);
        targetButton.SetActive(false);
        unSkillButton.SetActive(false);


    }




    public void skillAttak()
    {
        if (npc.action == true && npc.Hp[c] > 0 && npc.actiongage >= 5.0f) // 플레이어 공격
        {


            npc.actiongage -= 5.0f;
            actionGage.GetComponent<Image>().fillAmount -= 0.5f;



            pdamage = npc.Str[c] + npc.Equip_Str[c] + 10;
            if (pdamage <= 0) { pdamage = 0; }

            npc.Hp[i] -= pdamage;

            FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);

            if (npc.actiongage <= 0)
            {

                npc.actiongage = 0;
                actionGage.GetComponent<Image>().fillAmount = 0f;

                actionGage.GetComponent<Image>().fillAmount += npc.actiongage;

                npc.action = false;
                npc.eAction = true;
                if (npc.eAction == true)
                {

                    npc.eActiongage = 10f;
                    npc.actiongage = 10.1f;
                }
            }
            else { Debug.Log("공격 불가"); }
            Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
            Debug.Log(npc.name[c] + "은 " + npc.name[i] + "에게 염구를 던진다." + pdamage + "의 충격을 가한다.");
            Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
            Debug.Log(npc.action);

            attackButton.SetActive(true);
            targetButton.SetActive(false);
            unSkillButton.SetActive(false);
            Dice.SetActive(false);

        }
    }

    public void skip()
    {
        if (npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
        {

            npc.actiongage = 0f;
            actionGage.GetComponent<Image>().fillAmount = 0.0f;

            npc.action = false;
            npc.eAction = true;
            npc.eActiongage = 10f;

            Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
            Debug.Log(npc.name[c] + "는 턴을 종료한다.");
            Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
            Debug.Log(npc.action);
        }

        attackButton.SetActive(false);
        skipButton.SetActive(false);
        targetButton.SetActive(false);


    }



    public void enemyAttak()
    {


        //if (npc.unitCondition[0].condition_Stun == true)
        //{
        //     몬스터 턴아무것도 안하고
        //     npc.unitCondition[0].leftStun -= 1;
        //}
        if (player1.activeSelf == true && player2.activeSelf == false && player3.activeSelf == false)
        {
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[c] -= edamage;
            Monster.SetTrigger("Atk");

            FloatingTextController.CreateFloatingText2(edamage.ToString(), transform);

        }

        if (player1.activeSelf == true && player2.activeSelf == true && player3.activeSelf == false)
        {
            int random = Random.Range(switching[0],2);
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[random] -= edamage;
            Monster.SetTrigger("Atk");

            if (random == 0) { FloatingTextController.CreateFloatingText2(edamage.ToString(), transform); }
            if (random == 1) { FloatingTextController.CreateFloatingText3(edamage.ToString(), transform); }

        }

        if (player1.activeSelf == true && player2.activeSelf == true && player3.activeSelf == true)
        {
            int random = Random.Range(switching[0], 3);
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[random] -= edamage;
            Monster.SetTrigger("Atk");
            if (random == 0) { FloatingTextController.CreateFloatingText2(edamage.ToString(), transform); }
            if (random == 1) { FloatingTextController.CreateFloatingText3(edamage.ToString(), transform); }
            if (random == 2) { FloatingTextController.CreateFloatingText4(edamage.ToString(), transform); }
        }

        if (npc.eActiongage <= 0)
        {

            npc.eActiongage = 0f;
            eActionGage.GetComponent<Image>().fillAmount = 0f;
            npc.eAction = false;
            npc.action = true;
            Debug.Log("턴 완료");
            if (npc.action == true)
            {
                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                npc.actiongage = 10.1f;
                npc.eActiongage = 10f;

                attackButton.SetActive(true);
                skipButton.SetActive(true);
                diceTriger = true;
                Dice.SetActive(true);

            }
        }
    }

    public void mob1_Hp ()
    {

        mob_HpSlider_1.maxValue = npc.MaxHp[i];

        mob_HpSlider_1.value = npc.Hp[i];
    }

    public void chaneGetta1()
    {

        if (npc.Hp[switching[0]] > 0) // 체인지 게타원
        {
            c = 0;
            switching[0] = c;
            //Char1.SetActive(true);
            //Char2.SetActive(false);
            //Move.i = c;
            sKillManager.UniqueSkill_Set(c);
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

            Outline char1;
            Outline char2;
            Outline char3;

            char1 = Char1.GetComponent<Outline>();
            char2 = Char2.GetComponent<Outline>();
            char3 = Char3.GetComponent<Outline>();

            char1.effectColor = new Color32(0, 0, 0, 255);
            char2.effectColor = new Color32(0, 0, 0, 0);
            char3.effectColor = new Color32(0, 0, 0, 0);

            for (int i = 0; i < Npc.SkillTriggers[c].skill.Length; i++)
            {
                if (Npc.SkillTriggers[c].skill[i] == true)
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

        if (npc.Hp[switching[1]] > 0) // 체인지 게타투
        {
            c = 1;
            switching[1] = c;
            //Char2.SetActive(true);
            //Char1.SetActive(false);
            //Move.i = c;
            sKillManager.UniqueSkill_Set(c);
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

            Outline char1;
            Outline char2;
            Outline char3;

            char1 = Char1.GetComponent<Outline>();
            char2 = Char2.GetComponent<Outline>();
            char3 = Char3.GetComponent<Outline>();

            char1.effectColor = new Color32(0, 0, 0, 0);
            char2.effectColor = new Color32(0, 0, 0, 255);
            char3.effectColor = new Color32(0, 0, 0, 0);


            for (int i = 0; i < Npc.SkillTriggers[c].skill.Length; i++)
            {
                if (Npc.SkillTriggers[c].skill[i] == true)
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

        if (npc.Hp[switching[2]] > 0) // 체인지 게타3
        {
            c = 2;
            switching[2] = c;
            //Char2.SetActive(true);
            //Char1.SetActive(false);
            //Move.i = c;
            sKillManager.UniqueSkill_Set(c);
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

            Outline char1;
            Outline char2;
            Outline char3;

            char1 = Char1.GetComponent<Outline>();
            char2 = Char2.GetComponent<Outline>();
            char3 = Char3.GetComponent<Outline>();

            char1.effectColor = new Color32(0, 0, 0, 0);
            char2.effectColor = new Color32(0, 0, 0, 0);
            char3.effectColor = new Color32(0, 0, 0, 255);

            for (int i = 0; i < Npc.SkillTriggers[c].skill.Length; i++)
            {
                if (Npc.SkillTriggers[c].skill[i] == true)
                {
                    sKillManager.AddSkill(i);
                    Debug.Log(i);
                }
            }


            Debug.Log("현재 활동하는 캐릭터는  " + npc.name[switching[2]] + "다");
        }
    }


    // Use this for initialization
    void Start()
    {
        //switching[0] = 0; switching[1] = 1; switching[2] = 2;
        Hp1.GetComponent<Text>().text = "체력 : " + (npc.Hp[switching[0]] + npc.Equip_MaxHp[switching[0]]);
        Mp1.GetComponent<Text>().text = "마나 : " + (npc.Mp[switching[0]] + npc.Equip_MaxMp[switching[0]]);
        Str1.GetComponent<Text>().text = "힘 : " + (npc.Str[switching[0]] + npc.Equip_Str[switching[0]]);
        Dex1.GetComponent<Text>().text = "민첩 : " + (npc.Dex[switching[0]] + npc.Equip_Dex[switching[0]]);
        Wis1.GetComponent<Text>().text = "지능 : " + (npc.Wis[switching[0]] + npc.Equip_Wis[switching[0]]);

        sKillManager = GameObject.Find("SKillManager").GetComponent<SKillManager>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();

        player1 = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
        player2 = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
        player3 = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;
        /*
        Npc.SkillTriggers[0].skill[1] = true;
        Npc.SkillTriggers[0].skill[4] = true;
        Npc.SkillTriggers[1].skill[2] = true;

        Npc.SkillTriggers[1].skill[5] = true;
        */

        Invenpanel = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").gameObject;

        Player1 = GameObject.Find("Canvas").transform.Find("Jin_Getta1").transform.Find("Char1").GetComponent<Animator>();
        Player2 = GameObject.Find("Canvas").transform.Find("Jin_Getta2").transform.Find("Char2").GetComponent<Animator>();
        Player3 = GameObject.Find("Canvas").transform.Find("Jin_Getta3").transform.Find("Char3").GetComponent<Animator>();

        Monster = GameObject.Find("Canvas").transform.Find("mob1").GetComponent<Animator>();

        EffectSystem = GameObject.Find("EffectSystem");


        
        Idol = Resources.Load<RuntimeAnimatorController>("Battle_Resource/Animations/Idol");
        
        Nerd = Resources.Load<RuntimeAnimatorController>("Battle_Resource/Animations/Nerd");


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            for (int i = 0; i < Npc.SkillTriggers[0].skill.Length; i++)
            {
                Debug.Log("보유 스킬 번호 :"+i+" 는 "+Npc.SkillTriggers[0].skill[i]);
            }
        }


        if (EffectSystem.transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit") == true)
        {
            GameObject nomal = EffectSystem.transform.GetChild(0).gameObject;
            Destroy(nomal);
            
            GameObject Set = Instantiate(nomal);
            Set.transform.SetParent(EffectSystem.transform);
            Set.transform.position = EffectSystem.transform.position;
            Set.name = "30_0";

        }



        eTime +=Time.deltaTime;

        if (c== 0)
        {
            int playerHp = npc.Hp[switching[0]] + npc.Equip_MaxHp[switching[0]];
            int playerMp = npc.Mp[switching[0]] + npc.Equip_MaxMp[switching[0]];
            int playerStr = npc.Str[switching[0]] + npc.Equip_Str[switching[0]];
            int playerDex = npc.Dex[switching[0]] + npc.Equip_Dex[switching[0]];
            int playerWis = npc.Wis[switching[0]] + npc.Equip_Wis[switching[0]];


            Hp1.GetComponent<Text>().text = "체력 : " + playerHp;
            Mp1.GetComponent<Text>().text = "마나 : " + playerMp;
            Str1.GetComponent<Text>().text = "힘 : " + playerStr;
            Dex1.GetComponent<Text>().text = "민첩 : " + playerDex;
            Wis1.GetComponent<Text>().text = "지능 : " + playerWis;



        }

        if (c == 1)
        {
            int playerHp = npc.Hp[switching[1]] + npc.Equip_MaxHp[switching[1]];
            int playerMp = npc.Mp[switching[1]] + npc.Equip_MaxMp[switching[1]];
            int playerStr = npc.Str[switching[1]] + npc.Equip_Str[switching[1]];
            int playerDex = npc.Dex[switching[1]] + npc.Equip_Dex[switching[1]];
            int playerWis = npc.Wis[switching[1]] + npc.Equip_Wis[switching[1]];


            Hp1.GetComponent<Text>().text = "체력 : " + playerHp;
            Mp1.GetComponent<Text>().text = "마나 : " + playerMp;
            Str1.GetComponent<Text>().text = "힘 : " + playerStr;
            Dex1.GetComponent<Text>().text = "민첩 : " + playerDex;
            Wis1.GetComponent<Text>().text = "지능 : " + playerWis;



        }

        if (c == 2)
        {
            int playerHp = npc.Hp[switching[2]] + npc.Equip_MaxHp[switching[2]];
            int playerMp = npc.Mp[switching[2]] + npc.Equip_MaxMp[switching[2]];
            int playerStr = npc.Str[switching[2]] + npc.Equip_Str[switching[2]];
            int playerDex = npc.Dex[switching[2]] + npc.Equip_Dex[switching[2]];
            int playerWis = npc.Wis[switching[2]] + npc.Equip_Wis[switching[2]];

            Hp1.GetComponent<Text>().text = "체력 : " + playerHp;
            Mp1.GetComponent<Text>().text = "마나 : " + playerMp;
            Str1.GetComponent<Text>().text = "힘 : " + playerStr;
            Dex1.GetComponent<Text>().text = "민첩 : " + playerDex;
            Wis1.GetComponent<Text>().text = "지능 : " + playerWis;



        }


        if (battleaction == true)
        {
            //Debug.Log(i+"번의 몬스터 등장 !");
            if (i == 10)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_PolizerDog");
            }
            if (i == 11)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_PolizerBird");
            }
            if (i == 12)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Zoombie");
            }
            if (i == 13)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_PolizerSlaughterTiger");
            }
            if (i == 14)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Boss_DarkHon");
            }
            if (i == 15)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_soldier01");
            }
            if (i == 16)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Mothgirl");
            }
            if (i == 17)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_monitoringRobot");
            }
            if (i == 18)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Wearwolf");
            }
            if (i == 19)
            {
                mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Boss_Fireman");
            }

            mobHp.SetActive(true);
            attackButton.SetActive(true);
            skipButton.SetActive(true);

            actionGage.SetActive(true);
            eActionGage.SetActive(true);
            Dice.SetActive(true);

            if (actionGage.GetComponent<Image>().fillAmount <= 0.0f && eActionGage.GetComponent<Image>().fillAmount <= 0.0f)
            {
                actionGage.GetComponent<Image>().fillAmount = 1.0f;
                eActionGage.GetComponent<Image>().fillAmount = 1.0f;
            }




            mob1_Hp();



            mobHp.GetComponent<Text>().text = "체력 : " + npc.Hp[i];


            if (Input.GetKeyDown(KeyCode.A)&& npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
            {
                playerAttak();
                Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
                Debug.Log(npc.name[c] + "은 " + npc.name[i] + "에게 " + pdamage + "를 가했다.");
                Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
                Debug.Log(npc.action);
            }

            if (Input.GetKeyDown(KeyCode.S) && npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
            {
                skillAttak();
                Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
                Debug.Log(npc.name[c] + "은 " + npc.name[i] + "에게 염구를 던진다." + pdamage + "의 충격을 가한다.");
                Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
                Debug.Log(npc.action);
            }

            if (Input.GetKeyDown(KeyCode.Space) && npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
            {
                skip();
                Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
                Debug.Log(npc.name[c] + "는 턴을 종료한다.");
                Debug.Log(npc.name[i] + "은 " + npc.Hp[i] + "가 남았다.");
                Debug.Log(npc.action);
            }


            



            if (npc.eAction == true ) // 적 공격
            {
                /*
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("적의 턴입니다.");
                    
                }*/
                Debug.Log(eTime);
                Dice.SetActive(false);
                if (eTime >= 1f)
                {
                    eTime = 1.0f;
                }


                if (npc.unitCondition[i].condition_Stun == true) // 스턴 상태이상 관련
                {
                    eTime = 0f;
                    npc.eActiongage = 0f;
                    if (npc.eActiongage < 3.0f)
                    {
                        eActionGage.GetComponent<Image>().fillAmount = 0f;
                        npc.eActiongage = 0f;
                        npc.eAction = false;
                        npc.action = true;
                        npc.unitCondition[i].left_Stun--;

                        Debug.Log("턴 완료");
                        if (npc.action == true)
                        {
                            Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                            npc.actiongage = 10.1f;
                            npc.eActiongage = 10f;

                            attackButton.SetActive(true);
                            skipButton.SetActive(true);
                            if (npc.unitCondition[i].left_Stun <= 0)
                            {
                                npc.unitCondition[i].condition_Stun = false;
                            }
                        }
                    }
                }




                if (npc.Hp[i] > 0 && eTime >= 1.0f && npc.eActiongage >= 10.0f)
                {
                    enemyAttak();
                    Debug.Log("현재 남은 액션 게이지 = " + npc.eActiongage + "다");
                    Debug.Log(npc.name[i] + "은 " + npc.name[c] + "에게 " + edamage + "를 가했다.");
                    Debug.Log(npc.name[c] + "은 " + npc.Hp[c] + "가 남았다.");
                    Debug.Log(npc.eAction);
                    eTime = 0f;
                }

                else if (npc.eActiongage < 3.0f)
                {
                    eActionGage.GetComponent<Image>().fillAmount = 0f;
                    npc.eActiongage = 0f;
                    npc.eAction = false;
                    npc.action = true;
                    Debug.Log("턴 완료");
                    if (npc.action == true)
                    {
                        Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                        npc.actiongage = 10.1f;
                        npc.eActiongage = 10f;




                        attackButton.SetActive(true);
                        skipButton.SetActive(true);


                    }
                }

            }

            if (npc.Hp[0] <= 0  && npc.Hp[1] <= 0)
            {
                Debug.Log("플레이어 패배");
                npc.action = false;
                npc.eAction = false;
                battleaction = false;
                Dice.SetActive(false);
            }

            if (npc.Hp[i] <= 0)
            {
                Debug.Log("플레이어 승리");
                npc.action = false;
                npc.eAction = false;
                battleaction = false;
                npc.ArchivePoint[0] += npc.ArchivePoint[i];
                npc.huntCount[i]++;
                npc.actiongage = 10f;
                npc.eActiongage = 10f;
                diceTriger = true;

                Debug.Log(npc.name[i]+"를 총"+ npc.huntCount[i] + "마리 해치웠다.");
                mobHp.SetActive(false);
                attackButton.SetActive(false);
                skipButton.SetActive(false);
                actionGage.SetActive(false);
                eActionGage.SetActive(false);


                actionGage.GetComponent<Image>().fillAmount = 1.0f;
                eActionGage.GetComponent<Image>().fillAmount = 1.0f;

                reward.SetActive(true);
                reItems = 1;
                Reward.reward1 = Random.Range(1, 6);
                Reward.reward2 = Random.Range(1, 6);
                Reward.reward3 = Random.Range(1, 6);

                Reward.skillreward1 = Random.Range(1, 6);
                Reward.skillreward2 = Random.Range(1, 6);
                Reward.skillreward3 = Random.Range(1, 6);

                mob1.SetActive(false);
                mob2.SetActive(false);
                npc.Hp[i] = npc.MaxHp[i];
                Dice.SetActive(false);
            }
        }

    }
}
