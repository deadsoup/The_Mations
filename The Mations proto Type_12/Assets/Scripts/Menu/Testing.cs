using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Testing : MonoBehaviour { // 튜토리얼 맵설명 
    public static int count;
    public GameObject 텍스트1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4_1;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    public GameObject Text8;
    public GameObject Text9;
    public GameObject Text10;
    public GameObject Text11;
    public GameObject Text12;
    public GameObject Text13;
    public GameObject Text14;
    public GameObject Text15;
    public GameObject Text16;
    public GameObject Text17;
    public GameObject Text18;
    public GameObject Text19;
    public GameObject Cover;
    public GameObject HwakDae;
    public GameObject Next;
    public GameObject Text4;
    public GameObject BattleGo;
    public GameObject TitleGo;
    public GameObject Intext;
    public GameObject sun;

    public GameObject[] text = new GameObject[20]; //  이거는 저기 게임 오브젝트를 나열한것

    
    public void Click3()
    {
        if (Option.Coin == 0&& TutoDirector.Tuto ==0)
        {
            SceneManager.LoadScene("bin+yong");
        }
        else if(TutoDirector.Tuto == 1)
        {
            SceneManager.LoadScene("TutoRialMapScene");
        }
    }
   
    public void Click2()
    {
        if (Option.Coin == 0)
        {
            Intext.SetActive(true);
        }
    }
    public void Click4()
    {
        if (Option.Coin == 0)
        {
            Intext.SetActive(false);
        }
    }
    
    public void Click()
    {
        if (Option.Coin == 0)
        {
            Next.SetActive(false);
            HwakDae.SetActive(true);
            Text4.SetActive(true);
        }
    }
    // Use this for initialization
	void Start () {
        StartDirector.count = true;
        MapInfomation.Mapcount = 3;


        Option.Coin = 0;
        count = 0;

        for (int i = 0; i < text.Length; i++)
        {
            text[i] = GameObject.Find("Canvas").transform.GetChild(i).gameObject; // 위에서 나열한 게임오브젝트를 캔버스 자식오브젝트 순번대로 찾는 것
                                                                                  // 현재상황대로 나열하면 Cover1, 확대, 텍스트1, text2 나열이 됨
        }


    }

    //Cover.SetActive(true);
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && Option.Coin == 0)
        {
            count++;
        }
        if (count == 1)
        {
            텍스트1.SetActive(true);
        }if(count == 2)
        {
            텍스트1.SetActive(false);
            Text2.SetActive(true);
            sun.SetActive(true);

}
        if (count == 3)
        {
            Text2.SetActive(false);
            Text3.SetActive(true);
        }
        if (count == 4)
        {
            Text3.SetActive(false);
            Text4_1.SetActive(true);
        }
        if (count == 5)
        {
            Text4_1.SetActive(false);
            Text5.SetActive(true);
        }
        if (count == 6)
        {
            Text5.SetActive(false);
            Text6.SetActive(true);
        }
        if (count == 7)
        {
            Text6.SetActive(false);
            Text7.SetActive(true);
        }
        if (count == 8)
        {
            Text7.SetActive(false);
            Text8.SetActive(true);
        }
        if (count == 9)
        {
            Text8.SetActive(false);
            Text9.SetActive(true);
        }
        if (count == 10)
        {
            Text9.SetActive(false);
            Text10.SetActive(true);
        }
        if (count == 11)
        {
            Text10.SetActive(false);
            Text11.SetActive(true);
        }
        if (count == 12)
        {
            Text11.SetActive(false);
            Text12.SetActive(true);
        }
        if (count == 13)
        {
            Text12.SetActive(false);
            Text13.SetActive(true);
        }
        if (count == 14)
        {
            Text13.SetActive(false);
            Text14.SetActive(true);
        }
        if (count == 15)
        {
            Text14.SetActive(false);
            Text15.SetActive(true);
        }
        if (count == 16)
        {
            Text15.SetActive(false);
            Text16.SetActive(true);
        }
        if (count == 17)
        {
            Text16.SetActive(false);
            Text17.SetActive(true);
        }
        if (count == 18)
        {
            Text17.SetActive(false);
            Text18.SetActive(true);
        }
        if (count == 19)
        {
            Text18.SetActive(false);
            Text19.SetActive(true);
        }
        if (count == 20)
        {
            Text19.SetActive(false);
            sun.SetActive(false);
            Cover.SetActive(true);
            TutoDirector.Tuto = 1;
        }





    }
}
