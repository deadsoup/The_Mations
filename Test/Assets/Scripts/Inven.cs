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

    ItemDatabase database;

    public GameObject InvenSlot;
    public GameObject InvenItem;

    public GameObject UsePanel;


    public List<Equip> items = new List<Equip>();
    public List<GameObject> slots = new List<GameObject>();


    int slotAmount;
    int randomAdd;
    int randomAdd1;
    int randomAdd2;

    // Start is called before the first frame update
    void Start()
    {

        database = GetComponent<ItemDatabase>();
        slotAmount = 2;
        randomAdd = Random.Range(0, 6);
        randomAdd1 = Random.Range(0, 6);
        randomAdd2 = Random.Range(0, 6);


        Invenpanel = GameObject.Find("BackPanel");
        Slotpanel = Invenpanel.transform.Find("Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Equip());
            slots.Add(Instantiate(InvenSlot));
            slots[i].GetComponent<slot>().id = i;
            slots[i].name = "slots" + i.ToString();
            slots[i].transform.SetParent(Slotpanel.transform);
            //print(new Equip());
        }

        print(database.FetchItemByID(30).Name);
            }

    private void Update()
    {
        // 아이템추가
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(30);
        }
    }

    public void deleteItem(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (slots[i].name == name)
            {
                // 아이템 삭제전 플레이어 능력치 감소
                Remove_Status(1, items[i]);

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


    public void DeleteButton1()
    {
        deleteItem("slots0");

    }

    public void DeleteButton2()
    {
        deleteItem("slots1");

    }

    public void Use(int a)
    {
        if (a == 30) { UsePanel.SetActive(true); }
    }
    /*
     * item data 스크립트를 아이템이 들고있늗데
     * 여기에 함수를 만들어
     * 게임오브젝트 인벤을 찾아
     * 그리고 자기가 들고있ㄲ는 스크립트 itemdata에서 그 함수를 실행해
     * 그 함수는 찾은 인벤이 들고있는 use item을 실행하는 함수
    */

    public void UsePotion()
    {
        Equip itemToAdd = database.FetchItemByID(30);

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Name == "체력약" && slots[i].transform.GetChild(0).GetComponent<ItemData>().amount >= 0)
            {
                items[i] = itemToAdd;
                ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                data.amount--;
                data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                Add_Status(1, itemToAdd);
                print(itemToAdd.Hp);

                if (npc.Hp[1] >= npc.MaxHp[1])
                {
                    npc.Hp[1] = npc.MaxHp[1];
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
                   
                    Add_Status(0, itemToAdd);
                    break;



                }

            }
        }
    }

    void Add_Status(int unitIdx, Equip equip)
    {
        npc.Equip_MaxHp[unitIdx] += equip.MaxHp;
        npc.Hp[unitIdx] += equip.Hp;
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

}
