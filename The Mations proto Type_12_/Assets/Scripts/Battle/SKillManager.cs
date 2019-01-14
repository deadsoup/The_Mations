using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using UnityEngine.SceneManagement;



public class SKillManager : MonoBehaviour
{


    public int stun_per;
    public int sleep_per;
    public int burn_per;
    public int blood_per;
    public int Allbuff_Per;
    public int Strbuff_Per;

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
    battle Battle;

    GameObject actionGage;

    GameObject SkillPanel;
    GameObject Slotpanel;

    public GameObject skillslot;
    public GameObject skill;

    public List<Skill> SkillList = new List<Skill>();
    public List<Skill> SkillList2_save = new List<Skill>();

    internal GameObject[] playerSprite = new GameObject[3];

    /// <summary>
    /// 이펙트 관련
    /// </summary>
    public GameObject EffectSystem;
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;


    public GameObject Dark_berserker;
    public GameObject Hearts_Skill;
    public GameObject Awake_burning;
    public GameObject Infinite_manaring;
    public GameObject Loving_you;
    public GameObject Nightmare_lolubai;
    public GameObject only_one;
    public GameObject Pyrokinesis;
    public GameObject Rainpos_power;
    public GameObject Weidog_Skill;

    public GameObject AudioMG;


    GameObject InfoPanel;
    Image SkillIcon;
    Text Title;
    Text Need_Mp;
    Text Damage;
    Text Target;
    Text Attribute;
    Text Text;


    /*
    void saveJson()
    {
        SkillList2_save.Add(new Skill(0, "파이로", 40,"20과 20", "적군", "단일", "화상", "불마법"));
        SkillList2_save.Add(new Skill(1, "레인보우", 30, "없음", "아군", "단일", "없음", "자가버프마법"));
        SkillList2_save.Add(new Skill(2, "악몽", 80,"없음", "적군", "단일", "수면", "수면마법"));
        SkillList2_save.Add(new Skill(3, "마나링", 150, "없음", "아군", "광역", "없음","마나회복 마법"));
        SkillList2_save.Add(new Skill(4, "버닝", 200, "없음",  "아군", "광역", "없음",  "광역버프"));
        SkillList2_save.Add(new Skill(5, "온니 원", 100,"150", "적군", "단일", "없음", "뚝배기"));

        JsonData jsonData = JsonMapper.ToJson(SkillList2_save);

        File.WriteAllText(Application.streamingAssetsPath + "/SkillData.json", jsonData.ToString());
    }
   */



    public Skill SkillByID(int id)
    {
        for (int i = 0; i < SkillList.Count; i++)
        {
            if (SkillList[i].Id == id)
                return SkillList[i];
        }
        return null;
    }

