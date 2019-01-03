using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillSlot : MonoBehaviour
{
    public int id;

    private SKillManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("SKillManager").GetComponent<SKillManager>();
    }
}
