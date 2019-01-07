using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{

    /*
    public static int Id ;
    public static string Name;
    public static string Text;
    public static int MaxHp;
    public static int MaxMp;
    public static int Str;
    public static int Dex;
    public static int Wis;

    public Inven(int id, string name, string text, int maxHp, int maxMp, int str, int dex, int wis)
    {
        Id = id;
        Name = name;
        Text = text;
        MaxHp = maxHp;
        MaxMp = maxMp;
        Str = str;
        Dex = dex;
        Wis = wis;
    }
    */
    //public List<Inven> InvenList = new List<Inven>();

    GameObject Invenpanel;
    GameObject Slotpanel;
    GameObject Slotpanel2;
    GameObject Slotpanel3;

    ItemDatabase database;

    public GameObject InvenSlot;
    public GameObject InvenItem;

    public GameObject UsePanel;

    GameObject UseText;

    GameObject InfoPanel;
    Image ItemIcon;
    Text Title;
    Text Type;
    Text Grade;
    Text Option;
    Text Text;



    public List<Equip> items = new List<Equip>();
    public List<GameObject> slots = new List<GameObject>();

    public List<Equip> items2 = new List<Equip>();
    public List<GameObject> slots2 = new List<GameObject>();

    public List<Equip> items3 = new List<Equip>();
    public List<GameObject> slots3 = new List<GameObject>();

    int slotAmount;
    int randomAdd;
    int randomAdd1;
    int randomAdd2;

    int P1_ItemslotCount;
    int P2_ItemslotCount;
    int P3_ItemslotCount;

    private void Awake()
    {
        Invenpanel = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").gameObject;
        Slotpanel = Invenpanel.transform.Find("Panel").gameObject;
        Slotpanel2 = Invenpanel.transform.Find("Panel2").gameObject;
        Slotpanel3 = Invenpanel.transform.Find("Panel3").gameObject;
        UseText = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("BackPanel").transform.Find("UsePanel").transform.Find("Text").gameObject;
        InfoPanel = GameObject.Find("Canvas").transform.Find("Inven").transform.Find("ItemInfo").gameObject;
        ItemIcon = InfoPanel.transform.GetChild(0).GetComponent<Image>();
        Title = InfoPanel.transform.GetChild(1).GetComponent<Text>();
        Type = InfoPanel.transform.GetChild(2).GetComponent<Text>();
        Grade = InfoPanel.transform.GetChild(3).GetComponent<Text>();
        Option = InfoPanel.transform.GetChild(4).GetComponent<Text>();
        Text = InfoPanel.transform.GetChild(5).GetComponent<Text>();
    }


    // Start is called before the first frame update
    void Start()
    {

        database = GetComponent<ItemDatabase>();
        slotAmount = 4;
        randomAdd = Random.Range(0, 6);
        randomAdd1 = Random.Range(0, 6);
        randomAdd2 = Random.Range(0, 6);


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Equip());
            slots.Add(Instantiate(InvenSlot));
            slots[i].GetComponent<slot>().id = i;
            slots[i].name = "slots" + i.ToString();
            slots[i].transform.SetParent(Slotpanel.transform);

            items2.Add(new Equip());
            slots2.Add(Instantiate(InvenSlot));
            slots2[i].GetComponent<slot>().id = (i + 4);
            slots2[i].name = "slots" + (i + 4).ToString();
            slots2[i].transform.SetParent(Slotpanel2.transform);

            items3.Add(new Equip());
            slots3.Add(Instantiate(InvenSlot));
            slots3[i].GetComponent<slot>().id = (i + 8);
            slots3[i].name = "slots" + (i + 8).ToString();
            slots3[i].transform.SetParent(Slotpanel3.transform);
            print(i + "번 완료");
        }

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



    }

    private void Update()
    {
        // 아이템추가
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(51);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItem2(51);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItem3(51);
        }
    }
    // 아이템 삭제 - 문자열을 사용한다 - "slots0, slots1" 이걸 삭제함
    public void deleteItem(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (slots[i].name == name)
            {
                // 아이템 삭제전 플레이어 능력치 감소
                Remove_Status(battle.switching[0], items[i]);

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                items[i] = new Equip();
                InfoPanel.SetActive(false);
                break;
            }
            if (slots2[i].name == name)
            {
                // 아이템 삭제전 플레이어 능력치 감소
                Remove_Status(battle.switching[1], items2[i]);

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots2[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                items2[i] = new Equip();
                InfoPanel.SetActive(false);
                break;
            }
            if (slots3[i].name == name)
            {
                // 아이템 삭제전 플레이어 능력치 감소
                Remove_Status(battle.switching[2], items3[i]);

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots3[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                items3[i] = new Equip();
                InfoPanel.SetActive(false);
                break;
            }

        }

    }

    //각 플레이어마다 아이템 사용하는 법

    public void Use(int a)
    {
        Equip itemToAdd = database.FetchItemByID(a);
        if (a == 51)
        {
            UsePanel.SetActive(true);
            UseText.GetComponent<Text>().text = itemToAdd.Text + "\r\n 아이템을 사용하겠습니까? ";
        }
    }


    public void UsePotion() // 플레이어1의 사용하기
    {
        Equip itemToAdd = database.FetchItemByID(51);
        if (Slotpanel.activeInHierarchy == true)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == "진통제" && slots[i].transform.GetChild(0).GetComponent<ItemData>().amount >= 0)
                {
                    
                    items[i] = itemToAdd;
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount--;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Add_Status(battle.switching[0], itemToAdd);
                    print(itemToAdd.Hp);

                    if (npc.Hp[battle.switching[0]] >= npc.MaxHp[battle.switching[0]])
                    {
                        npc.Hp[battle.switching[0]] = npc.MaxHp[battle.switching[0]];
                    }


                    if (data.amount <= 0)
                    {
                        // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                        var children = slots[i].GetComponentInChildren<ItemData>();
                        GameObject obj = children.gameObject;
                        Destroy(obj);
                        // 아이템정보 초기화 (id -1로변경)
                        items[i] = new Equip();
                        break;


                    }
                }



            }
        }
        if (Slotpanel2.activeInHierarchy == true) // 플레이어2의 사용하기
        {
            for (int i = 0; i < items2.Count; i++)
            {
                if (items2[i].Name == "진통제" && slots2[i].transform.GetChild(0).GetComponent<ItemData>().amount >= 0)
                {
                    items2[i] = itemToAdd;
                    ItemData data = slots2[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount--;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Add_Status(battle.switching[1], itemToAdd);
                    print(itemToAdd.Hp);

                    if (npc.Hp[battle.switching[1]] >= npc.MaxHp[battle.switching[1]])
                    {
                        npc.Hp[battle.switching[1]] = npc.MaxHp[battle.switching[1]];
                    }


                    if (data.amount <= 0)
                    {
                        // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                        var children = slots2[i].GetComponentInChildren<ItemData>();
                        GameObject obj = children.gameObject;
                        Destroy(obj);
                        // 아이템정보 초기화 (id -1로변경)
                        items2[i] = new Equip();
                        break;


                    }
                }
            }
        }
        if (Slotpanel3.activeInHierarchy == true) // 플레이어 3의 사용하기
        {
            for (int i = 0; i < items3.Count; i++)
            {
                if (items3[i].Name == "진통제" && slots3[i].transform.GetChild(0).GetComponent<ItemData>().amount >= 0)
                {
                    items3[i] = itemToAdd;
                    ItemData data = slots3[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount--;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Add_Status(battle.switching[2], itemToAdd);
                    print(itemToAdd.Hp);

                    if (npc.Hp[battle.switching[2]] >= npc.MaxHp[battle.switching[2]])
                    {
                        npc.Hp[battle.switching[2]] = npc.MaxHp[battle.switching[2]];
                    }


                    if (data.amount <= 0)
                    {
                        // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                        var children = slots3[i].GetComponentInChildren<ItemData>();
                        GameObject obj = children.gameObject;
                        Destroy(obj);
                        // 아이템정보 초기화 (id -1로변경)
                        items3[i] = new Equip();
                        break;


                    }
                }
            }
        }
    }



    public void AddItem(int id)
    {
        Equip itemToAdd = database.FetchItemByID(id);
        if (itemToAdd.Stackable && Check_Item_In_Inventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Debug.Log("이미있는 대상");
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(InvenItem);
                    itemObj.GetComponent<ItemData>().equip = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);

                    itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                    //itemObj.transform.position = new Vector2(511, 249.6f);
                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.name = itemToAdd.Name;
                    Debug.Log("없는 대상" + i);

                    if (items[i].Id < 50)
                    {
                        Add_Status(battle.switching[0], itemToAdd);
                    }
                    break;



                }

            }
        }
    }

    public void AddItem2(int id)
    {
        Equip itemToAdd = database.FetchItemByID(id);
        if (itemToAdd.Stackable && Check_Item_In_Inventory2(itemToAdd))
        {
            for (int i = 0; i < items2.Count; i++)
            {
                if (items2[i].Id == id)
                {
                    ItemData data = slots2[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Debug.Log("이미있는 대상");
                }
            }
        }
        else
        {
            for (int i = 0; i < items2.Count; i++)
            {
                Debug.Log("첫 포문 입장" + i);
                if (items2[i].Id == -1)
                {
                    Debug.Log("이프문 입장" + i);
                    if (P2_ItemslotCount < 4)
                    {
                        Debug.Log("두번째 이프문 입장" + i);
                        P2_ItemslotCount++;
                        items2[i] = itemToAdd;
                        GameObject itemObj = Instantiate(InvenItem);
                        itemObj.GetComponent<ItemData>().equip = itemToAdd;
                        itemObj.GetComponent<ItemData>().slot = i;
                        itemObj.transform.SetParent(slots2[i].transform);

                        itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                        //itemObj.transform.position = new Vector2(511, 249.6f);
                        itemObj.transform.position = slots2[i].transform.position;
                        itemObj.name = itemToAdd.Name;
                        Debug.Log("없는 대상" + i);

                        if (items2[i].Id < 50)
                        {
                            Add_Status(battle.switching[1], itemToAdd);
                        }
                        break;
                    }
                    else
                    {
                        Debug.Log("캐릭터 2의 아이템창 꽉 참");
                        break;
                    }
                }

            }
        }
    }

    public void AddItem3(int id)
    {
        Equip itemToAdd = database.FetchItemByID(id);
        if (itemToAdd.Stackable && Check_Item_In_Inventory3(itemToAdd))
        {
            for (int i = 0; i < items3.Count; i++)
            {
                if (items3[i].Id == id)
                {
                    ItemData data = slots3[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    Debug.Log("이미있는 대상");
                }
            }
        }
        else
        {
            for (int i = 0; i < items3.Count; i++)
            {
                if (items3[i].Id == -1)
                {

                    if (P3_ItemslotCount < 4)
                    {
                        P3_ItemslotCount++;
                        items3[i] = itemToAdd;
                        GameObject itemObj = Instantiate(InvenItem);
                        itemObj.GetComponent<ItemData>().equip = itemToAdd;
                        itemObj.GetComponent<ItemData>().slot = i;
                        itemObj.transform.SetParent(slots3[i].transform);

                        itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                        //itemObj.transform.position = new Vector2(511, 249.6f);
                        itemObj.transform.position = slots3[i].transform.position;
                        itemObj.name = itemToAdd.Name;
                        Debug.Log("없는 대상" + i);
                        if(items3[i].Id < 50)
                        {
                            Add_Status(battle.switching[2], itemToAdd);
                        }
                        
                        break;
                    }
                    else
                    {
                        Debug.Log("캐릭터 3의 아이템창 꽉 참");
                        break;
                    }
                }

            }
        }
    }

    public void CheckStatus(string name)
    {
        InfoPanel.SetActive(true);
        for (int i = 0; i < items.Count; i++)
        {
            if (slots[i].name == name)
            {
                ItemIcon.sprite = items[i].sprite;
                Title.text = items[i].Name;
                if (items[i].Type == 1)
                {
                    Type.text = "무기";
                }
                if (items[i].Type == 2)
                {
                    Type.text = "갑옷";
                }
                if (items[i].Type == 3)
                {
                    Type.text = "소비품";
                }
                Grade.text = items[i].Grade;
                Option.text = items[i].ItemOption;
                Text.text = items[i].Text;
                InfoPanel.transform.Find("Delete0").GetComponent<Button>().onClick.RemoveAllListeners();
                InfoPanel.transform.Find("Delete0").GetComponent<Button>().onClick.AddListener(delegate () { deleteItem(name); });
                break;
            }

            if (slots2[i].name == name)
            {
                ItemIcon.sprite = items2[i].sprite;
                Title.text = items2[i].Name;
                if (items[i].Type == 1)
                {
                    Type.text = "무기";
                }
                if (items[i].Type == 2)
                {
                    Type.text = "갑옷";
                }
                if (items[i].Type == 3)
                {
                    Type.text = "소비품";
                }
                Grade.text = items2[i].Grade;
                Option.text = items2[i].ItemOption;
                Text.text = items2[i].Text;
                InfoPanel.transform.Find("Delete0").GetComponent<Button>().onClick.RemoveAllListeners();
                InfoPanel.transform.Find("Delete0").GetComponent<Button>().onClick.AddListener(delegate () { deleteItem(name); });
                break;
            }
            if (slots3[i].name == name)
            {
                ItemIcon.sprite = items3[i].sprite;
                Title.text = items3[i].Name;
                if (items[i].Type == 1)
                {
                    Type.text = "무기";
                }
                if (items[i].Type == 2)
                {
                    Type.text = "갑옷";
                }
                if (items[i].Type == 3)
                {
                    Type.text = "소비품";
                }
                Grade.text = items3[i].Grade;
                Option.text = items3[i].ItemOption;
                Text.text = items3[i].Text;
                InfoPanel.transform.Find("Delete0").GetComponent<Button>().onClick.RemoveAllListeners();
                InfoPanel.transform.Find("Delete0").GetComponent<Button>().onClick.AddListener(delegate () { deleteItem(name); });
                break;
            }


        }
           

    }

   





    void Add_Status(int unitIdx, Equip equip)
    {
        npc.Equip_MaxHp[unitIdx] += equip.MaxHp;
        npc.Hp[unitIdx] += (int)(equip.Hp * (npc.MaxHp[unitIdx] + npc.Equip_MaxHp[unitIdx]) * 0.01f);
        npc.Equip_MaxMp[unitIdx] += equip.MaxMp;
        npc.Mp[unitIdx] += equip.Mp;
        npc.Equip_Str[unitIdx] += equip.Str;
        npc.Equip_Dex[unitIdx] += equip.Dex;
        npc.Equip_Wis[unitIdx] += equip.Wis;

        Debug.Log(string.Format("hp : {0}, mp : {1}, str : {2}, dex : {3}, wis : {4}", npc.MaxHp[unitIdx], npc.MaxMp[unitIdx],
            npc.Str[unitIdx], npc.Dex[unitIdx], npc.Wis[unitIdx]));
    }

    // 아이템 능력치 되돌리는 함수
    void Remove_Status(int unitIdx, Equip equip)
    {
        // 아이템 능력치 해제 및 예외처리
        if (equip.Id != -1)
        {
            npc.Equip_MaxHp[unitIdx] -= equip.MaxHp;
            npc.Equip_MaxMp[unitIdx] -= equip.MaxMp;
            npc.Equip_Str[unitIdx] -= equip.Str;
            npc.Equip_Dex[unitIdx] -= equip.Dex;
            npc.Equip_Wis[unitIdx] -= equip.Wis;
        }

    }

    bool Check_Item_In_Inventory(Equip equip)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == equip.Id)
                return true;

        }
        return false;
    }
    bool Check_Item_In_Inventory2(Equip equip)
    {
        for (int i = 0; i < items2.Count; i++)
        {
            if (items2[i].Id == equip.Id)
                return true;

        }
        return false;
    }
    bool Check_Item_In_Inventory3(Equip equip)
    {
        for (int i = 0; i < items3.Count; i++)
        {
            if (items3[i].Id == equip.Id)
                return true;

        }
        return false;
    }

}
