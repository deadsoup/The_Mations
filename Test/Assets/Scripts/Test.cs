using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour {
    
    public struct hero_1
    {
        public string name;
        public int Hp;
        public int Mp;
    }
    
    public struct hero_2
    {
        public string name;
        public int Hp;
        public int Mp;
    }

    int a;
    int b;
    int c;
    int money;

    bool set = true;
    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {   if (Input.GetMouseButtonDown(0)) { set = true; }

        if (Input.GetMouseButtonDown(0) && set == true)
        {

            c++;
            Debug.Log("주사위를 굴립니다 총 "+ c+" 번 던졌습니다.");

            a = Random.Range(1, 7);
            b = Random.Range(1, 7);

            

            if (a == 6 && b == 6 && set == true)
            {
                money += 100000;
                Debug.Log("1번 주사위는 " + a);
                Debug.Log("2번 주사위는 " + b);
                Debug.Log("현재 총 " + money + "원 획득" + " (******십만원*******" + "획득)");
                set = false;
            }

            if (a == b && set == true)
            {
                Debug.Log("1번 주사위는 " + a);
                Debug.Log("2번 주사위는 " + b);
                
                Debug.Log("재시도");
                set = false;
            }

            else if (set == true)
            {
                int d = a + b;

                if (d <= 6)
                {
                    money += 100;
                    Debug.Log("1번 주사위는 " + a);
                    Debug.Log("2번 주사위는 " + b);
                    Debug.Log("현재 총 "+money +"원 획득"+ " (백원" + "획득)");
                }

                if (d >= 7)
                {
                    money += 1000;
                    Debug.Log("1번 주사위는 " + a);
                    Debug.Log("2번 주사위는 " + b);
                    Debug.Log("현재 총 " + money + "원 획득" + " (천원" + "획득)");
                }

                if (d >= 12)
                {
                    money += 10000;
                    Debug.Log("1번 주사위는 " + a);
                    Debug.Log("2번 주사위는 " + b);
                    Debug.Log("현재 총 " + money + "원 획득" + " (만원" + "획득)");
                }

            }
        }

    }
}
