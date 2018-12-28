using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventTriggr2 : MonoBehaviour
{
    /* GameObject Player;
    //public static int Victory1 = 1;//이벤트 트리거 초기값

    int SetEvent;



    void Start()
    {
    }
    void Update()
    {


        
         if (EventRandom == 2)
        {
            GameObject EventText = GameObject.Find("Eventmanager");
            EventText.GetComponent<Eventmanager1>().EventText1();
            Victory1 = 0;
        }
        */

        /* 
         if (Victory1 == 0) //전투 승리 시, 이벤트 클리어 시 C 값을 0으로 바꾼다.
         {
             Destroy(gameObject); // 0이 될 시 오브젝트 파괴

             GameObject ClearPassage = GameObject.Find("Clearmanager");
             ClearPassage.GetComponent<Clearmanager>().ClearP2();
             //클리어통로 매니저를 찾아 ClearPl 컴포넌트를 실행한다.
         } 
         
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        EventRandom();

    }

    public void EventRandom()
    {
        SetEvent = Random.Range(1, 3);

        if (SetEvent == 1)
        {
            GameObject EventText1 = GameObject.Find("Eventmanager");
            EventText1.GetComponent<Eventmanager1>().EventText1();
            Debug.Log("이벤트 1 출력");

        }
        if (SetEvent == 2)
        {
            GameObject EventText2 = GameObject.Find("Eventmanager");
            EventText2.GetComponent<Eventmanager1>().EventText2();
            Debug.Log("이벤트 2 출력");
        }
    }
    */
}