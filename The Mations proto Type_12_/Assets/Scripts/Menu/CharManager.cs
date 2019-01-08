using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public GameObject Char1;
    public GameObject Char2;
    // Start is called before the first frame update

    public void char1select()
    {
        if(CharCount.Charcount == 1)
        {
            Char1.SetActive(true);
            Char2.SetActive(false);
        }
        if (CharCount.Charcount == 2)
        {
            Char1.SetActive(false);
            Char2.SetActive(true);
        }


    }
    void Start()
    {
        Debug.Log(CharCount.Charcount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
