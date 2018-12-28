using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKillManager : MonoBehaviour
{

    public int stun_per;
    public int sleep_per;
    public int burn_per;
    public struct skillSetting
    {

    }
    bool[] P1_skillON = new bool[4];
    bool[] P2_skillON = new bool[4];
    bool[] P3_skillON = new bool[4];
    bool[] P4_skillON = new bool[4];

    public Button[] skillButton = new Button[4];
    public skillSetting[] skill = new skillSetting[4];
    Party party;
    npc Npc;
    GameObject actionGage;
    void Start()
    {
        stun_per = 20;

        party = GameObject.Find("PartySystem").GetComponent<Party>();
        actionGage = GameObject.Find("Canvas").transform.Find("actionGage").gameObject;
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();
        //skillButton[0].onClick.AddListener(skill1);
        //skillButton1.onClick.RemoveAllListeners();
        
        Npc.SkillTriggers[0].skill[1] = true;
        Npc.SkillTriggers[1].skill[2] = true;
        
    }

    void Update()
    {


    }

    public void UniqueSkill_Set(int num)
    {
        for (int i = 0; i < party.playerSlot.Length; i++)
        {
            if (battle.switching[i] == battle.switching[num])
            {
                if (battle.switching[num] == 0)
                {
                    skillButton[0].onClick.RemoveAllListeners();
                    skillButton[0].onClick.AddListener(Idol_UniqueSkill);
                    skillButton[0].name = "아이돌 고유스킬";
                }

                if (battle.switching[num] == 1)
                {
                    skillButton[0].onClick.RemoveAllListeners();
                    skillButton[0].onClick.AddListener(Nerd_UniqueSkill);
                    skillButton[0].name = "힘숨찐 고유스킬";
                }

            }


        }

    }

    public void Skill1_Set(int num) //  해당 캐릭터[번호].스킬[번호]의 획득여부 
    {
        for (int i = 0; i < party.playerSlot.Length; i++)
        {
            if (battle.switching[i] == battle.switching[num])
            {
                if (battle.switching[num] == 0)
                {
                    Debug.Log(Npc.SkillTriggers[i].skill[1]);
                    if (Npc.SkillTriggers[i].skill[1] == true)
                    {
                        skillButton[1].onClick.RemoveAllListeners();
                        P1_skillON[1] = true;
                        skillButton[1].onClick.AddListener(Skill1_Noname);
                        skillButton[1].name = "테스트 스킬1";
                        Debug.Log("스킬 트리거"+i+"스킬 1번");
                        break;
                    }
                    if (Npc.SkillTriggers[i].skill[2] == true)
                    {
                        skillButton[1].onClick.RemoveAllListeners();
                        P1_skillON[1] = true;
                        skillButton[1].onClick.AddListener(Skill2_Noname);
                        skillButton[1].name = "테스트 스킬2";
                        Debug.Log("스킬 트리거" + i + "스킬 2번");
                        break;
                    }
                }

                if (battle.switching[num] == 1)
                {
                    if (Npc.SkillTriggers[i].skill[1] == true && P2_skillON[1] == false)
                    {
                        skillButton[1].onClick.RemoveAllListeners();
                        skillButton[1].onClick.AddListener(Skill1_Noname);
                        skillButton[1].name = "테스트 스킬1";
                        Debug.Log("스킬 트리거" + i + "스킬 1번");
                        break;
                    }
                    if (Npc.SkillTriggers[i].skill[2] == true && P2_skillON[1] == false)
                    {
                        skillButton[1].onClick.RemoveAllListeners();
                        skillButton[1].onClick.AddListener(Skill2_Noname);
                        skillButton[1].name = "테스트 스킬2";
                        Debug.Log("스킬 트리거" + i + "스킬 2번");
                        break;
                    }
                }

            }


        }

    }

    public void Skill2_Set(int num)
    {
        for (int i = 0; i < party.playerSlot.Length; i++)
        {
            if (battle.switching[i] == battle.switching[num])
            {
                if (battle.switching[num] == 0)
                {
                    if (Npc.SkillTriggers[i].skill[1] == true && P1_skillON[2] == false)
                    {
                        skillButton[2].onClick.RemoveAllListeners();
                        P1_skillON[2] = true;
                        skillButton[2].onClick.AddListener(Skill1_Noname);
                        skillButton[2].name = "테스트 스킬1";
                        Debug.Log("스킬 트리거" + i + "스킬 1번");
                        break;
                    }
                    if (Npc.SkillTriggers[i].skill[2] == true && P1_skillON[2] == false)
                    {
                        skillButton[2].onClick.RemoveAllListeners();
                        P1_skillON[2] = true;
                        skillButton[2].onClick.AddListener(Skill2_Noname);
                        skillButton[2].name = "테스트 스킬2";
                        Debug.Log("스킬 트리거" + i + "스킬 2번");
                        break;
                    }
                }

                if (battle.switching[num] == 1)
                {
                    if (Npc.SkillTriggers[i].skill[1] == true && P2_skillON[2] == false)
                    {
                        skillButton[2].onClick.RemoveAllListeners();
                        P2_skillON[2] = true;
                        skillButton[2].onClick.AddListener(Skill1_Noname);
                        skillButton[2].name = "테스트 스킬1";
                        Debug.Log("스킬 트리거" + i + "스킬 1번");
                        break;
                    }
                    if (Npc.SkillTriggers[i].skill[2] == true && P2_skillON[2] == false)
                    {
                        skillButton[2].onClick.RemoveAllListeners();
                        P2_skillON[2] = true;
                        skillButton[2].onClick.AddListener(Skill2_Noname);
                        skillButton[2].name = "테스트 스킬2";
                        Debug.Log("스킬 트리거" + i + "스킬 2번");
                        break;
                    }
                }

            }


        }

    }









    public void Idol_UniqueSkill()
    {


        if (npc.Mp[0] >= 50)
        {
            if (npc.actiongage >= 5f)
            {
                if (npc.Hp[battle.switching[0]] < (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]) 
                    || npc.Hp[battle.switching[1]] < (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]])
                    || npc.Hp[battle.switching[2]] < (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]))
                {
                    npc.Mp[0] -= 50;
                    npc.Hp[battle.switching[0]] += 50;
                    npc.Hp[battle.switching[1]] += 50;
                    npc.Hp[battle.switching[2]] += 50;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.actiongage -= 5f;

                    if (npc.Hp[battle.switching[0]] >= (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]))
                    { npc.Hp[battle.switching[0]] = (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]); }

                    if (npc.Hp[battle.switching[1]] >= (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]]))
                    { npc.Hp[battle.switching[1]] = (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]]); }

                    if (npc.Hp[battle.switching[2]] >= (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]))
                    { npc.Hp[battle.switching[2]] = (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]); }
                }
                else if (npc.Hp[battle.switching[0]] == (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]) && npc.Hp[battle.switching[1]] == (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]]) && npc.Hp[battle.switching[2]] == (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]))
                {
                    Debug.Log("모든 캐릭터 풀피");
                }
            }
            else
            {
                Debug.Log("행동력 부족");
            }
        }
        else
        {
            Debug.Log("마나 부족");
        }
    }

    public void Nerd_UniqueSkill()
    {
        if (npc.Mp[1] >= 100)
        {
            stun_per = 100;
            if (npc.actiongage >= 5f)
            {
                if (stun_per >= Random.Range(1, 101))
                {
                    npc.Mp[1] -= 100;
                    npc.unitCondition[battle.i].condition_Stun = true;
                    npc.unitCondition[battle.i].left_Stun = 2;
                    npc.Hp[battle.i] -= 40;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.actiongage -= 5f;
                    Debug.Log("스턴 성공");
                    FloatingTextController.CreateFloatingText("스턴 !!"+40.ToString(), transform);
                }
                else
                {
                    npc.Mp[1] -= 100;
                    npc.Hp[battle.i] -= 40;
                    npc.actiongage -= 5f;
                    Debug.Log("스턴 실패");
                    FloatingTextController.CreateFloatingText(40.ToString(), transform);
                }
            }
            else
            {
                Debug.Log("행동력 부족");
            }
        }
        else
        {
            Debug.Log("마나 부족");
        }
    }

    public void Skill1_Noname()
    {
        Debug.Log("테스트스킬1");
    }

    public void Skill2_Noname()
    {
        Debug.Log("테스트스킬2");
    }

    public void Skill3_Noname()
    {
        Debug.Log("테스트스킬3");
    }

    public void Skill4_Noname()
    {
        Debug.Log("테스트스킬4");
    }
    public void Skill5_Noname()
    {
        Debug.Log("테스트스킬5");
    }

    public void Skill6_Noname()
    {
        Debug.Log("테스트스킬6");
    }

    public void Skill7_Noname()
    {
        Debug.Log("테스트스킬7");
    }

    public void Skill8_Noname()
    {
        Debug.Log("테스트스킬8");
    }

}
