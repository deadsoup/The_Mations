using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Testing : MonoBehaviour {
    public static int count;
    public GameObject 텍스트1;
    public GameObject Text2;
    public GameObject Cover;
    public GameObject HwakDae;
    public GameObject Next;
    public GameObject Text4;
    public GameObject BattleGo;
    public GameObject TitleGo;
    public GameObject Intext;
    
    
    public void Click3()
    {
        if (Option.Coin == 0)
        {
            SceneManager.LoadScene("Pyj_GameScene");
        }
    }
    public void Click2()
    {
        if (Option.Coin == 0)
        {
            Intext.SetActive(true);
        }
    }
    public void Click4()
    {
        if (Option.Coin == 0)
        {
            Intext.SetActive(false);
        }
    }
    
    public void Click()
    {
        if (Option.Coin == 0)
        {
            Next.SetActive(false);
            HwakDae.SetActive(true);
            Text4.SetActive(true);
        }
    }
    // Use this for initialization
	void Start () {
        StartDirector.count = true;
       
        Option.Coin = 0;
        count = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && Option.Coin == 0)
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
