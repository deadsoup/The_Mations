using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject cover;
    // Start is called before the first frame update

   
    void Start()
    {
        if (TutoDirector.Tuto == 1)
        {
            Char1.SetActive(false);
            Char2.SetActive(false);
            Char3.SetActive(false);
            cover.SetActive(false);
        }

        else if (CharCount.Charcount == 0)
        {
            Char1.SetActive(true);
            Char2.SetActive(false);
            Char3.SetActive(false);
            cover.SetActive(false);
        }
        else if (CharCount.Charcount == 1)
        {
            Char1.SetActive(false);
            Char2.SetActive(true);
            Char3.SetActive(false);
            cover.SetActive(false);
        }
        else if (CharCount.Charcount == 2)
        {
            Char1.SetActive(false);
            Char2.SetActive(false);
            Char3.SetActive(true);
            cover.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
