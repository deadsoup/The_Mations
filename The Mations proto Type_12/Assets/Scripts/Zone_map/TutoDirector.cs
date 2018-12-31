using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoDirector : MonoBehaviour
{
    public static int tutocount;
    public static int Tuto;
    public GameObject RButton;
    public GameObject LButton;
    public GameObject MoveTu1;
    public GameObject MoveTu2;
    public GameObject MoveTu3;
    public GameObject MoveTu4;
    public GameObject MoveTu5;
    public GameObject MoveTu6;
    public GameObject MoveBu;
    public GameObject Batu15;
    // Start is called before the first frame update
    void Start()
    {
       
        tutocount = 0;
        RButton.SetActive(false);
        LButton.SetActive(false);
        MoveBu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutocount++;
        }
        if (TutoDirector.Tuto == 2)
        {
            Batu15.SetActive(true);
            RButton.SetActive(true);
            LButton.SetActive(true);
        }
        else if (TutoDirector.Tuto == 1)
        {

            if (TutoDirector.tutocount == 1)
            {
                MoveTu1.SetActive(true);
            }
            if (TutoDirector.tutocount == 2)
            {
                MoveTu1.SetActive(false);
                MoveTu2.SetActive(true);
            }
            if (TutoDirector.tutocount == 3)
            {
                MoveTu2.SetActive(false);
                MoveTu3.SetActive(true);
                MoveBu.SetActive(true);
                RButton.SetActive(true);
                LButton.SetActive(true);
            }
            if (TutoDirector.tutocount == 4)
            {
                MoveTu3.SetActive(false);
                MoveTu4.SetActive(true);
                MoveBu.SetActive(true);

            }
            if (TutoDirector.tutocount == 5)
            {
                MoveTu4.SetActive(false);
                MoveTu5.SetActive(true);
                MoveBu.SetActive(true);

            }
            if (TutoDirector.tutocount == 6)
            {
                MoveBu.SetActive(true);
                MoveTu5.SetActive(false);
                MoveTu6.SetActive(true);


            }
            else if (TutoDirector.Tuto == 2)
            {
                RButton.SetActive(true);
                LButton.SetActive(true);
                
            }
        }



    }
}
