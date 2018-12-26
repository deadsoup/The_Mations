using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour {

    public GameObject BgmAmount;
    public GameObject SeAmount;

    int Bgmcount=5;
    int Secount=5;

    public void BgmUP()
    {
        
        if (Bgmcount < 10 )
        {
            Bgmcount++;
        }
        

    }
    public void BgmDown()
    {
        
        if (Bgmcount > 0)
        {
            Bgmcount--;
        }
        

    }
    public void SeUP()
    {
        if (Secount < 10)
        {
            Secount++;
        }
        

    }
    public void SeDown()
    {
        if (Secount > 0)
        {
            Secount--;
        }
        

    }
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.BgmAmount.GetComponent<Text>().text = "배경음 :                 "+Bgmcount.ToString();
        this.SeAmount.GetComponent<Text>().text = "효과음 :                 " + Secount.ToString();

    }
}
