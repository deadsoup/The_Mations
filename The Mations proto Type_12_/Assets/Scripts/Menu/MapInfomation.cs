using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MapInfomation : MonoBehaviour
{
    public static int Mapcount;
    public GameObject Guname;
    public GameObject Nan2do;
   /* public GameObject[] ButtonGroup= new GameObject[13];

    public GameObject BG;
    GameObject StageMgr;*/


   
    void Start()
    {
        //맵인포메이션 맵카운트를 맵매니저스크립트 끝줄에 넣은뒤 해당번호를가지고 통로맵을 들어가고
        //그 통로맵을 클리어 시 해당하는 번호에따라 맵매니저에서 또다른 번호를 조건으로 줘서
        //해당 번호가되면 클리어한 구의 버튼을 삭제해준다!! 이러면 구현가능
        MapInfomation.Mapcount = -1;
        /*StageMgr = GameObject.Find("StageMgr");
        BG = GameObject.Find("Canvas").transform.Find("Intext").transform.Find("ButtonGroup").gameObject;
        Debug.Log("여기까지는됬다");


        for (int i = 0; i < 13; i++)
        {
            Debug.Log("For문집입");
            ButtonGroup[i] = BG.transform.GetChild(i).gameObject;
            ButtonGroup[i].SetActive(false);
        }*/
        
    }

    
    void Update()
    {
        if (Mapcount == -1)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "";
            
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            
            
        }
        if (Mapcount ==0)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "중구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "Mations Center";
           
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            

        }
        if (Mapcount == 1)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "동대문구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "쉬움";
            
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;


           /* for (int i = 0; i < 13; i++)
            {
                StageMgr.GetComponent<StageManager>().StageButton[i].SetActive(false);
            }
            StageMgr.GetComponent<StageManager>().StageButton[1].SetActive(true);*/

        }
        if (Mapcount == 2)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "종로구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "쉬움";
            
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;


           /* for (int i = 0; i < 13; i++)
            {
                StageMgr.GetComponent<StageManager>().StageButton[i].SetActive(false);
            }
            StageMgr.GetComponent<StageManager>().StageButton[2].SetActive(true);*/

        }
        if (Mapcount == 3)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "용산구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "쉬움";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 4)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "강남구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "쉬움";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 5)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "도봉구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "보통";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 6)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "마포구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "보통";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 7)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "동작구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "보통";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 8)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "송파구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "보통";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 9)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "강동구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "어려움";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 10)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "은평구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "어려움";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 11)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "강서구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "어려움";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }
        if (Mapcount == 12)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "구로구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "어려움";

            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;

        }


    }
}
