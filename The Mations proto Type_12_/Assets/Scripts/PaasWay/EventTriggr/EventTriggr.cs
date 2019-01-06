using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventTriggr : MonoBehaviour
{

    void Start()
    {
    }
    void Update()
    {
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        MapManager.instance.StartEventTrg();
    }
}
