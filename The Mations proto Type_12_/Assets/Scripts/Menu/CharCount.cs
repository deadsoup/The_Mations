using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCount : MonoBehaviour
{
    public static int Charcount;
    // Start is called before the first frame update
    public void Click(int a)
    {
       Charcount = a;
        

        //DontDestroyOnLoad(this.gameObject);

    }
    public void Clickno(int a)
    {
        Charcount = a;
        //DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
