using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject[] hairButton = new GameObject[9];

    public GameObject[] upbodyButton = new GameObject[6];

    public GameObject[] downbodyButton = new GameObject[6];

    public GameObject[] hair = new GameObject[9];

    public GameObject[] upbody = new GameObject[6];
                          
    public GameObject[] downbody = new GameObject[6];
    
    



    int Hair;
    static int HairCount;

    int UpBody;
    static int UpBodyCount;

    int DownBody;
    static int DownBodyCount;

    static int saveHair;
    static int saveUp;
    static int saveDown;

    // Use this for initialization
    void Start ()
    {

        
        hair[0].SetActive(true);
        upbody[5].SetActive(true);
        downbody[5].SetActive(true);
        
    }

    public void save()
    {
        PlayerPrefs.SetInt("Hair", HairCount);
        PlayerPrefs.SetInt("Up", UpBodyCount);
        PlayerPrefs.SetInt("Down", DownBodyCount);

        Debug.Log(HairCount);                                                                                                                                                                                                                                                                                                  
        Debug.Log(UpBodyCount);
        Debug.Log(DownBodyCount);

    }
    
    public void load()
    {
        HairCount = PlayerPrefs.GetInt("Hair");
        UpBodyCount = PlayerPrefs.GetInt("Up");
        DownBodyCount = PlayerPrefs.GetInt("Down");

        int c;
        for (c = 0; c <= 8; c++)
        {
            hair[c].SetActive(false);
        }

        int e;
        for (e = 0; e <= 5; e++)
        {
            upbody[e].SetActive(false);
        }

        int f;
        for (f = 0; f <= 5; f++)
        {
            downbody[f].SetActive(false);
        }




        hair[HairCount].SetActive(true);
        upbody[UpBodyCount].SetActive(true);
        downbody[DownBodyCount].SetActive(true);


        Debug.Log(HairCount);
        Debug.Log(UpBodyCount);
        Debug.Log(DownBodyCount);

    }

    




    public void changeHair1()
    {

        HairCount = 0;
        int c;
        for (c = 0; c <= 8; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair2()
    {
        HairCount = 1;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair3()
    {
        HairCount = 2;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair4()
    {
        HairCount = 3;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair5()
    {
        HairCount = 4;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair6()
    {
        HairCount = 5;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair7()
    {
        HairCount = 6;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair8()
    {
        HairCount = 7;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }

    public void changeHair9()
    {
        HairCount = 8;
        int c;
        for (c = 0; c < 9; c++)
        {
            hair[c].SetActive(false);
        }
        hair[HairCount].SetActive(true);

    }



    public void changeUp1()
    {
        UpBodyCount = 0;
        int c;
        for (c = 0; c <= 5; c++)
        {
            upbody[c].SetActive(false);
        }
        upbody[UpBodyCount].SetActive(true);      

    }

    public void changeUp2()
    {
        UpBodyCount = 1;
        int c;
        for (c = 0; c <= 5; c++)
        {
            upbody[c].SetActive(false);
        }
        upbody[UpBodyCount].SetActive(true);

    }

    public void changeUp3()
    {
        UpBodyCount = 2;
        int c;
        for (c = 0; c <= 5; c++)
        {
            upbody[c].SetActive(false);
        }
        upbody[UpBodyCount].SetActive(true);

    }

    public void changeUp4()
    {
        UpBodyCount = 3;
        int c;
        for (c = 0; c <= 5; c++)
        {
            upbody[c].SetActive(false);
        }
        upbody[UpBodyCount].SetActive(true);

    }

    public void changeUp5()
    {
        UpBodyCount = 4;
        int c;
        for (c = 0; c <= 5; c++)
        {
            upbody[c].SetActive(false);
        }
        upbody[UpBodyCount].SetActive(true);

    }

    public void changeUp6()
    {
        UpBodyCount = 5;
        int c;
        for (c = 0; c <= 5; c++)
        {
            upbody[c].SetActive(false);
        }
        upbody[UpBodyCount].SetActive(true);

    }

    public void changeDown1()
    {
        DownBodyCount = 0;
        int c;
        for (c = 0; c <= 5; c++)
        {
            downbody[c].SetActive(false);
        }
        downbody[DownBodyCount].SetActive(true);

    }

    public void changeDonw2()
    {
        DownBodyCount = 1;
        int c;
        for (c = 0; c <= 5; c++)
        {
            downbody[c].SetActive(false);
        }
        downbody[DownBodyCount].SetActive(true);

    }

    public void changeDonw3()
    {
        DownBodyCount = 2;
        int c;
        for (c = 0; c <= 5; c++)
        {
            downbody[c].SetActive(false);
        }
        downbody[DownBodyCount].SetActive(true);

    }

    public void changeDonw4()
    {
        DownBodyCount = 3;
        int c;
        for (c = 0; c <= 5; c++)
        {
            downbody[c].SetActive(false);
        }
        downbody[DownBodyCount].SetActive(true);

    }

    public void changeDonw5()
    {
        DownBodyCount = 4;
        int c;
        for (c = 0; c <= 5; c++)
        {
            downbody[c].SetActive(false);
        }
        downbody[DownBodyCount].SetActive(true);

    }

    public void changeDonw6()
    {
        DownBodyCount = 5;
        int c;
        for (c = 0; c <= 5; c++)
        {
            downbody[c].SetActive(false);
        }
        downbody[DownBodyCount].SetActive(true);

    }

    

    // Update is called once per frame
    void Update ()
    {


	}
}
