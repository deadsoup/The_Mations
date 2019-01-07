using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Skill
{
    public int Id;
    public string Name;
    public int Need_MP;
    public string Damage;
    public string Target;
    public string Attribute; // 속성
    public string Abnomal; // 상태이상
    public string Text;

    
    public Sprite sprite;

    public Skill(int id, string name, int need_mp, string damage, string target, string attribute, string abnomal, string text)
    {
        Id = id;
        Name = name;
        Need_MP = need_mp;
        Damage = damage;
        Target = target;
        Attribute = attribute;
        Abnomal = abnomal;
        Text = text;

        sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/" + Id);
    }
    public Skill()
    {
        Id = -1;
    }

}

public class SKillManager : MonoBehaviour
{


    public int stun_per;
    public int sleep_per;
    public int burn_per;
    private JsonData skilldata;

    bool[] P1_skillON = new bool[4];
    bool[] P2_skillON = new bool[4];
    bool[] P3_skillON = new bool[4];
    bool[] P4_skillON = new bool[4];

    public Button[] skillButton = new Button[4];

    internal Animator SkillScene;
    internal Animator SkillScene2;
    internal Animator SkillScene3;
    internal RuntimeAnimatorController SkillScene_Animator;

    Party party;
    npc Npc;
    GameObject actionGage;

    GameObject SkillPanel;
    GameObject Slotpanel;

    public GameObject skillslot;
    public GameObject skill;

    public List<Skill> SkillList = new List<Skill>();

    internal GameObject[] playerSprite = new GameObject[3];






    public Skill SkillByID(int id)
    {
        for (int i = 0; i < SkillList.Count; i++)
        {
            if (SkillList[i].Id == id)
                return SkillList[i];
        }
        return null;
    }

    void ContructSkill()
    {
        for (int i = 0; i < skilldata.Count; i++)
        {
            SkillList.Add(new Skill(
                (int)skilldata[i]["Id"],
                skilldata[i]["Name"].ToString(),
                (int)skilldata[i]["Need_Mp"],
                skilldata[i]["Damage"].ToString(),
                skilldata[i]["Target"].ToString(),
                skilldata[i]["Attribute"].ToString(),
                skilldata[i]["Abnomal"].ToString(),
                skilldata[i]["Text"].ToString()
                ));
        }
    }

    public List<Skill> skills = new List<Skill>();
    public List<GameObject> slots = new List<GameObject>();

    int slotAmount;

    void load()
    {
        string filePath = Application.streamingAssetsPath + "/SkillData.json";
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
        skilldata = JsonMapper.ToObject(jsonString);
    }



