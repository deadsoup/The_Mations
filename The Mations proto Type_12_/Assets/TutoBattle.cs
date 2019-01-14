using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoBattle : MonoBehaviour
{
    public GameObject Tuto1;
    public GameObject Tuto2;
    public GameObject Tuto3;
    public GameObject Tuto4;
    public GameObject Tuto5;
    public GameObject Tuto6;
    public GameObject Tuto7;
    public GameObject Tuto8;
    public GameObject Tuto9;
    public GameObject Tuto10;
    public GameObject Tuto11;
    public GameObject Tuto12;
    public GameObject Tuto13;
    public GameObject Tuto14;
    public GameObject Tuto15;
    public GameObject Tuto16;
    public GameObject Tuto17;
    public GameObject Tuto18;
    public GameObject Tuto19;
    public GameObject Tuto20;
    public static int TUtoCount;

    public void Click()
    {
        TUtoCount+=1;


        //DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        TUtoCount = 0;
        Tuto1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (TUtoCount == 1)
        {
            Tuto1.SetActive(false);
            Tuto2.SetActive(true);
        }
        if (TUtoCount == 2)
        {
            Tuto2.SetActive(false);
            Tuto3.SetActive(true);
        }
        if (TUtoCount == 3)
        {
            Tuto3.SetActive(false);
            Tuto4.SetActive(true);
        }
        if (TUtoCount == 4)
        {
            Tuto4.SetActive(false);
            Tuto5.SetActive(true);
        }
        if (TUtoCount == 5)
        {
            Tuto5.SetActive(false);
            Tuto6.SetActive(true);
        }
        if (TUtoCount == 6)
        {
            Tuto6.SetActive(false);
            Tuto7.SetActive(true);
        }
        if (TUtoCount == 7)
        {
            Tuto7.SetActive(false);
            Tuto8.SetActive(true);
        }
        if (TUtoCount == 8)
        {
            Tuto8.SetActive(false);
            Tuto9.SetActive(true);
        }
        if (TUtoCount == 9)
        {
            Tuto9.SetActive(false);
            Tuto10.SetActive(true);
        }
        if (TUtoCount == 10)
        {
            Tuto10.SetActive(false);
            Tuto11.SetActive(true);
        }
        if (TUtoCount == 11)
        {
            Tuto11.SetActive(false);
            Tuto12.SetActive(true);
        }
        if (TUtoCount == 12)
        {
            Tuto12.SetActive(false);
            Tuto13.SetActive(true);
        }
        if (TUtoCount == 13)
        {
            Tuto13.SetActive(false);
            Tuto14.SetActive(true);
        }
        if (TUtoCount == 14)
        {
            Tuto14.SetActive(false);
            Tuto15.SetActive(true);
        }
        if (TUtoCount == 15)
        {
            Tuto15.SetActive(false);
            Tuto16.SetActive(true);
        }
        if (TUtoCount == 16)
        {
            Tuto16.SetActive(false);
            Tuto17.SetActive(true);
        }
        if (TUtoCount == 17)
        {
            Tuto17.SetActive(false);
            Tuto18.SetActive(true);
        }
        if (TUtoCount == 18)
        {
            Tuto18.SetActive(false);
            Tuto19.SetActive(true);
        }
        if (TUtoCount == 19)
        {
            Tuto19.SetActive(false);
            Tuto20.SetActive(true);
        }
        if (TUtoCount == 20)
        {
            SceneManager.LoadScene("CharScene");
        }
        
    }
}
