using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventTriggr : MonoBehaviour
{
    GameObject Player;
    public static int c = 1;  //이벤트 트리거 초기값


    void Start()
    {
    }
    void Update()
    {
        //if (c == 0) //전투 승리 시, 이벤트 클리어 시 C 값을 0으로 바꾼다.
        //{
        //    Destroy(gameObject); // 0이 될 시 오브젝트 파괴

        //    GameObject ClearPassage = GameObject.Find("Clearmanagar");
        //    ClearPassage.GetComponent<Clearmanager>().ClearP1();
        //    //클리어통로 매니저를 찾아 ClearPl 컴포넌트를 실행한다.
        //}
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("전투시작");
        //c = 0;

        MapManager.instance.StartEventTrg();
    }
}
