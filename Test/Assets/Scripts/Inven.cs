using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inven : MonoBehaviour
{


    public static int[] Id = new int[6];
    public static string[] Name = new string[6];
    public static string[] Text = new string[6];
    public static int[] MaxHp = new int[6];
    public static int[] MaxMp = new int[6];
    public static int[] Str = new int[6];
    public static int[] Dex = new int[6];
    public static int[] Wis = new int[6];

    int slotAmount;

    public GameObject Invenpanel;
    public GameObject Slotpanel;
    public GameObject InvenSlot;
    public GameObject InvenItem;

    public List<Reward> items = new List<Reward>();
    public List<GameObject> slots = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        slotAmount = 9;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Reward());
            slots.Add(Instantiate(InvenSlot));
            slots[i].transform.SetParent(Slotpanel.transform);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
