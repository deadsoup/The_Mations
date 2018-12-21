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

<<<<<<< HEAD
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

        slotAmount = Random.Range(1,10);
        randomAdd = Random.Range(0, 6);
        randomAdd1 = Random.Range(0, 6);
        randomAdd2 = Random.Range(0, 6);


        Invenpanel = GameObject.Find("BackPanel");
        Slotpanel = Invenpanel.transform.Find("Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Equip());
            slots.Add(Instantiate(InvenSlot));
            slots[i].transform.SetParent(Slotpanel.transform);


        }
        AddItem(randomAdd);
        AddItem(randomAdd1);
        AddItem(randomAdd2);

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
                }
            }
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Id == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(InvenItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.sprite;
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.Name;
                break;



            }

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
