using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Reward : MonoBehaviour
{
    GameObject Rewardpanel;
    GameObject Slotpanel;

    RewardDatabase rewardBase;


    Inven inven;

    public GameObject RewardSlot;
    public GameObject RewardItem;

    int slotAmount;


    public List<Equip> rewardItems = new List<Equip>();
    public List<GameObject> slots = new List<GameObject>();

    public static int reward1, reward2, reward3, reward4, reward5, reward6, reward7, reward8, reward9;

    public GameObject add1, add2, add3, add4, add5, add6, add7, add8, add9;
    public GameObject Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9;

    void Start()
    {
        slotAmount = 3;

        /*
        reward1 = Random.Range(1, 6); reward2 = Random.Range(1, 6); reward3 = Random.Range(1, 6); reward4 = Random.Range(1, 6);
        reward5 = Random.Range(1, 6); reward6 = Random.Range(1, 6); reward7 = Random.Range(1, 6); reward8 = Random.Range(1, 6); reward9 = Random.Range(1, 6);*/

        rewardBase = GetComponent<RewardDatabase>();

        inven = GameObject.Find("Inven").GetComponent<Inven>();

        Rewardpanel = GameObject.Find("RewardPanel");
        Slotpanel = Rewardpanel.transform.Find("Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            rewardItems.Add(new Equip());
            slots.Add(Instantiate(RewardSlot));
            slots[i].GetComponent<slot>().id = i;
            slots[i].name = "RewardSlots" + i.ToString();
            slots[i].transform.SetParent(Slotpanel.transform);


        }

        /*
        for (int i = 0; i < rewardItems.Count; i++)
        {
            deleteItem(i);
        }
        */
    }

    void Update()
    {
        addadd();
        
    }

    public void addadd()
    {
        if (battle.reItems == 1)
        {
            AddItem(reward1);
            AddItem(reward2);
            AddItem(reward3);
            add1.SetActive(true);
            add2.SetActive(true);
            add3.SetActive(true);
            /*
            add4.SetActive(true);
            add5.SetActive(true);
            add6.SetActive(true);
            add7.SetActive(true);
            add8.SetActive(true);
            add9.SetActive(true);
            */
            battle.reItems = 0;
        }
    }


    public void charAddItem_slot1()
    {
        for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].Id == -1)
            {
                charAddItem("RewardSlots0");
                inven.AddItem(reward1);
                add1.SetActive(false);
                break;
            }
            if(inven.items[i].Id != -1)
            {
                add1.SetActive(true);
            }
        }
    }

    public void charAddItem_slot2()
    {
        for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].Id == -1)
            {
                charAddItem("RewardSlots1");
                inven.AddItem(reward2);
                add2.SetActive(false);
                break;
            }
            if (inven.items[i].Id != -1)
            {
                add2.SetActive(true);
            }
        }
    }

    public void charAddItem_slot3()
    {
        for (int i = 0; i < inven.items.Count; i++)
        {
            if (inven.items[i].Id == -1)
            {
                charAddItem("RewardSlots2");
                inven.AddItem(reward3);
                add3.SetActive(false);
                break;
            }
            if (inven.items[i].Id != -1)
            {
                add3.SetActive(true);
            }
        }
    }


    public void charAddItem(string name)
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (slots[i].name == name)
            {

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                rewardItems[i] = new Equip();
                break;
            }

        }

    }


    public void Alldelete()
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            deleteItem(i);
            deleteItem(i);
            deleteItem(i);
            deleteItem(i);
            deleteItem(i);
            deleteItem(i);
            deleteItem(i);
            Panel1.SetActive(false); Panel2.SetActive(false); Panel3.SetActive(false); //Panel4.SetActive(false); Panel5.SetActive(false);
           // Panel6.SetActive(false); Panel7.SetActive(false); Panel8.SetActive(false); Panel9.SetActive(false);
        }
    }

    public void deleteItem(int id)
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (rewardItems[i].Id == id)
            {

                // slot 밑에있는 아이템 오브젝트 찾기 및 삭제
                var children = slots[i].GetComponentInChildren<ItemData>();
                GameObject obj = children.gameObject;
                Destroy(obj);
                // 아이템정보 초기화 (id -1로변경)
                rewardItems[i] = new Equip();

                break;
            }

        }

    }




    public void AddItem(int id)
    {
        Equip itemToAdd = rewardBase.FetchItemByID(id);

            for (int i = 0; i < rewardItems.Count; i++)
            {
                if (rewardItems[i].Id == -1)
                {
                    rewardItems[i] = itemToAdd;
                    GameObject itemObj = Instantiate(RewardItem);
                    itemObj.GetComponent<ItemData>().equip = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;
                    itemObj.transform.SetParent(slots[i].transform);



                    itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;

                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.name = itemToAdd.Name;
                    Debug.Log("없는 대상" + i);

                    break;



                }

            }
        

    }

    bool Check_Item_In_Inventory(Equip equip)
    {
        for (int i = 0; i < rewardItems.Count; i++)
        {
            if (rewardItems[i].Id == equip.Id)
                return true;

        }
        return false;
    }




}
