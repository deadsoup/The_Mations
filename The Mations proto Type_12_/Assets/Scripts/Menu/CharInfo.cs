using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharInfo : MonoBehaviour
{
    
    public GameObject Point;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject Str1;
    public GameObject Wiz1;
    public GameObject Hp1;
    public GameObject Mp1;
    public GameObject Hp2;
    public GameObject Mp2;
    public GameObject Hp3;
    public GameObject Mp3;
    
    public GameObject Str2;
    public GameObject Wiz2;
    public GameObject Str3;
    public GameObject Wiz3;
    // Start is called before the first frame update
    public void StatUP1()
    {
        
        if (npc.SkillPoint >= 1)
        {
            npc.Str[0]++;
            this.Str1.GetComponent<Text>().text =""+(npc.Str[0]);
            npc.SkillPoint += -1;
        }
        
    }
    public void StatUP2()
    {

        if (npc.SkillPoint >= 1)
        {
            npc.Wis[0]++;
            this.Wiz1.GetComponent<Text>().text = ""+(npc.Wis[0]);
            npc.SkillPoint += -1;
        }

    }
    public void StatUP21()
    {

        if (npc.SkillPoint >= 1)
        {
            npc.Str[1]++;
            this.Str2.GetComponent<Text>().text = "" + (npc.Str[1]);
            npc.SkillPoint += -1;
        }

    }
    public void StatUP22()
    {

        if (npc.SkillPoint >= 1)
        {
            npc.Wis[1]++;
            this.Wiz2.GetComponent<Text>().text = "" + (npc.Wis[1]);
            npc.SkillPoint += -1;
        }
    }
    public void StatUP31()
    {

        if (npc.SkillPoint >= 1)
        {
            npc.Str[2]++;
            this.Str3.GetComponent<Text>().text = "" + (npc.Str[2]);
            npc.SkillPoint += -1;
        }

    }
    public void StatUP32()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Wis[2]++;
            this.Wiz3.GetComponent<Text>().text = "" + (npc.Wis[2]);
            npc.ArchivePoint[0] += -1;
        }
    }
    public void HpUP1()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Hp[0]+=10;
            this.Hp1.GetComponent<Text>().text = "" + (npc.Hp[0]);
            npc.ArchivePoint[0] += -1;
        }

    }
    public void MpUP1()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Mp[0]+=10;
            this.Mp1.GetComponent<Text>().text = "" + (npc.Mp[0]);
            npc.ArchivePoint[0] += -1;
        }
    }
    public void HpUP2()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Hp[1] += 10;
            this.Hp2.GetComponent<Text>().text = "" + (npc.Hp[1]);
            npc.ArchivePoint[0] += -1;
        }

    }
    public void MpUP2()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Mp[1] += 10;
            this.Mp2.GetComponent<Text>().text = "" + (npc.Mp[1]);
            npc.ArchivePoint[0] += -1;
        }
    }
    public void HpUP3()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Hp[2] += 10;
            this.Hp3.GetComponent<Text>().text = "" + (npc.Hp[2]);
            npc.ArchivePoint[0] += -1;
        }

    }
    public void MpUP3()
    {

        if (npc.ArchivePoint[0] >= 1)
        {
            npc.Mp[2] += 10;
            this.Mp3.GetComponent<Text>().text = "" + (npc.Mp[2]);
            npc.ArchivePoint[0] += -1;
        }
    }

    void Start()
    {
        
        
       this.Str1.GetComponent<Text>().text = " "+2+0;
        this.Wiz1.GetComponent<Text>().text = " "+5+0;
        this.Str2.GetComponent<Text>().text = " "+3+0;
        this.Wiz2.GetComponent<Text>().text = " "+3+0;
        this.Str3.GetComponent<Text>().text = " " +2+0;
        this.Wiz3.GetComponent<Text>().text = " " +1+0;
        
        this.Hp1.GetComponent<Text>().text = " " + 150;
        this.Mp1.GetComponent<Text>().text = " " + 200;
        this.Hp2.GetComponent<Text>().text = " " + 200;
        this.Mp2.GetComponent<Text>().text = " " + 150;
        this.Hp3.GetComponent<Text>().text = " " + 250;
        this.Mp3.GetComponent<Text>().text = " " + 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.Point.GetComponent<Text>().text = "    " + npc.ArchivePoint[0] + "    Point";
        this.Point2.GetComponent<Text>().text = "    " + npc.ArchivePoint[0] + "    Point";
        this.Point3.GetComponent<Text>().text = "    " + npc.ArchivePoint[0] + "    Point";

    }
}
