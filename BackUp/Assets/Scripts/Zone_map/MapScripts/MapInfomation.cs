using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapInfomation : MonoBehaviour
{
    public static int Mapcount;
    public GameObject Guname;
    public GameObject Nan2do;
    

    // Start is called before the first frame update
    void Start()
    {
        MapInfomation.Mapcount = -1;
    }

    // Update is called once per frame
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
            
        }
        if (Mapcount == 2)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "종로구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "쉬움";
            
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            
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
