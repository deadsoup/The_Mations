using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MapInfomation : MonoBehaviour
{
    public static int Mapcount;
    public GameObject Guname;
    public GameObject Nan2do;
    public GameObject Monster;

    // Start is called before the first frame update
    void Start()
    {
        MapInfomation.Mapcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mapcount == 0)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "";
            this.Monster.GetComponent<Text>().text = "출현 몬스터 :" + "";
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            this.Monster.GetComponent<Text>().fontSize = 25;
        }
        if (Mapcount ==1)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "서대문구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "중하";
            this.Monster.GetComponent<Text>().text = "출현 몬스터 :" +"효민몬1"+"효민몬2";
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            this.Monster.GetComponent<Text>().fontSize = 25;
        }
        if (Mapcount == 2)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "마포구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "하";
            this.Monster.GetComponent<Text>().text = "출현 몬스터 :" + "골빈몬1" + "골빈몬2";
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            this.Monster.GetComponent<Text>().fontSize = 25;
        }
        if (Mapcount == 3)
        {
            this.Guname.GetComponent<Text>().text = "구 이름   :" + "종로구";
            this.Nan2do.GetComponent<Text>().text = "맵 난이도 :" + "중상";
            this.Monster.GetComponent<Text>().text = "출현 몬스터 :" + "리니지몬1" + "던파몬2";
            this.Guname.GetComponent<Text>().fontSize = 25;
            this.Nan2do.GetComponent<Text>().fontSize = 25;
            this.Monster.GetComponent<Text>().fontSize = 25;
        }
    }
}
