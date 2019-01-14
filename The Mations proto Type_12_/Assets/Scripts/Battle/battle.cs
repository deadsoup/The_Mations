using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battle : MonoBehaviour {

    internal int pdamage;
    internal int edamage;

    internal int PlusDamage;

    internal float eTime;

    internal int speed = 1;

    internal bool diceTriger = true;

    public static bool battleaction;

    bool[] playerDeactivate = new bool[3];

    public bool[] playerAbnomal_strbuff = new bool[3];
    public bool[] playerAbnomal_allbuff = new bool[3];
    public bool[] playerAbnomal_burn = new bool[3];

    public bool monsterAbnomal_sleep;
    public bool monsterAbnomal_burn;


    public static int i; //몬스터 배열 호출

    public static int c = 0; //공격 전환

    public static int[] switching = new int[3]; // 캐릭터 전환

    public int Effect_Check;

    public static int reItems;

    Party party;

    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;

    public GameObject attackButton;


    public GameObject skipButton;

    public GameObject reward;

    public GameObject AudioMG;

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

    public GameObject Point;

    internal SKillManager sKillManager;
    internal npc Npc;

    internal GameObject player1;
    internal GameObject player2;
    internal GameObject player3;

    internal GameObject Invenpanel;

    internal Animator Player1;

    internal Animator Player2;

    internal Animator Player3;

    internal Animator Monster;

    internal GameObject Dice2;
    internal Animator DiceAni;
    internal RuntimeAnimatorController DiceAni_;

    internal RuntimeAnimatorController Idol;
    internal RuntimeAnimatorController Nerd;
    internal RuntimeAnimatorController Dog;
    internal RuntimeAnimatorController Dog_Trnas;

    internal GameObject EffectSystem;
    internal GameObject[] touchProtect = new GameObject[3];

    internal GameObject[] playerSlot = new GameObject[3];



    bool[] charActive = new bool[3];

    public bool Dog_TransForm;

    EnemySkill enemySkill;
    int dice;
    public void randomDice()
    {
        dice = Random.Range(1, 7);
    }

    public void nomalDice()
    {
        if (npc.action == true && npc.Hp[c] > 0 && npc.actiongage >= 3.0f && diceTriger == true)
        {
            Dice2.SetActive(true);
            DiceAni.runtimeAnimatorController = null;
            DiceAni.runtimeAnimatorController = DiceAni_;
            int dice = Random.Range(1, 7    );
            if (dice == 1)
            {
                PlusDamage = -2;
                DiceAni.SetTrigger("1");
            }
            if (dice == 2)
            { PlusDamage = -1; DiceAni.SetTrigger("2"); }
            if (dice == 3)
            { PlusDamage = 0; DiceAni.SetTrigger("3"); }
            if (dice == 4)
            { PlusDamage = 1; DiceAni.SetTrigger("4"); }
            if (dice == 5)
            { PlusDamage = 2; DiceAni.SetTrigger("5"); }
            if (dice == 6)
            { PlusDamage = 3; DiceAni.SetTrigger("6"); }




            print(dice);
        }
    }


    public void playerAttak()
    {
        if (npc.action == true && npc.Hp[c] > 0 && npc.actiongage >= 3.0f)
        {
            npc.actiongage -= 3.0f;
            actionGage.GetComponent<Image>().fillAmount -= 0.3f;

            pdamage = npc.Str[c] + npc.Equip_Str[c] + npc.BuffStr[c] + npc.Allbuff[c] + PlusDamage;
            if (pdamage <= 0) { pdamage = 0; }

            npc.Hp[i] -= pdamage;

            PlusDamage = 0;

            if (charActive[0] == true)
            {
                if (c == 0)
                {
                    Debug.Log("아이돌 모션 진입");
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player1.SetTrigger("Atk1");
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);


                }
                if (c == 1)
                {
                    Debug.Log("너드 모션 진입");
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player1.SetTrigger("Atk1");
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
                }
                if (c == 2)
                {
                    Debug.Log("개 모션 진입");
                    if (Dog_TransForm == true)
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player1.SetTrigger("Atk1");
                    }
                    else
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player1.SetTrigger("Atk1");
                    }
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
                }
            }

            if (charActive[1] == true)
            {
                if (c == 0)
                {
                    Debug.Log("모션 진입");
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player2.SetTrigger("Atk2");
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);

                }
                if (c == 1)
                {
                    Debug.Log("모션 진입");
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player2.SetTrigger("Atk2");
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
                }
                if (c == 2)
                {
                    Debug.Log("모션 진입");
                    if (Dog_TransForm == true)
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player2.SetTrigger("Atk2");
                    }
                    else
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player2.SetTrigger("Atk2");
                    }
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
                }
            }

            if (charActive[2] == true)
            {
                if (c == 0)
                {
                    Debug.Log("모션 진입");
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player3.SetTrigger("Atk3");
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);

                }
                if (c == 1)
                {
                    Debug.Log("모션 진입");
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player3.SetTrigger("Atk3");
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
                }
                if (c == 2)
                {
                    Debug.Log("모션 진입");
                    if (Dog_TransForm == true)
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player3.SetTrigger("Atk3");
                    }
                    else
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player3.SetTrigger("Atk3");
                    }
                    FloatingTextController.CreateFloatingText(pdamage.ToString(), transform);
                }
            }

            Monster.SetTrigger("Hit");
            EffectSystem.transform.Find("30_0").GetComponent<Animator>().SetTrigger("Active");

            if (SceneManager.GetActiveScene().name == "DH_Battle")
            {
                AudioMG.GetComponent<AudioMG>().playAttack();
            }

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


    }

    public void enemyAttak() // 적 공격 맞았을 시
    {
        if (player1.activeSelf == true && player2.activeSelf == false && player3.activeSelf == false)
        {
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[switching[0]] -= edamage;
            Monster.SetTrigger("Atk");
            if (switching[0] == 0)
            {
                Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                Char1.GetComponent<Animator>().runtimeAnimatorController = Idol;
                Player1.SetTrigger("Hit");

            }
            if (switching[0] == 1)
            {
                Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                Char1.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                Player1.SetTrigger("Hit");
            }
            if (switching[0] == 2)
            {
                if (Dog_TransForm == true)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                    Player1.SetTrigger("Hit");
                }
                else
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Dog;
                    Player1.SetTrigger("Hit");
                }
            }

            FloatingTextController.CreateFloatingText2(edamage.ToString(), transform);

        }

        if (player1.activeSelf == true && player2.activeSelf == true && player3.activeSelf == false)
        {
            int random = 50;
            int randomTarget = Random.Range(1, 101);
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            Monster.SetTrigger("Atk");
            if (random >= randomTarget)
            {
                npc.Hp[switching[0]] -= edamage;
                if (switching[0] == 0)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player1.SetTrigger("Hit");

                }
                if (switching[0] == 1)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player1.SetTrigger("Hit");
                }
                if (switching[0] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player1.SetTrigger("Hit");
                    }
                    else
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player1.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText2(edamage.ToString(), transform);
            }
            else if (random < randomTarget)
            {
                npc.Hp[switching[1]] -= edamage;
                if (switching[1] == 0)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player2.SetTrigger("Hit");

                }
                if (switching[1] == 1)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player2.SetTrigger("Hit");
                }
                if (switching[1] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player2.SetTrigger("Hit");
                    }
                    else
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player2.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText3(edamage.ToString(), transform);
            }


        }

        if (player1.activeSelf == true && player2.activeSelf == true && player3.activeSelf == true)
        {
            int random = Random.Range(0, 3);
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;


            Debug.Log("적의 현재 타겟은 " + random);


            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[switching[random]] -= edamage;
            Monster.SetTrigger("Atk");
            if (random == 0)
            {
                if (switching[0] == 0)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player1.SetTrigger("Hit");

                }
                if (switching[0] == 1)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player1.SetTrigger("Hit");
                }
                if (switching[0] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player1.SetTrigger("Hit");
                    }
                    else
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player1.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText2(edamage.ToString(), transform);
            }
            if (random == 1)
            {
                if (switching[1] == 0)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player2.SetTrigger("Hit");

                }
                if (switching[1] == 1)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player2.SetTrigger("Hit");
                }
                if (switching[1] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player2.SetTrigger("Hit");
                    }
                    else
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player2.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText3(edamage.ToString(), transform);
            }
            if (random == 2)
            {
                if (switching[2] == 0)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player3.SetTrigger("Hit");

                }
                if (switching[2] == 1)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player3.SetTrigger("Hit");
                }
                if (switching[2] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player3.SetTrigger("Hit");
                    }
                    else
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player3.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText4(edamage.ToString(), transform);
            }
        }

        if (player1.activeSelf == false && player2.activeSelf == true && player3.activeSelf == false)
        {
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[switching[1]] -= edamage;
            Monster.SetTrigger("Atk");
            if (switching[1] == 0)
            {
                Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                Char2.GetComponent<Animator>().runtimeAnimatorController = Idol;
                Player2.SetTrigger("Hit");

            }
            if (switching[1] == 1)
            {
                Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                Char2.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                Player2.SetTrigger("Hit");
            }
            if (switching[1] == 2)
            {
                if (Dog_TransForm == true)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                    Player2.SetTrigger("Hit");
                }
                else
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Dog;
                    Player2.SetTrigger("Hit");
                }
            }

            FloatingTextController.CreateFloatingText3(edamage.ToString(), transform);

        }

        if (player1.activeSelf == false && player2.activeSelf == false && player3.activeSelf == true)
        {
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            npc.Hp[switching[2]] -= edamage;
            Monster.SetTrigger("Atk");
            if (switching[2] == 0)
            {
                Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                Char3.GetComponent<Animator>().runtimeAnimatorController = Idol;
                Player3.SetTrigger("Hit");

            }
            if (switching[2] == 1)
            {
                Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                Char3.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                Player3.SetTrigger("Hit");
            }
            if (switching[2] == 2)
            {
                if (Dog_TransForm == true)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                    Player3.SetTrigger("Hit");
                }
                else
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Dog;
                    Player3.SetTrigger("Hit");
                }
            }
            FloatingTextController.CreateFloatingText4(edamage.ToString(), transform);

        }

        if (player1.activeSelf == false && player2.activeSelf == true && player3.activeSelf == true)
        {
            int random = 50;
            int randomTarget = Random.Range(1, 101);
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }

            if (random >= randomTarget)
            {
                npc.Hp[switching[1]] -= edamage;
                Monster.SetTrigger("Atk");
                if (switching[1] == 0)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player2.SetTrigger("Hit");

                }
                if (switching[1] == 1)
                {
                    Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char2.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player2.SetTrigger("Hit");
                }
                if (switching[1] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player2.SetTrigger("Hit");
                    }
                    else
                    {
                        Char2.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char2.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player2.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText3(edamage.ToString(), transform);
            }
            else if (random < randomTarget)
            {
                npc.Hp[switching[2]] -= edamage;
                if (switching[2] == 0)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player3.SetTrigger("Hit");

                }
                if (switching[2] == 1)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player3.SetTrigger("Hit");
                }
                if (switching[2] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player3.SetTrigger("Hit");
                    }
                    else
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player3.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText4(edamage.ToString(), transform);
            }

        }

        if (player1.activeSelf == true && player2.activeSelf == false && player3.activeSelf == true)
        {
            int random = 50;
            int randomTarget = Random.Range(1, 101);
            npc.eActiongage -= 10.0f;
            eActionGage.GetComponent<Image>().fillAmount -= 1.0f;

            int randomDamage = Random.Range(1, 7);

            edamage = npc.atk[i] + randomDamage;
            if (edamage <= 0) { edamage = 0; }
            Monster.SetTrigger("Atk");

            if (random >= randomTarget)
            {
                npc.Hp[switching[0]] -= edamage;
                if (switching[0] == 0)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player1.SetTrigger("Hit");

                }
                if (switching[0] == 1)
                {
                    Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char1.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player1.SetTrigger("Hit");
                }
                if (switching[0] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player1.SetTrigger("Hit");
                    }
                    else
                    {
                        Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char1.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player1.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText2(edamage.ToString(), transform);
            }
            else if (random < randomTarget)
            {
                npc.Hp[switching[2]] -= edamage;
                if (switching[2] == 0)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Idol;
                    Player3.SetTrigger("Hit");

                }
                if (switching[2] == 1)
                {
                    Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                    Char3.GetComponent<Animator>().runtimeAnimatorController = Nerd;
                    Player3.SetTrigger("Hit");
                }
                if (switching[2] == 2)
                {
                    if (Dog_TransForm == true)
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog_Trnas;
                        Player3.SetTrigger("Hit");
                    }
                    else
                    {
                        Char3.GetComponent<Animator>().runtimeAnimatorController = null;
                        Char3.GetComponent<Animator>().runtimeAnimatorController = Dog;
                        Player3.SetTrigger("Hit");
                    }
                }
                FloatingTextController.CreateFloatingText4(edamage.ToString(), transform);
                if (SceneManager.GetActiveScene().name == "DH_Battle")
                {
                    AudioMG.GetComponent<AudioMG>().playAttack();
                }


            }


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

    public void mob1_Hp()
    {

        mob_HpSlider_1.maxValue = npc.MaxHp[i];

        mob_HpSlider_1.value = npc.Hp[i];
    }

    public void Player_Dead() // 사망 시
    {
        if (npc.Hp[switching[0]] <= 0)
        {
            npc.Hp[switching[0]] = 0;
            Player1.SetTrigger("Dead");
            if (Dice.transform.GetChild(1).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idol_dead_Idle") == true)
            {
                Char1.GetComponent<Animator>().runtimeAnimatorController = null;
                player1.SetActive(false);
            }

        }
        if (npc.Hp[switching[1]] <= 0)
        {
            npc.Hp[switching[1]] = 0;
            Char2.GetComponent<Animator>().runtimeAnimatorController = null;
            player2.SetActive(false);
        }
        if (npc.Hp[switching[2]] <= 0)
        {
            npc.Hp[switching[2]] = 0;
            Char3.GetComponent<Animator>().runtimeAnimatorController = null;
            player3.SetActive(false);
        }


    }

    public void chaneGetta1()
    {

        if (npc.Hp[switching[0]] > 0 && playerDeactivate[0] == false) // 체인지 게타원
        {
            charActive[0] = true;
            charActive[1] = false;
            charActive[2] = false;

            Effect_Check = 0;

            c = switching[0];
            //switching[0] = c;
            //Char1.SetActive(true);
            //Char2.SetActive(false);
            //Move.i = c;


            Debug.Log(c + "캐릭터 번호");

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

            if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "Passway")
            {
                player1.transform.GetChild(1).gameObject.SetActive(true);
                player2.transform.GetChild(1).gameObject.SetActive(false);
                player3.transform.GetChild(1).gameObject.SetActive(false);
            }



            if (SceneManager.GetActiveScene().name == "DH_Battle")
            {
                Outline char1;
                Outline char2;
                Outline char3;

                char1 = Char1.GetComponent<Outline>();
                char2 = Char2.GetComponent<Outline>();
                char3 = Char3.GetComponent<Outline>();

                char1.effectColor = new Color32(0, 0, 0, 255);
                char2.effectColor = new Color32(0, 0, 0, 0);
                char3.effectColor = new Color32(0, 0, 0, 0);
            }

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

        if (npc.Hp[switching[1]] > 0 && playerDeactivate[1] == false) // 체인지 게타투
        {

            charActive[0] = false;
            charActive[1] = true;
            charActive[2] = false;

            Effect_Check = 1;

            if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "Passway")
            {
                player1.transform.GetChild(1).gameObject.SetActive(false);
                player2.transform.GetChild(1).gameObject.SetActive(true);
                player3.transform.GetChild(1).gameObject.SetActive(false);
            }

            c = switching[1];
            Debug.Log(c + "캐릭터 번호");
            //switching[1] = c;
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

            if (SceneManager.GetActiveScene().name == "DH_Battle")
            {
                Outline char1;
                Outline char2;
                Outline char3;

                char1 = Char1.GetComponent<Outline>();
                char2 = Char2.GetComponent<Outline>();
                char3 = Char3.GetComponent<Outline>();

                char1.effectColor = new Color32(0, 0, 0, 0);
                char2.effectColor = new Color32(0, 0, 0, 255);
                char3.effectColor = new Color32(0, 0, 0, 0);
            }

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

        if (npc.Hp[switching[2]] > 0 && playerDeactivate[2] == false) // 체인지 게타3
        {

            charActive[0] = false;
            charActive[1] = false;
            charActive[2] = true;

            Effect_Check = 2;

            c = switching[2];
            Debug.Log(c + "캐릭터 번호");

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

            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                player1.transform.GetChild(1).gameObject.SetActive(false);
                player2.transform.GetChild(1).gameObject.SetActive(false);
                player3.transform.GetChild(1).gameObject.SetActive(true);
            }



            if (SceneManager.GetActiveScene().name == "DH_Battle")
            {
                Outline char1;
                Outline char2;
                Outline char3;

                char1 = Char1.GetComponent<Outline>();
                char2 = Char2.GetComponent<Outline>();
                char3 = Char3.GetComponent<Outline>();

                char1.effectColor = new Color32(0, 0, 0, 0);
                char2.effectColor = new Color32(0, 0, 0, 0);
                char3.effectColor = new Color32(0, 0, 0, 255);
            }
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


    public void Status1()
    {
        StopAllCoroutines();
        StartCoroutine(player1_Status());
    }
    public void Status2()
    {
        StopAllCoroutines();
        StartCoroutine(player2_Status());
    }
    public void Status3()
    {
        StopAllCoroutines();
        StartCoroutine(player3_Status());
    }


    public IEnumerator player1_Status()
    {
        while (true)
        {
            int playerHp = npc.Hp[switching[0]] + npc.Equip_MaxHp[switching[0]];
            int playerMaxHp = npc.MaxHp[switching[0]] + npc.Equip_MaxHp[switching[0]];

            int playerMp = npc.Mp[switching[0]] + npc.Equip_MaxMp[switching[0]];
            int playerMaxMp = npc.MaxMp[switching[0]] + npc.Equip_MaxHp[switching[0]];

            int playerStr = npc.Str[switching[0]] + npc.Equip_Str[switching[0]];
            int playerWis = npc.Wis[switching[0]] + npc.Equip_Wis[switching[0]];


            Hp1.GetComponent<Text>().text = "체력 : " + playerHp + " / " + playerMaxHp;
            Mp1.GetComponent<Text>().text = "마나 : " + playerMp + " / " + playerMaxMp;
            Str1.GetComponent<Text>().text = "힘 : " + playerStr;
            Wis1.GetComponent<Text>().text = "지능 : " + playerWis;
            if (SceneManager.GetActiveScene().name == "GameScene" )
            {
                Point.GetComponent<Text>().text = "포인트 : " + npc.SkillPoint;
            }
            yield return new WaitForSeconds(0);

        }
    }
    public IEnumerator player2_Status()
    {
        while (true)
        {
            int playerHp = npc.Hp[switching[1]] + npc.Equip_MaxHp[switching[1]];
            int playerMaxHp = npc.MaxHp[switching[1]] + npc.Equip_MaxHp[switching[1]];

            int playerMp = npc.Mp[switching[1]] + npc.Equip_MaxMp[switching[1]];
            int playerMaxMp = npc.MaxMp[switching[1]] + npc.Equip_MaxHp[switching[1]];

            int playerStr = npc.Str[switching[1]] + npc.Equip_Str[switching[1]];
            int playerWis = npc.Wis[switching[1]] + npc.Equip_Wis[switching[1]];


            Hp1.GetComponent<Text>().text = "체력 : " + playerHp + " / " + playerMaxHp;
            Mp1.GetComponent<Text>().text = "마나 : " + playerMp + " / " + playerMaxMp;
            Str1.GetComponent<Text>().text = "힘 : " + playerStr;
            Wis1.GetComponent<Text>().text = "지능 : " + playerWis;
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                Point.GetComponent<Text>().text = "포인트 : " + npc.SkillPoint;
            }
            yield return new WaitForSeconds(0);

        }
    }
    public IEnumerator player3_Status()
    {
        while (true)
        {
            int playerHp = npc.Hp[switching[2]] + npc.Equip_MaxHp[switching[2]];
            int playerMaxHp = npc.MaxHp[switching[2]] + npc.Equip_MaxHp[switching[2]];

            int playerMp = npc.Mp[switching[2]] + npc.Equip_MaxMp[switching[2]];
            int playerMaxMp = npc.MaxMp[switching[2]] + npc.Equip_MaxHp[switching[2]];

            int playerStr = npc.Str[switching[2]] + npc.Equip_Str[switching[2]];
            int playerWis = npc.Wis[switching[2]] + npc.Equip_Wis[switching[2]];


            Hp1.GetComponent<Text>().text = "체력 : " + playerHp + " / " + playerMaxHp;
            Mp1.GetComponent<Text>().text = "마나 : " + playerMp + " / " + playerMaxMp;
            Str1.GetComponent<Text>().text = "힘 : " + playerStr;
            Wis1.GetComponent<Text>().text = "지능 : " + playerWis;
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                Point.GetComponent<Text>().text = "포인트 : " + npc.SkillPoint;
            }
            yield return new WaitForSeconds(0);

        }
    }


    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "Passway")
        {
            sKillManager = GameObject.Find("SKillManager").GetComponent<SKillManager>();
            Npc = GameObject.Find("EventSystem").GetComponent<npc>();
            party = GameObject.Find("EventSystem").GetComponent<Party>();

            player1 = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta1").gameObject;
            player2 = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta2").gameObject;
            player3 = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta3").gameObject;

            Invenpanel = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Inven").transform.Find("BackPanel").gameObject;

            Player1 = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta1").transform.Find("Char1").GetComponent<Animator>();
            Player2 = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta2").transform.Find("Char2").GetComponent<Animator>();
            Player3 = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta3").transform.Find("Char3").GetComponent<Animator>();
        }
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            //switching[0] = 0; switching[1] = 1; switching[2] = 2;
            Hp1.GetComponent<Text>().text = "체력 : " + (npc.Hp[switching[0]] + npc.Equip_MaxHp[switching[0]]);
            Mp1.GetComponent<Text>().text = "마나 : " + (npc.Mp[switching[0]] + npc.Equip_MaxMp[switching[0]]);
            Str1.GetComponent<Text>().text = "힘 : " + (npc.Str[switching[0]] + npc.Equip_Str[switching[0]]);
            Wis1.GetComponent<Text>().text = "지능 : " + (npc.Wis[switching[0]] + npc.Equip_Wis[switching[0]]);

            sKillManager = GameObject.Find("SKillManager").GetComponent<SKillManager>();
            Npc = GameObject.Find("EventSystem").GetComponent<npc>();
            enemySkill = GameObject.Find("SKillManager").GetComponent<EnemySkill>();
            party = GameObject.Find("PartySystem").GetComponent<Party>();

            player1 = GameObject.Find("Canvas").transform.Find("Jin_Getta1").gameObject;
            player2 = GameObject.Find("Canvas").transform.Find("Jin_Getta2").gameObject;
            player3 = GameObject.Find("Canvas").transform.Find("Jin_Getta3").gameObject;

            Invenpanel = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").gameObject;

            Player1 = GameObject.Find("Canvas").transform.Find("Jin_Getta1").transform.Find("Char1").GetComponent<Animator>();
            Player2 = GameObject.Find("Canvas").transform.Find("Jin_Getta2").transform.Find("Char2").GetComponent<Animator>();
            Player3 = GameObject.Find("Canvas").transform.Find("Jin_Getta3").transform.Find("Char3").GetComponent<Animator>();

            Dice2 = GameObject.Find("Canvas").transform.Find("Dice").transform.GetChild(1).gameObject;
            DiceAni = GameObject.Find("Canvas").transform.Find("Dice").transform.GetChild(1).GetComponent<Animator>();
            Monster = GameObject.Find("Canvas").transform.Find("mob1").GetComponent<Animator>();

            EffectSystem = GameObject.Find("EffectSystem");
            touchProtect[0] = GameObject.Find("Canvas").transform.Find("touchProtect").gameObject;
            touchProtect[1] = GameObject.Find("Canvas").transform.Find("touchProtect2").gameObject;
            touchProtect[2] = GameObject.Find("Canvas").transform.Find("touchProtect3").gameObject;

            Idol = Resources.Load<RuntimeAnimatorController>("Battle_Resource/Animations/Idol");

            Nerd = Resources.Load<RuntimeAnimatorController>("Battle_Resource/Animations/Nerd");

            Dog = Resources.Load<RuntimeAnimatorController>("Battle_Resource/Animations/Dog");

            Dog_Trnas = Resources.Load<RuntimeAnimatorController>("Battle_Resource/Animations/Dog_Trans");

            DiceAni_ = Resources.Load<RuntimeAnimatorController>("Battle_Resource/dice/DiceAni");

            //player1.transform.Find("Char1").GetComponent<Image>().sprite = party.playerSprite[0].GetComponent<Image>().sprite;
            //player1.transform.Find("Char2").GetComponent<Image>().sprite = party.playerSprite[1].GetComponent<Image>().sprite;
            //player1.transform.Find("Char3").GetComponent<Image>().sprite = party.playerSprite[2].GetComponent<Image>().sprite;

            print("현재 첫 캐릭터의 아이디는 무엇" + party.num);
            //party.selectPlayer(party.num);

            //party.playerSelect1(party.num);



            //party.selectPlayer(1);
            //party.selectPlayer(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            Player_Dead();

            if (EffectSystem.transform.Find("30_0").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit") == true)
            {
                GameObject nomal = EffectSystem.transform.GetChild(0).gameObject;
                Destroy(nomal);

                GameObject Set = Instantiate(nomal);
                Set.transform.SetParent(EffectSystem.transform);
                Set.transform.position = EffectSystem.transform.position;
                Set.name = "30_0";

            }

            if (Dice.transform.GetChild(1).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("End") == true)
            {
                
                GameObject nomal = Dice.transform.GetChild(1).gameObject;

                DiceAni.runtimeAnimatorController = null;
                diceTriger = false;
                Dice.SetActive(false);
                Dice2.SetActive(false);

                playerAttak();

            }



            eTime += Time.deltaTime;

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
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Cat");
                }
                if (i == 13)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Zoombie");
                }
                if (i == 14)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_PolizerSlaughterTiger");
                }
                if (i == 15)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Boss_DarkHon");
                }
                if (i == 16)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_soldier01");
                }
                if (i == 17)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_monitoringRobot");
                }
                if (i == 18)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Mothgirl");
                }
                if (i == 19)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Wearwolf");
                }
                if (i == 20)
                {
                    mob1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monster/Monster_Gollem");
                }
                if (i == 21)
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


                if (Input.GetKeyDown(KeyCode.A) && npc.action == true && npc.Hp[c] > 0) // 플레이어 공격
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
                ///
                // 상태이상 관련 출력
                ///

                if (npc.action == true) // 플레이어 턴의 상태이상
                {
                    /// 상태이상 해제관련
                    /// 
                    /// 스턴 관련
                    if (npc.unitCondition[switching[0]].condition_Stun == true)
                    {
                        if (npc.unitCondition[switching[0]].left_Stun <= 0)
                        {
                            touchProtect[0].SetActive(false);
                            npc.unitCondition[switching[0]].condition_Stun = false;
                            playerDeactivate[0] = false;
                        }
                    }

                    if (npc.unitCondition[switching[1]].condition_Stun == true)
                    {
                        if (npc.unitCondition[switching[1]].left_Stun <= 0)
                        {
                            touchProtect[1].SetActive(false);
                            npc.unitCondition[switching[1]].condition_Stun = false;
                            playerDeactivate[1] = false;
                        }
                    }

                    if (npc.unitCondition[switching[2]].condition_Stun == true)
                    {
                        if (npc.unitCondition[switching[2]].left_Stun <= 0)
                        {
                            touchProtect[2].SetActive(false);
                            npc.unitCondition[switching[2]].condition_Stun = false;
                            playerDeactivate[2] = false;
                        }
                    }


                    /// 상태이상 발동관련
                    /// 
                    /// 스턴 관련
                    for (int player = 0; player < 3; player++)
                    {
                        if (npc.unitCondition[switching[0]].condition_Stun == true && npc.unitCondition[switching[1]].condition_Stun == true && npc.unitCondition[switching[2]].condition_Stun == true) // 스턴 상태이상 관련
                        {
                            playerDeactivate[0] = true;
                            playerDeactivate[1] = true;
                            playerDeactivate[2] = true;

                            npc.actiongage = 0;

                            if (npc.actiongage < 0.0f)
                            {
                                eActionGage.GetComponent<Image>().fillAmount = 0f;
                                npc.actiongage = 0f;
                                npc.eAction = true;
                                npc.action = false;
                                npc.unitCondition[switching[0]].left_Stun--;
                                npc.unitCondition[switching[1]].left_Stun--;
                                npc.unitCondition[switching[2]].left_Stun--;

                                Debug.Log("턴 완료");


                                if (npc.actiongage <= 0)
                                {
                                    npc.actiongage = 0f;
                                    actionGage.GetComponent<Image>().fillAmount = 0f;
                                    npc.action = false;
                                    npc.eAction = true;
                                    npc.eActiongage = 10f;

                                }

                            }
                        }

                        if (npc.unitCondition[switching[player]].condition_Stun == true)
                        {
                            playerDeactivate[player] = true;
                            touchProtect[player].SetActive(true);
                            if (npc.actiongage < 0.0f)
                            {
                                eActionGage.GetComponent<Image>().fillAmount = 0f;
                                npc.actiongage = 0f;
                                npc.eAction = true;
                                npc.action = false;
                                npc.unitCondition[switching[player]].left_Stun--;

                                Debug.Log("턴 완료");

                                if (npc.actiongage <= 0)
                                {
                                    npc.actiongage = 0f;
                                    actionGage.GetComponent<Image>().fillAmount = 0f;
                                    npc.action = false;
                                    npc.eAction = true;
                                    npc.eActiongage = 10f;
                                }

                            }
                        }
                    }

                    //// 상태이상 버프  힘
                    for (int i = 0; i < 3; i++)
                    {
                        if (npc.unitCondition[switching[i]].condition_StrBuff == true && playerAbnomal_strbuff[switching[i]] == true)
                        {
                            Debug.Log("버프 발동");
                            npc.unitCondition[switching[i]].left_StrBuff--;
                            playerAbnomal_strbuff[switching[i]] = false;
                            Debug.Log(switching[i] + "의 힘버프 상태" + npc.unitCondition[switching[i]].left_StrBuff);
                            if (npc.unitCondition[switching[i]].left_StrBuff <= 0)
                            {
                                npc.unitCondition[switching[i]].condition_StrBuff = false;
                                playerAbnomal_strbuff[switching[i]] = false;
                                npc.BuffStr[switching[i]] = 0;
                                Debug.Log("힘 버프 종료" + npc.BuffStr[switching[i]]);
                            }
                        }
                    }

                    //// 상태이상 버프  올버프

                    for (int i = 0; i < 3; i++)
                    {
                        if (npc.unitCondition[switching[i]].condition_AllBuff == true && playerAbnomal_allbuff[switching[i]] == true)
                        {
                            npc.unitCondition[switching[i]].left_AllBuff--;
                            playerAbnomal_allbuff[switching[i]] = false;
                            if (npc.unitCondition[switching[i]].left_AllBuff <= 0)
                            {
                                npc.unitCondition[switching[i]].condition_AllBuff = false;
                                playerAbnomal_allbuff[switching[i]] = false;
                                npc.Allbuff[switching[0]] = 0;
                                npc.Allbuff[switching[1]] = 0;
                                npc.Allbuff[switching[2]] = 0;
                                Debug.Log("강화 버프 종료" + npc.Allbuff[switching[i]]);
                            }
                        }
                    }






                }








                if (npc.eAction == true) // 적 공격
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

                    if (npc.unitCondition[i].condition_Sleep == true) // 수면 상태이상 관련
                    {
                        eTime = 0f;
                        npc.eActiongage = 0f;
                        if (npc.eActiongage < 3.0f)
                        {
                            eActionGage.GetComponent<Image>().fillAmount = 0f;
                            npc.eActiongage = 0f;
                            npc.eAction = false;
                            npc.action = true;
                            npc.unitCondition[i].left_Sleep--;

                            Debug.Log("턴 완료");
                            if (npc.action == true)
                            {
                                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                                npc.actiongage = 10.1f;
                                npc.eActiongage = 10f;

                                attackButton.SetActive(true);
                                skipButton.SetActive(true);
                                if (npc.unitCondition[i].left_Sleep <= 0)
                                {
                                    npc.unitCondition[i].condition_Sleep = false;
                                }
                            }
                        }
                    }


                    if (npc.unitCondition[i].condition_Burn == true) // 화상 상태이상 관련
                    {
                        npc.unitCondition[i].left_Burn--;
                        npc.Hp[i] -= 20;
                        Debug.Log("턴 완료");
                        FloatingTextController.CreateFloatingText("화상 !!" + 20.ToString(), transform);
                        monsterAbnomal_burn = false;
                        if (npc.unitCondition[i].left_Burn <= 0)
                        {
                            Debug.Log("화상 완료");
                            npc.unitCondition[i].condition_Burn = false;
                            monsterAbnomal_burn = false;
                        }
                    }


                    if (npc.Hp[i] > 0 && eTime >= 1.0f && npc.eActiongage >= 10.0f)
                    {
                        enemyAttak();
                        Debug.Log("현재 남은 액션 게이지 = " + npc.eActiongage + "다");
                        //Debug.Log(npc.name[i] + "은 " + npc.name[c] + "에게 " + edamage + "를 가했다.");
                        //Debug.Log(npc.name[c] + "은 " + npc.Hp[c] + "가 남았다.");
                        Debug.Log(npc.eAction);
                        eTime = 0f;

                        playerAbnomal_strbuff[0] = true;
                        playerAbnomal_strbuff[1] = true;
                        playerAbnomal_strbuff[2] = true;
                        playerAbnomal_allbuff[0] = true;
                        playerAbnomal_allbuff[1] = true;
                        playerAbnomal_allbuff[2] = true;

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

                            playerAbnomal_strbuff[0] = true;
                            playerAbnomal_strbuff[1] = true;
                            playerAbnomal_strbuff[2] = true;
                            playerAbnomal_allbuff[0] = true;
                            playerAbnomal_allbuff[1] = true;
                            playerAbnomal_allbuff[2] = true;

                            attackButton.SetActive(true);
                            skipButton.SetActive(true);


                        }
                    }

                }

                if (npc.Hp[0] <= 0 && npc.Hp[1] <= 0)
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

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().playVictorySE();
                    }


                    npc.ArchivePoint[0] += npc.ArchivePoint[i];

                    if (npc.ArchivePoint[0] >= 500)
                    {
                        npc.ArchivePoint[0] -= 500;
                        npc.SkillPoint++;
                    }


                    npc.huntCount[i]++;
                    npc.actiongage = 10f;
                    npc.eActiongage = 10f;
                    diceTriger = true;

                    Debug.Log(npc.name[i] + "를 총" + npc.huntCount[i] + "마리 해치웠다.");
                    mobHp.SetActive(false);
                    attackButton.SetActive(false);
                    skipButton.SetActive(false);
                    actionGage.SetActive(false);
                    eActionGage.SetActive(false);


                    actionGage.GetComponent<Image>().fillAmount = 1.0f;
                    eActionGage.GetComponent<Image>().fillAmount = 1.0f;

                    reward.SetActive(true);
                    reItems = 1;

                    /// 몬스터 ID에 따른 드랍 형태
                    

                    mob1.SetActive(false);
                    mob2.SetActive(false);
                    npc.Hp[i] = npc.MaxHp[i];
                    Dice.SetActive(false);
                }
            }

        }
    }
}
