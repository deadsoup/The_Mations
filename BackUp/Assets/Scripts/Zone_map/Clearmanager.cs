using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clearmanager : MonoBehaviour
{
   public GameObject ClearPassage1;  //오브젝를 찾을 수 있도록 선언
    public GameObject ClearPassage2;
    public GameObject ClearPassage3;


    void Start()
    {
    }

    public void ClearP1()
    {
            this.ClearPassage1.SetActive(true);
        //이벤트 트리거에 의해 켜질 클리어 통로
    }
    public void ClearP2()
    {
        this.ClearPassage2.SetActive(true);
    }
    public void ClearP3()
    {
        this.ClearPassage3.SetActive(true);
    }


}