    public void ContructSkill()
    {
        for (int i = 0; i < skilldata.Count; i++)
        {
            SkillList.Add(new Skill(
                (int)skilldata[i]["Id"],
                skilldata[i]["Name"].ToString(),
                (int)skilldata[i]["Need_MP"],
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

    public GameObject[] Effect = new GameObject[9];

    void Start()
    {
        slotAmount = 3;
        
        stun_per = 20;

        
        party = GameObject.Find("PartySystem").GetComponent<Party>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "Passway")
        {
            playerSprite[0] = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta1").transform.Find("Char1").gameObject;
            playerSprite[1] = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta2").transform.Find("Char2").gameObject;
            playerSprite[2] = GameObject.Find("Canvas").transform.Find("Status").transform.Find("Jin_Getta3").transform.Find("Char3").gameObject;



            InfoPanel = GameObject.Find("Canvas").transform.Find("Status").transform.Find("SkillSlot").transform.Find("SkillInfo").gameObject;
            SkillIcon = InfoPanel.transform.GetChild(1).GetComponent<Image>();
            Title = InfoPanel.transform.GetChild(2).GetComponent<Text>();
            Need_Mp = InfoPanel.transform.GetChild(3).GetComponent<Text>();
            Damage = InfoPanel.transform.GetChild(4).GetComponent<Text>();
            Target = InfoPanel.transform.GetChild(5).GetComponent<Text>();
            Attribute = InfoPanel.transform.GetChild(6).GetComponent<Text>();
            Text = InfoPanel.transform.GetChild(7).GetComponent<Text>();

        }

        if (SceneManager.GetActiveScene().name == "DH_Battle")
        {
            playerSprite[0] = GameObject.Find("Canvas").transform.Find("Jin_Getta1").transform.Find("Char1").gameObject;
            playerSprite[1] = GameObject.Find("Canvas").transform.Find("Jin_Getta2").transform.Find("Char2").gameObject;
            playerSprite[2] = GameObject.Find("Canvas").transform.Find("Jin_Getta3").transform.Find("Char3").gameObject;
            SkillScene = GameObject.Find("SkillScene").transform.Find("SkillAnimator").GetComponent<Animator>();
            SkillScene2 = GameObject.Find("SkillScene").transform.Find("SkillAnimator2").GetComponent<Animator>();
            SkillScene3 = GameObject.Find("SkillScene").transform.Find("SkillAnimator3").GetComponent<Animator>();
            SkillScene_Animator = GameObject.Find("SkillScene").transform.Find("SkillAnimator").GetComponent<Animator>().runtimeAnimatorController;

            Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();
            actionGage = GameObject.Find("Canvas").transform.Find("actionGage").gameObject;


            InfoPanel = GameObject.Find("Canvas").transform.Find("SkillSlot").transform.Find("SkillInfo").gameObject;
            SkillIcon = InfoPanel.transform.GetChild(1).GetComponent<Image>();
            Title = InfoPanel.transform.GetChild(2).GetComponent<Text>();
            Need_Mp = InfoPanel.transform.GetChild(3).GetComponent<Text>();
            Damage = InfoPanel.transform.GetChild(4).GetComponent<Text>();
            Target = InfoPanel.transform.GetChild(5).GetComponent<Text>();
            Attribute = InfoPanel.transform.GetChild(6).GetComponent<Text>();
            Text = InfoPanel.transform.GetChild(7).GetComponent<Text>();




            SkillPanel = GameObject.Find("Panel");
            Slotpanel = SkillPanel.transform.Find("slotPanel").gameObject;
        }
        //saveJson();
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

    public void Off()
    {
        InfoPanel.SetActive(false);
    }

    public void CheckStatus(string name)
    {
        InfoPanel.SetActive(true);
        for (int i = 0; i < skills.Count; i++)
        {
            if (slots[i].name == name)
            {

                    SkillIcon.sprite = skills[i].sprite;
                    Title.text = skills[i].Name;

                    Need_Mp.text = "소모 마나량 " + skills[i].Need_MP.ToString();
                    Damage.text = skills[i].Damage;
                    Target.text = skills[i].Target;
                    Attribute.text = skills[i].Attribute;
                    Text.text = skills[i].Text;

                    InfoPanel.transform.Find("Delete").gameObject.SetActive(true);
                    InfoPanel.transform.Find("Delete").GetComponent<Button>().onClick.RemoveAllListeners();
                    InfoPanel.transform.Find("Delete").GetComponent<Button>().onClick.AddListener(delegate () { deleteSkill(name); });
                    InfoPanel.transform.Find("Delete").GetComponent<Button>().onClick.AddListener(Off);
                    break;
                
            }



        }


    }

    public void CheckStatus_Uniqe()
    {
        InfoPanel.SetActive(true);
        for (int i = 0; i < skills.Count; i++)
        {
            if (skillButton[0].name == "아이돌 고유스킬")
            {
                SkillIcon.sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_idoll");
                Title.text = "러빙 유";

                Need_Mp.text = "50";
                Damage.text = "0";
                Target.text = "아군";
                Attribute.text = "광역";
                Text.text = "사랑스러운 노래로 \r\n팀원들을 복돋아 \r\n체력을 50 회복시킨다.";

                InfoPanel.transform.Find("Delete").gameObject.SetActive(false);
                break;
            }

            if (skillButton[0].name == "힘숨찐 고유스킬")
            {
                SkillIcon.sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_JJintta");
                Title.text = "다크 버서커";

                Need_Mp.text = "60";
                Damage.text = "40";
                Target.text = "적군";
                Attribute.text = "단일";
                Text.text = "흑염룡의 힘으로 \r\n적에게 40의 데미지를 입히고 \r\n 50%의 확률로 2턴간 기절 시킨다.";

                InfoPanel.transform.Find("Delete").gameObject.SetActive(false);
                break;
            }

            if (skillButton[0].name == "개 고유스킬")
            {
                SkillIcon.sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_Hartz_Transform");
                Title.text = "변신 : 하울링";

                Need_Mp.text = "0";
                Damage.text = "0";
                Target.text = "자신";
                Attribute.text = "단일";
                Text.text = "변신을 하여 큰 성채로 진화한다.";

                InfoPanel.transform.Find("Delete").gameObject.SetActive(false);
                break;
            }
            if (skillButton[0].name == "개 고유스킬2")
            {
                SkillIcon.sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_BigHartz_strike");
                Title.text = "후려치기";

                Need_Mp.text = "50";
                Damage.text = "40";
                Target.text = "적군";
                Attribute.text = "단일";
                Text.text = "발톱을 사용하여 상대를 강타한다.\r\n 40의 데미지를 입히고 60%의 확률로 \r\n 출혈을 일으킨다. ";

                InfoPanel.transform.Find("Delete").gameObject.SetActive(false);
                break;

            }

        }
    }




    public void UniqueSkill_Set(int num)
    {
        Debug.Log( "캐릭터 번호");
        if (num == 0)
        {
            skillButton[0].onClick.RemoveAllListeners();
            skillButton[0].onClick.AddListener(Idol_UniqueSkill);
            skillButton[0].name = "아이돌 고유스킬";
            skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_idoll");
        }

        if (num == 1)
        {
            skillButton[0].onClick.RemoveAllListeners();
            skillButton[0].onClick.AddListener(Nerd_UniqueSkill);
            skillButton[0].name = "힘숨찐 고유스킬";
            skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_JJintta");
        }

        if (num == 2)
        {
            Debug.Log("진입 성공 ");
            skillButton[0].onClick.RemoveAllListeners();
            skillButton[0].onClick.AddListener(Dog_UniqueSkill);
            skillButton[0].name = "개 고유스킬";
            skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_Hartz_Transform");
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
            int damage = 50 * (1 + (int)(npc.Wis[0] * 0.03) + (int)(npc.Mp[0] / 100));

            if (npc.actiongage >= 5f)
            {
                if (npc.Hp[battle.switching[0]] < (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]) 
                    || npc.Hp[battle.switching[1]] < (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]])
                    || npc.Hp[battle.switching[2]] < (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]))
                {
                    npc.Mp[0] -= 50;
                    npc.Hp[battle.switching[0]] += damage;
                    npc.Hp[battle.switching[1]] += damage;
                    npc.Hp[battle.switching[2]] += damage;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.actiongage -= 5f;

                    SkillScene.SetTrigger("Atk");

                    if (npc.Hp[battle.switching[0]] >= (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]))
                    { npc.Hp[battle.switching[0]] = (npc.MaxHp[battle.switching[0]] + npc.Equip_MaxHp[battle.switching[0]]); }

                    if (npc.Hp[battle.switching[1]] >= (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]]))
                    { npc.Hp[battle.switching[1]] = (npc.MaxHp[battle.switching[1]] + npc.Equip_MaxHp[battle.switching[1]]); }

                    if (npc.Hp[battle.switching[2]] >= (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]))
                    { npc.Hp[battle.switching[2]] = (npc.MaxHp[battle.switching[2]] + npc.Equip_MaxHp[battle.switching[2]]); }


