using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour {
    public static int count;
    public GameObject 텍스트1;
    public GameObject Text2;
    public GameObject Cover;
    public GameObject HwakDae;
    public GameObject Next;
    public GameObject Text4;
    public GameObject BattleGo;
    
    
    public void Click2()
    {
       
        SceneManager.LoadScene("Pyj_GameScene");
        
    }
    
    public void Click()
    {
        Next.SetActive(false);
        HwakDae.SetActive(true);
        Text4.SetActive(true);
    }
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
        if (Input.GetMouseButtonDown(0))
        {
            count++;
        }
        if (count == 1)
        {
            텍스트1.SetActive(true);
        }if(count == 2)
        {
            텍스트1.SetActive(false);
            Text2.SetActive(true);
        }
        if (count == 3)
        {
            Text2.SetActive(false);
            Cover.SetActive(true);

        }
        
    }
}
