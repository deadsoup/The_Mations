using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{

    //배열 없이
    /*public GameObject obj1;
    public GameObject obj2; 
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    */
    //퍼블릭으로 선언해서 인스펙트에 뜸, 오브젝트를 인스펙트로 끌어다 넣으면 됨

    int count;

    //public GameObject[] hairObj = new GameObject[5];

    //리스트로 선언하기
    //public List<GameObject> hairObj = new List<GameObject>();
    public List<GameObject> hairObj = new List<GameObject>();

    void Start()
    {

        //count++;
        /*obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        obj4.SetActive(false);
        obj5.SetActive(false);
        obj6.SetActive(false);
        */
        //안보이게 처리해주는 거임, 게임 키면 대머리

        //배열 사용
        //배열에 담겨있는 오브젝트들을 전부 off시켜 안보이게 한다
        /*for (int i = 0; i < hairObj.Length; i++)
        {
            hairObj[i].SetActive(false);
        }
        */

        //코딩으로 리스트에 추가하기
        /*hairObj.Add(GameObject.Find("hair1"));
        hairObj.Add(GameObject.Find("hair2"));
        hairObj.Add(GameObject.Find("hair3"));
        hairObj.Add(GameObject.Find("hair4"));
        hairObj.Add(GameObject.Find("hair5"));
        hairObj.Add(GameObject.Find("hair6"));
        */

        //리스트 사용
        for (int i = 0; i < hairObj.Count; i++)
        {
            hairObj[i].SetActive(false);
        }

    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            count++;
            for (int i = 0; i < hairObj.Count; i++)
            {
                hairObj[i].SetActive(false);
            }
            if (count > 5)
            {
                count = 0;
            }
        }
        if (count == 0)
        {
            //obj1.SetActive(true);
            hairObj[0].SetActive(true);
        }
        if (count == 1)
        {
            //obj2.SetActive(true);
            hairObj[1].SetActive(true);
        }
        if (count == 2)
        {
            //obj3.SetActive(true);
            hairObj[2].SetActive(true);
        }
        if (count == 3)
        {
            //obj4.SetActive(true);
            hairObj[3].SetActive(true);
        }
        if (count == 4)
        {
            //obj5.SetActive(true);
            hairObj[4].SetActive(true);
        }
        if (count == 5)
        {
            //obj6.SetActive(true);
            hairObj[5].SetActive(true);
        }
        if (count == 6)
        {
            hairObj[6].SetActive(true);
        }

    }
}
