using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle_Tuto : MonoBehaviour
{

    battle Battle;
    GameObject[] BattleTuto_Text = new GameObject[6];
    GameObject LB;
    GameObject RB;

    public void BattleTuto()
    {
        if (TutoDirector.Tuto == 1)
        {
            //여기로 실행되면 됨
            Battle.chaneGetta1();
            //battle.i = ?? 등장 몬스터를 정할 수 있음
        }
    }

    public void BattleEnd()
    {
        if (TutoDirector.Tuto == 1)
        {
            //SceneManager.LoadScene("TutoRialMapScene"); 몬스터 잡고 나오는 보상창 나가기 눌렀을시 신전환이 됨
            //TutoDirector.Tuto = 0;

        }

        for (int i = 0; i < BattleTuto_Text.Length; i++)
        {
            BattleTuto_Text[i] = GameObject.Find("Canvas").transform.Find("BattleTuto_Text").transform.GetChild(i).gameObject;
        }


    }

    




    void Start()
    {
        Battle = GameObject.Find("Battle").transform.Find("battle").GetComponent<battle>();
        Battle.chaneGetta1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
