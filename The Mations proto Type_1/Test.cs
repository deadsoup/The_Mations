using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

    
    int monHp = 2000;
    int pcDmg = 10;
    int Ats = 0;
    int count = 0;
    float rotSpeed = 0;


    bool clear = false;
    bool Deadd = true;
    public int Atk()
    {
       
            Debug.Log("발라카스를 때렷다");
            this.monHp -= this.pcDmg + Ats;
        if (monHp < 2000)
        {
            Ats += 10;
        }
        if (monHp >= 1000 && monHp < 1300)
        {
            Ats += 10;
            Debug.Log("발라카스가 미쳐 날뜁니다");
        }
          
        if (monHp < 1000)
        {
            Ats += 10;
            Debug.Log("발라카스가 비틀거립니다");
        }
            return monHp;
        
        
    }
    public void Dead()
    {
        if(monHp <= 0 && Deadd==true)
        {
            Debug.Log("발라카스 사망");
            clear = true;
            Deadd = false;

            Debug.Log(count+"번");
        }
    }
	// Use this for initialization
	void Start () {
        Debug.Log("발라카스사냥");
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (clear == false&&Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.rotSpeed = 7;
            }
            transform.Rotate(0,0, this.rotSpeed);
            
            count++;
            Atk();
            Debug.Log("공격력이 늘어났다 야호");
            Debug.Log(monHp + "줄었다");
        }

        
        Dead();
        
        
       
    }
}
