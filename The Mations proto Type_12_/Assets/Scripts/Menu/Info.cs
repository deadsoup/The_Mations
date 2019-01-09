using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{

    public GameObject Info1;
    public GameObject Information;
    public GameObject Information2;
    public GameObject Information3; 


    public void ClickInfo()
    {
        Info1.SetActive(true);
    }
    public void ClickInfoClose()
    {
        Info1.SetActive(false);
    }
    public void ClickChar1()
    {
        Information.SetActive(true);
        Information2.SetActive(false);
        Information3.SetActive(false);
    }
    public void ClickChar2()
    {
        Information2.SetActive(true);
        Information.SetActive(false);
        Information3.SetActive(false);
    }
    public void ClickChar3()
    {
        Information3.SetActive(true);
        Information2.SetActive(false);
        Information.SetActive(false);
    }
}
