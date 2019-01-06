using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour {

     GameObject Bgmamount;
     GameObject Seamount;

    int Bgmcount=0;
    int Secount=0;

    public void Click31()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Click1()
    {
        
        if (Bgmcount < 10 )
        {
            Bgmcount++;
        }
        

    }
    public void Click2()
    {
        
        if (Bgmcount > 0)
        {
            Bgmcount--;
        }
        

    }
    public void Click3()
    {
        if (Secount < 10)
        {
            Secount++;
        }
        

    }
    public void Click4()
    {
        if (Secount > 0)
        {
            Secount--;
        }
        

    }
    // Use this for initialization
    void Start () {
        Bgmamount = GameObject.Find("Bgmamount");
        Seamount = GameObject.Find("Seamount");
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.Bgmamount.GetComponent<Text>().text = Bgmcount.ToString();
        this.Bgmamount.GetComponent<Text>().fontSize = 35;
        this.Seamount.GetComponent<Text>().text = Secount.ToString();
        this.Seamount.GetComponent<Text>().fontSize = 35;

    }
}
