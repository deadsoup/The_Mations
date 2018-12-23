﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Equip equip;
    public int amount;
    public int slot;

    private Transform originalParent;
    private Inven inv;
    private Vector2 offset;

    void Start()
    {
        inv = GameObject.Find("Inven").GetComponent<Inven>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (equip != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this. transform.position.y);
            originalParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (equip != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inv.slots[slot].transform);
        this.transform.position = inv.slots[slot].transform.position;

        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    

}