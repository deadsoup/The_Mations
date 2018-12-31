using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.IO;

public class SaveBattleScene : MonoBehaviour
{
    public List<BattleInfo> battleSave = new List<BattleInfo>();
    battle Battle;
    Inven inven;
    GameObject[] invenslot = new GameObject[4];
    SKillManager skill;
    npc Npc;
    //GameObject invenslot;

        /*
    void saveJson()
    {
        battleSave.Add(new BattleInfo(npc.Id[battle.switching[0]], npc.name[battle.switching[0]], npc.MaxHp[battle.switching[0]],npc.Hp[battle.switching[0]],
                        npc.MaxMp[battle.switching[0]], npc.Mp[battle.switching[0]], npc.Str[battle.switching[0]], npc.Wis[battle.switching[0]],
                        npc.ArchivePoint[0],
                        npc.Equip_MaxHp[battle.switching[0]],npc.Equip_MaxMp[battle.switching[0]],npc.Equip_Str[battle.switching[0]],npc.Equip_Wis[battle.switching[0]],
                        invenslot[0].transform.GetChild(0).GetComponent<ItemData>().equip.Id, invenslot[0].transform.GetChild(0).GetComponent<ItemData>().amount,
                        invenslot[1].transform.GetChild(0).GetComponent<ItemData>().equip.Id, invenslot[1].transform.GetChild(0).GetComponent<ItemData>().amount,
                        invenslot[2].transform.GetChild(0).GetComponent<ItemData>().equip.Id, invenslot[2].transform.GetChild(0).GetComponent<ItemData>().amount,
                        invenslot[3].transform.GetChild(0).GetComponent<ItemData>().equip.Id, invenslot[3].transform.GetChild(0).GetComponent<ItemData>().amount,

                        );
        battleSave.Add(new BattleInfo(1, 1, "톱", "보통", "목재용 톱. 피해량 + 1", 0, 0, 0, 0, 1, 0, 0, "W_Sword007", false));
        battleSave.Add(new BattleInfo(2, 1, "권총", "보통", "소구경 권총. 피해량 + 2", 0, 0, 0, 0, 2, 0, 0, "W_Gun001", false));
        battleSave.Add(new BattleInfo(3, 1, "장검", "고급", "서양식 양날검. 피해량 + 3", 0, 0, 0, 0, 3, 0, 0, "W_Sword001", false));
        battleSave.Add(new BattleInfo(4, 1, "레이저검", "고급", "**워즈의 광선검. 피해량 + 3", 0, 0, 0, 0, 3, 0, 0, "W_Sword017", false));
        battleSave.Add(new BattleInfo(5, 1, "병건", "희귀", "병-건. 피해량 + 4", 0, 0, 0, 0, 4, 0, 0, "I_Cannon01", false));

        battleSave.Add(new BattleInfo(30, 3, "체력약", "보통", "응급처치약이다. 회복량 + 50", 0, 50, 0, 0, 4, 0, 0, "I_Cannon01", true));

        JsonData jsonData = JsonMapper.ToJson(battleSave);

        File.WriteAllText(Application.dataPath + "/battleSaveData.json", jsonData.ToString());
    }
    */



    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("Canvas").transform.Find("Inven").GetComponent<Inven>();
        skill = GameObject.Find("SKillManager").GetComponent<SKillManager>();
        Npc = GameObject.Find("EventSystem").GetComponent<npc>();
        Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();

        invenslot[0] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots0").gameObject;
        invenslot[1] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots1").gameObject;
        invenslot[2] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots2").gameObject;
        invenslot[3] = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("Panel").transform.Find("slots3").gameObject;
    }

}

[System.Serializable]
public class BattleInfo // 캐릭터 슬롯칸에 저장시킬 것
{
    public int Id; // 저장시킬 캐릭터의 아이디
    public string Name; // 캐릭터의 명칭
    public int MaxHp; // 캐릭터의 최대 체력
    public int Hp; // 캐릭터의 체력
    public int MaxMp;
    public int Mp;
    public int Str;
    public int Wis;
    public int ArchivePoint; // 플레이어의 소지 업적 포인트 [0]에다 저장함

    public int Equip_MaxHp;
    public int Equip_MaxMp;
    public int Equip_Str;
    public int Equip_Wis;

    public int Inven1;
    public int Inven1_Amount;

    public int Inven2;
    public int Inven2_Amount;

    public int Inven3;
    public int Inven3_Amount;

    public int Inven4;
    public int Inven4_Amount;

    public int Skill1_ID;
    public bool Skill1_Active;

    public int Skill2_ID;
    public bool Skill2_Active;

    public int Skill3_ID;
    public bool Skill3_Active;


    public BattleInfo(int id, string name, int maxhp, int hp, int maxmp, int mp, int str, int wis, int archivepoint, int equip_maxhp, int equip_maxmp, int equip_str, int equip_wis,
                    int inven1, int inven1_amount, int inven2, int inven2_amount, int inven3, int inven3_amount, int inven4, int inven4_amount,
                    int skill1_id, bool skill1_active)
    {


    }


}