    void Start()
    {
        slotAmount = 3;
        
        stun_per = 20;

        party = GameObject.Find("PartySystem").GetComponent<Party>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();

        playerSprite[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").transform.Find("Char1").gameObject;
        playerSprite[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").transform.Find("Char2").gameObject;
        playerSprite[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").transform.Find("Char3").gameObject;
        SkillScene = GameObject.Find("SkillScene").transform.Find("SkillAnimator").GetComponent<Animator>();
        SkillScene2 = GameObject.Find("SkillScene").transform.Find("SkillAnimator2").GetComponent<Animator>();
        SkillScene3 = GameObject.Find("SkillScene").transform.Find("SkillAnimator3").GetComponent<Animator>();
        SkillScene_Animator = GameObject.Find("SkillScene").transform.Find("SkillAnimator").GetComponent<Animator>().runtimeAnimatorController;

        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            actionGage = GameObject.Find("Canvas").transform.Find("actionGage").gameObject;
        }
        //skillButton[0].onClick.AddListener(skill1);
        //skillButton1.onClick.RemoveAllListeners();

        //Npc.SkillTriggers[0].skill[1] = true;

        SkillPanel = GameObject.Find("Panel");
        Slotpanel = SkillPanel.transform.Find("slotPanel").gameObject;


        //skilldata = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "/Json/SkillData.json"));
        load();
        ContructSkill();





        for (int i = 0; i < slotAmount; i++)
        {
            skills.Add(new Skill());
            //slots.Add(Instantiate(skillslot));
            slots[i].GetComponent<skillSlot>().id = i;
            //slots[i].name = "skillSlot" + (2+i).ToString();
            //slots[i].transform.SetParent(Slotpanel.transform);
        }



       // Debug.Log("스킬 트리거 체크" + Npc.SkillTriggers[0].skill[4]);
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
                    skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_Pyrokinesis");
                }

                if (battle.switching[num] == 1)
                {
                    skillButton[0].onClick.RemoveAllListeners();
                    skillButton[0].onClick.AddListener(Nerd_UniqueSkill);
                    skillButton[0].name = "힘숨찐 고유스킬";
                    skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_Nightmare lullaby");
                }

                if (battle.switching[num] == 2)
                {
                    skillButton[0].onClick.RemoveAllListeners();
                    skillButton[0].onClick.AddListener(Dog_UniqueSkill);
                    skillButton[0].name = "개 고유스킬";
                    skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_Nightmare lullaby");
                }


            }


        }

    }

    public void AddSkill(int id)
    {
        Skill skillToAdd = SkillByID(id);
        for (int i = 0; i < skills.Count; i++)
        {
            if (skills[i].Id == -1)
            {
                skills[i] = skillToAdd;
                GameObject itemObj = Instantiate(skill);
                itemObj.GetComponent<SkillData>().skill = skillToAdd;
                itemObj.GetComponent<SkillData>().slot = i;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Button>().onClick.RemoveAllListeners();
                itemObj.GetComponent<Button>().onClick.AddListener(delegate() { Skill_Noname(id); });
                itemObj.GetComponent<Image>().sprite = skillToAdd.sprite;
                itemObj.transform.position = slots[i].transform.position;
                itemObj.name = "획득 스킬" + id.ToString();

                Debug.Log("없는 대상" + i);
                break;

            }

        }
    }

    public void deleteSkill(string name)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (slots[i].name == name)
            {
                print("이름 찾기 성공");
                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                if (slots[i].transform.childCount > 0)
                {
                    var children = slots[i].GetComponentInChildren<SkillData>();
                    GameObject obj = children.gameObject;
                    for (int skillNum = 0; skillNum < 15; skillNum++)
                    {
                        print("포문 입장 성공" + skillNum);
                        if (slots[i].GetComponentInChildren<SkillData>().skill.Id == skillNum) //&& Npc.SkillTriggers[battle.c].skill[skillNum] == true
                        {
                            print("이프문 입장 성공" + skillNum);
                            Debug.Log(slots[i].GetComponentInChildren<SkillData>().skill.Id);
                            Npc.SkillTriggers[battle.c].skill[skillNum] = false;
                            Destroy(obj);
                            skills[i] = new Skill();
                            break;
                        }
                    }
                }
                if (slots[i].transform.childCount == 0)
                {
                    break;
                }


            }

        }

    }

    public void resetSkill(string name)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (slots[i].name == name)
            {
                print("이름 찾기 성공");
                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                if (slots[i].transform.childCount > 0)
                {
                    var children = slots[i].GetComponentInChildren<SkillData>();
                    GameObject obj = children.gameObject;
                    for (int skillNum = 0; skillNum < 15; skillNum++)
                    {
                        print("포문 입장 성공" + skillNum);
                        if (slots[i].GetComponentInChildren<SkillData>().skill.Id == skillNum) //&& Npc.SkillTriggers[battle.c].skill[skillNum] == true
                        {
                            print("이프문 입장 성공" + skillNum);
                            Debug.Log(slots[i].GetComponentInChildren<SkillData>().skill.Id);
                            Destroy(obj);
                            skills[i] = new Skill();
                            break;
                        }
                    }
                }
                if (slots[i].transform.childCount == 0)
                {
                    break;
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

                    SkillScene.SetTrigger("Atk");

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

                SkillScene2.SetTrigger("Atk");

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

    public void Dog_UniqueSkill()
    {
        if (npc.Mp[2] >= 100)
        {
            if (npc.actiongage >= 5f)
            {

                npc.Mp[2] -= 100;
                actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                npc.actiongage -= 5f;
                FloatingTextController.CreateFloatingText2("변신", transform);
                playerSprite[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("Charcter/CharAnimation/Dog/Player_Dog_idle");

                skillButton[0].onClick.RemoveAllListeners();
                skillButton[0].onClick.AddListener(Dog_UniqueSkill2);
                skillButton[0].name = "개 고유스킬2";
                skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_Pyrokinesis");

                SkillScene3.SetTrigger("Atk");

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

    public void Dog_UniqueSkill2()
    {
        if (npc.Mp[2] >= 0)
        {
            if (npc.actiongage >= 5f)
            {
                Debug.Log("개 스킬 발동");
                npc.Mp[2] -= 0;
                actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                npc.actiongage -= 5f;
                npc.Hp[battle.i] -= 40;
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




    public void Skill_Noname(int id)
    {
        if (id == 1)
        {
            Debug.Log("테스트스킬1");
        }
        if (id == 2)
        {
            Debug.Log("테스트스킬2");
        }
        if (id == 3)
        {
            Debug.Log("테스트스킬3");
        }
        if (id == 4)
        {
            Debug.Log("테스트스킬4");
        }
        if (id == 5)
        {
            Debug.Log("테스트스킬5");
        }
        if (id == 6)
        {
            Debug.Log("테스트스킬6");
        }
        if (id == 7)
        {
            Debug.Log("테스트스킬7");
        }
        if (id == 8)
        {
            Debug.Log("테스트스킬8");
        }


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
