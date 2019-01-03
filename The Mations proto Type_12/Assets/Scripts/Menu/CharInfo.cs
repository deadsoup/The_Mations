using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharInfo : MonoBehaviour
{
    public static int PointCount;
    public GameObject Point;
    public GameObject Point2;
    //public GameObject Point3;
    public GameObject Str1;
    public GameObject Wiz1;
    int StrCount;
    int WizCount;
    int StrCount2;
    int WizCount2;
    //int StrCount3;
    //int WizCount3;
     public GameObject Str2;
     public GameObject Wiz2;
     /*public GameObject Str3;
     public GameObject Wiz3;*///  캐릭터3번생기면 여기쓰면됨
    // Start is called before the first frame update
    public void StatUP1()
    {
        
        if (PointCount >= 1)
        {
            StrCount++;
            this.Str1.GetComponent<Text>().text =""+(20+StrCount);
            PointCount += -1;
        }
        
    }
    public void StatUP2()
    {

        if (PointCount >= 1)
        {
            WizCount++;
            this.Wiz1.GetComponent<Text>().text = ""+(50 + WizCount);
            PointCount += -1;
        }

    }
    public void StatUP21()
    {

        if (PointCount >= 1)
        {
            StrCount2++;
            this.Str2.GetComponent<Text>().text = "" + (30 + StrCount2);
            PointCount += -1;
        }

    }
    public void StatUP22()
    {

        if (PointCount >= 1)
        {
            WizCount2++;
            this.Wiz2.GetComponent<Text>().text = "" + (30 + WizCount2);
            PointCount += -1;
        }
    }

        void Start()
    {
        
        PointCount = 90;
        this.Str1.GetComponent<Text>().text = " "+2+0;
        this.Wiz1.GetComponent<Text>().text = " "+5+0;
        this.Str2.GetComponent<Text>().text = " "+3+0;
        this.Wiz2.GetComponent<Text>().text = " "+3+0;
        //이부분에 위에와 같이 3번추가하면됨 위에 함수 21,22복사해서 31,32만들어서 인포3 버튼에 함수연결시켜주기
    }

    // Update is called once per frame
    void Update()
    {
        this.Point.GetComponent<Text>().text = "    " + PointCount + "    Point";
        this.Point2.GetComponent<Text>().text = "    " + PointCount + "    Point";
        //this.Point3.GetComponent<Text>().text = "    " + PointCount + "    Point";

    }
}