                    GameObject Effect = Instantiate(Loving_you);
                    Effect.transform.SetParent(char1.transform);
                    Effect.transform.position = char1.transform.position;

                    GameObject Effect2 = Instantiate(Loving_you);
                    Effect2.transform.SetParent(char2.transform);
                    Effect2.transform.position = char2.transform.position;

                    GameObject Effect3 = Instantiate(Loving_you);
                    Effect3.transform.SetParent(char3.transform);
                    Effect3.transform.position = char3.transform.position;



                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Unique_Skill(0);
                    }

                        /*
                        itemObj.transform.SetParent(slots[i].transform);

                        itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                        //itemObj.transform.position = new Vector2(511, 249.6f);
                        itemObj.transform.position = slots[i].transform.position;
                        itemObj.name = itemToAdd.Name;
                        */

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
        if (npc.Mp[1] >= 60)
        {
            stun_per = 50;
            if (npc.actiongage >= 5f)
            {
                int damage = 40 * (1 + (int)(npc.Wis[1] * 0.03) + (int)(npc.Mp[1] / 100));

                if (stun_per >= Random.Range(1, 101))
                {

                    npc.Mp[1] -= 100;
                    npc.unitCondition[battle.i].condition_Stun = true;
                    npc.unitCondition[battle.i].left_Stun = 2;
                    npc.Hp[battle.i] -= damage;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.actiongage -= 5f;
                    Debug.Log("스턴 성공");
                    FloatingTextController.CreateFloatingText("스턴 !!"+40.ToString(), transform);

                    
                        GameObject Effect = Instantiate(Dark_berserker);
                        Effect.transform.SetParent(EffectSystem.transform);
                        Effect.transform.position = EffectSystem.transform.position;
                    

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Unique_Skill(1);
                    }
                }
                else
                {
                    npc.Mp[1] -= 100;
                    npc.Hp[battle.i] -= damage;
                    npc.actiongage -= 5f;
                    Debug.Log("스턴 실패");
                    FloatingTextController.CreateFloatingText(40.ToString(), transform);

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Unique_Skill(1);
                    }
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
        if (npc.Mp[2] >= 0)
        {
            if (npc.actiongage >= 5f)
            {

                npc.Mp[2] -= 0;
                actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                npc.actiongage -= 5f;
                FloatingTextController.CreateFloatingText4("변신", transform);

                if (playerSprite[0].GetComponent<Image>().sprite == Resources.Load<Sprite>("Charcter/CharAnimation/Hearts/Player_Hatz_idle"))
                {
                    playerSprite[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Charcter/CharAnimation/Hearts/Player_HatzTransform_idle");
                }

                if (playerSprite[1].GetComponent<Image>().sprite == Resources.Load<Sprite>("Charcter/CharAnimation/Hearts/Player_Hatz_idle"))
                {
                    playerSprite[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("Charcter/CharAnimation/Hearts/Player_HatzTransform_idle");
                }

                if (playerSprite[2].GetComponent<Image>().sprite == Resources.Load<Sprite>("Charcter/CharAnimation/Hearts/Player_Hatz_idle"))
                {
                    playerSprite[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("Charcter/CharAnimation/Hearts/Player_HatzTransform_idle");
                }

                skillButton[0].onClick.RemoveAllListeners();
                skillButton[0].onClick.AddListener(Dog_UniqueSkill2);
                skillButton[0].name = "개 고유스킬2";
                skillButton[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("Battle_Resource/SkillImage/Skill_BigHartz_strike");

                Battle.Dog_TransForm = true;
                SkillScene3.SetTrigger("Atk");

                if (SceneManager.GetActiveScene().name == "DH_Battle")
                {
                    AudioMG.GetComponent<AudioMG>().play_Unique_Skill(2);
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

    public void Dog_UniqueSkill2()
    {
        if (npc.Mp[2] >= 50)
        {
            burn_per = 60;
            if (npc.actiongage >= 5f)
            {
                if (burn_per >= Random.Range(1, 101))
                {

                    int damage = 40 * (1 + (int)(npc.Wis[2] * 0.03) + (int)(npc.Mp[2] / 100));

                    npc.Hp[battle.i] -= damage;
                    npc.Mp[2] -= 50;

                    Battle.monsterAbnomal_burn = true;
                    npc.unitCondition[battle.i].condition_Burn = true;
                    npc.unitCondition[battle.i].left_Burn = 2;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.actiongage -= 5f;
                    FloatingTextController.CreateFloatingText("출혈 !!" + 40.ToString(), transform);

                    GameObject Effect = Instantiate(Weidog_Skill);

                    Effect.transform.SetParent(EffectSystem.transform);

                    Effect.transform.position = EffectSystem.transform.position;

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Unique_Skill(3);
                    }

                }
                else
                {
                    npc.Mp[2] -= 100;
                    npc.Hp[battle.i] -= 40;
                    npc.actiongage -= 5f;
                    Debug.Log("스턴 실패");
                    FloatingTextController.CreateFloatingText( 40.ToString(), transform);
                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Unique_Skill(3);
                    }
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




    public void Skill_Noname(int id)
    {
        if (id == 0) // 파이로키네시스
        {
            Debug.Log("스킬 사용 진입");
            if (npc.Mp[battle.c] >= 40)
            {
                Debug.Log("마나 보유 확인");
                burn_per = 100;
                if (npc.actiongage >= 5f)
                {
                    if (burn_per >= Random.Range(1, 101))
                    {
                        Debug.Log("스킬 발도");


                        npc.Mp[battle.c] -= 40;
                        Battle.monsterAbnomal_burn = true;
                        npc.unitCondition[battle.i].condition_Burn = true;
                        npc.unitCondition[battle.i].left_Burn = 2;
                        actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                        npc.actiongage -= 5f;
                        Debug.Log("불탐 성공");
                        FloatingTextController.CreateFloatingText("화상 !!", transform);

                        GameObject Effect = Instantiate(Pyrokinesis);

                        Effect.transform.SetParent(EffectSystem.transform);

                        Effect.transform.position = EffectSystem.transform.position;

                        if (SceneManager.GetActiveScene().name == "DH_Battle")
                        {
                            AudioMG.GetComponent<AudioMG>().play_Skill(0);
                        }


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


        if (id == 1) //레인포스 파워
        {
            if (npc.Mp[battle.c] >= 30)
            {
                if (npc.actiongage >= 5f)
                {

                    int damage = 20 * (1 + (int)(npc.Wis[battle.c] * 0.03) + (int)(npc.Mp[battle.c] / 100));

                    npc.Mp[battle.c] -= 30;
                    npc.unitCondition[battle.c].condition_StrBuff = true;
                    npc.unitCondition[battle.c].left_StrBuff = 2;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.BuffStr[battle.c] = damage;
                    FloatingTextController.CreateFloatingText2("공격력 증가", transform);

                    if (Battle.Effect_Check == 0)
                    {
                        GameObject Effect = Instantiate(Rainpos_power);
                        Effect.transform.SetParent(char1.transform);
                        Effect.transform.position = char1.transform.position;
                    }
                    if (Battle.Effect_Check == 1)
                    {
                        GameObject Effect = Instantiate(Rainpos_power);
                        Effect.transform.SetParent(char2.transform);
                        Effect.transform.position = char2.transform.position;
                    }
                    if (Battle.Effect_Check == 2)
                    {
                        GameObject Effect = Instantiate(Rainpos_power);
                        Effect.transform.SetParent(char3.transform);
                        Effect.transform.position = char3.transform.position;
                    }

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Skill(1);
                    }


                }
                else if (npc.BuffStr[battle.c] == 20)
                {
                    Debug.Log("이미 버프 상태");
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


        if (id == 2) // 악몽
        {
            if (npc.Mp[battle.c] >= 80)
            {
                sleep_per = 100;
                if (npc.actiongage >= 5f)
                {
                    if (sleep_per >= Random.Range(1, 101))
                    {

                        npc.Mp[battle.c] -= 80;
                        npc.unitCondition[battle.i].condition_Sleep = true;
                        npc.unitCondition[battle.i].left_Sleep = 2;
                        actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                        npc.actiongage -= 5f;
                        Debug.Log("수면 성공");
                        FloatingTextController.CreateFloatingText("수면 !!" + 40.ToString(), transform);

                        GameObject Effect = Instantiate(Nightmare_lolubai);

                        Effect.transform.SetParent(EffectSystem.transform);

                        Effect.transform.position = EffectSystem.transform.position;


                        if (SceneManager.GetActiveScene().name == "DH_Battle")
                        {
                            AudioMG.GetComponent<AudioMG>().play_Skill(2);
                        }

                    }
                    else
                    {
                        npc.Mp[battle.c] -= 100;
                        npc.actiongage -= 5f;
                        Debug.Log("수면 실패");

                        if (SceneManager.GetActiveScene().name == "DH_Battle")
                        {
                            AudioMG.GetComponent<AudioMG>().play_Skill(2);
                        }

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



        if (id == 3)//마나링
        {
            if (npc.Mp[battle.c] >= 150)
            {
                if (npc.actiongage >= 5f)
                {
                    if (npc.Mp[battle.switching[0]] < (npc.MaxMp[battle.switching[0]] + npc.Equip_MaxMp[battle.switching[0]])
                        || npc.Mp[battle.switching[1]] < (npc.MaxMp[battle.switching[1]] + npc.Equip_MaxMp[battle.switching[1]])
                        || npc.Mp[battle.switching[2]] < (npc.MaxMp[battle.switching[2]] + npc.Equip_MaxMp[battle.switching[2]]))
                    {
                        int damage = 50 * (1 + (int)(npc.Wis[battle.c] * 0.03) + (int)(npc.Mp[battle.c] / 100));

                        npc.Mp[battle.c] -= 150;
                        npc.Mp[battle.switching[0]] += damage;
                        npc.Mp[battle.switching[1]] += damage;
                        npc.Mp[battle.switching[2]] += damage;
                        actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                        npc.actiongage -= 5f;


                        if (npc.Mp[battle.switching[0]] >= (npc.MaxMp[battle.switching[0]] + npc.Equip_MaxMp[battle.switching[0]]))
                        { npc.Mp[battle.switching[0]] = (npc.MaxMp[battle.switching[0]] + npc.Equip_MaxMp[battle.switching[0]]); }

                        if (npc.Mp[battle.switching[1]] >= (npc.MaxMp[battle.switching[1]] + npc.Equip_MaxMp[battle.switching[1]]))
                        { npc.Mp[battle.switching[1]] = (npc.MaxMp[battle.switching[1]] + npc.Equip_MaxMp[battle.switching[1]]); }

                        if (npc.Mp[battle.switching[2]] >= (npc.MaxMp[battle.switching[2]] + npc.Equip_MaxMp[battle.switching[2]]))
                        { npc.Mp[battle.switching[2]] = (npc.MaxMp[battle.switching[2]] + npc.Equip_MaxMp[battle.switching[2]]); }



                        GameObject Effect = Instantiate(Infinite_manaring);
                        Effect.transform.SetParent(char1.transform);
                        Effect.transform.position = char1.transform.position;

                        GameObject Effect2 = Instantiate(Infinite_manaring);
                        Effect2.transform.SetParent(char2.transform);
                        Effect2.transform.position = char2.transform.position;

                        GameObject Effect3 = Instantiate(Infinite_manaring);
                        Effect3.transform.SetParent(char3.transform);
                        Effect3.transform.position = char3.transform.position;

                        if (SceneManager.GetActiveScene().name == "DH_Battle")
                        {
                            AudioMG.GetComponent<AudioMG>().play_Skill(3);
                        }


                    }
                    else if (npc.Mp[battle.switching[0]] == (npc.MaxMp[battle.switching[0]] + npc.Equip_MaxMp[battle.switching[0]]) && npc.Mp[battle.switching[1]] == (npc.MaxMp[battle.switching[1]] + npc.Equip_MaxMp[battle.switching[1]]) && npc.Mp[battle.switching[2]] == (npc.MaxMp[battle.switching[2]] + npc.Equip_MaxMp[battle.switching[2]]))
                    {
                        Debug.Log("모든 캐릭터 풀마나");
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


        if (id == 4) //어웨이크 버닝
        {
            if (npc.Mp[battle.c] >= 200)
            {
                //battle.switching[Battle.Effect_Check]
                if (npc.actiongage >= 5f)
                {
                    int damage = 20 * (1 + (int)(npc.Wis[battle.c] * 0.03) + (int)(npc.Mp[battle.c] / 100));

                    npc.Mp[battle.c] -= 200;
                    npc.unitCondition[battle.c].condition_AllBuff = true;
                    npc.unitCondition[battle.c].left_AllBuff = 2;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.Allbuff[battle.switching[0]] = damage;
                    npc.Allbuff[battle.switching[1]] = damage;
                    npc.Allbuff[battle.switching[2]] = damage;
                    FloatingTextController.CreateFloatingText2("전 능력 강화", transform);
                    FloatingTextController.CreateFloatingText3("전 능력 강화", transform);
                    FloatingTextController.CreateFloatingText4("전 능력 강화", transform);

                    GameObject Effect = Instantiate(Awake_burning);
                    Effect.transform.SetParent(char1.transform);
                    Effect.transform.position = char1.transform.position;

                    GameObject Effect2 = Instantiate(Awake_burning);
                    Effect2.transform.SetParent(char2.transform);
                    Effect2.transform.position = char2.transform.position;

                    GameObject Effect3 = Instantiate(Awake_burning);
                    Effect3.transform.SetParent(char3.transform);
                    Effect3.transform.position = char3.transform.position;

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Skill(4);
                    }

                }
                else if (npc.Allbuff[battle.c] == 20)
                {
                    Debug.Log("이미 버프 상태");
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


        if (id == 5)
        {
            if (npc.Mp[battle.c] >= 100)
            {
                if (npc.actiongage >= 5f)
                {
                    int damage = 150 * (1 + (int)(npc.Wis[battle.c] * 0.03) + (int)(npc.Mp[battle.c] / 100));

                    npc.Mp[battle.c] -= 100;
                    actionGage.GetComponent<Image>().fillAmount -= 0.5f;
                    npc.actiongage -= 5f;
                    npc.Hp[battle.i] -= damage;
                    FloatingTextController.CreateFloatingText("싱귤러 스크라이크" + 150.ToString(), transform);


                    GameObject Effect = Instantiate(only_one);

                    Effect.transform.SetParent(EffectSystem.transform);

                    Effect.transform.position = EffectSystem.transform.position;

                    if (SceneManager.GetActiveScene().name == "DH_Battle")
                    {
                        AudioMG.GetComponent<AudioMG>().play_Skill(5);
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


        if (id == 7)
        {
            Debug.Log("테스트스킬7");
        }
        if (id == 8)
        {
            Debug.Log("테스트스킬8");
        }


    }


}

[System.Serializable]
public class Skill
{
    public int Id;
    public string Name;
    public int Need_MP;
    public string Damage;
    public string Target;
    public string Attribute;
    public string Abnomal; 
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