using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCountNo : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click(int a)
    {
        MapInfomation.Mapcount = a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
