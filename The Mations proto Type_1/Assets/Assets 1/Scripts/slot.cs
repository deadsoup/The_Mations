using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour , IDropHandler
{
    public int id;

    private Inven inv;


    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inv.items[id].Id == -1)
        {
            //droppedItem.transform.SetParent(this.transform);
            //droppedItem.transform.position = this.transform.position;
            inv.items[droppedItem.slot] = new Equip();
            inv.items[id] = droppedItem.equip;
            droppedItem.slot = id;
        }
        //else if (inv.items[id].Id != -1)
        else if (droppedItem.slot != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inv.slots[droppedItem.slot].transform);
            item.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slot] = item.GetComponent<ItemData>().equip;
            inv.items[id] = droppedItem.equip;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inven").GetComponent<Inven>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
