using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharUiDirector : MonoBehaviour
{
    public static int Character;
    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject Char4;
    public GameObject Char5;
    public GameObject Char6;
    public GameObject Char1Cancle;
    public GameObject CharSelect1;
    public GameObject Char2Cancle;
    public GameObject CharSelect2;
    public GameObject Char3Cancle;
    public GameObject CharSelect3;
    public GameObject Char4Cancle;
    public GameObject CharSelect4;
    public GameObject Char5Cancle;
    public GameObject CharSelect5;
    public GameObject Char6Cancle;
    public GameObject CharSelect6;

   
    public void Ch1_Click1()
    {
        Char2.SetActive(true);
        Char3.SetActive(true);
        Char4.SetActive(true);
        Char5.SetActive(true);
        Char6.SetActive(true);
        CharSelect1.SetActive(false);
        Char1Cancle.SetActive(true);
        CharUiDirector.Character = 1;
        
    }
    public void Ch1_Click2()
    {
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char1Cancle.SetActive(false);
        CharSelect1.SetActive(true);
        CharUiDirector.Character = 0;
       
    }
    public void Ch2_Click1()
    {
        Char1.SetActive(true);
        Char3.SetActive(true);
        Char4.SetActive(true);
        Char5.SetActive(true);
        Char6.SetActive(true);
        CharSelect2.SetActive(false);
        Char2Cancle.SetActive(true);
        CharUiDirector.Character = 2;
        
    }
    public void Ch2_Click2()
    {
        Char1.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char2Cancle.SetActive(false);
        CharSelect2.SetActive(true);
        CharUiDirector.Character = 0;
        
    }
    public void Ch3_Click1()
    {
        Char1.SetActive(true);
        Char2.SetActive(true);
        Char4.SetActive(true);
        Char5.SetActive(true);
        Char6.SetActive(true);
        CharSelect3.SetActive(false);
        Char3Cancle.SetActive(true);
        CharUiDirector.Character = 3;
    }
    public void Ch3_Click2()
    {
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char3Cancle.SetActive(false);
        CharSelect3.SetActive(true);
        CharUiDirector.Character = 0;
    }
    public void Ch4_Click1()
    {
        Char1.SetActive(true);
        Char2.SetActive(true);
        Char3.SetActive(true);
        Char5.SetActive(true);
        Char6.SetActive(true);
        CharSelect4.SetActive(false);
        Char4Cancle.SetActive(true);
        CharUiDirector.Character = 4;
    }
    public void Ch4_Click2()
    {
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char4Cancle.SetActive(false);
        CharSelect4.SetActive(true);
        CharUiDirector.Character = 0;
    }
    public void Ch5_Click1()
    {
        Char1.SetActive(true);
        Char2.SetActive(true);
        Char3.SetActive(true);
        Char4.SetActive(true);
        Char6.SetActive(true);
        CharSelect5.SetActive(false);
        Char5Cancle.SetActive(true);
        CharUiDirector.Character = 5;
    }
    public void Ch5_Click2()
    {
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char6.SetActive(false);
        Char5Cancle.SetActive(false);
        CharSelect5.SetActive(true);
        CharUiDirector.Character = 0;
    }
    public void Ch6_Click1()
    {
        Char1.SetActive(true);
        Char2.SetActive(true);
        Char3.SetActive(true);
        Char4.SetActive(true);
        Char5.SetActive(true);
        CharSelect6.SetActive(false);
        Char6Cancle.SetActive(true);
        CharUiDirector.Character = 6;
    }
    public void Ch6_Click2()
    {
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6Cancle.SetActive(false);
        CharSelect6.SetActive(true);
        CharUiDirector.Character = 0;
    }
    public void Start()
    {
        StartDirector.count = true;
        //TutoDirector.Tuto = 0;
    }
}
