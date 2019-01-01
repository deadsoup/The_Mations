using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoBattle : MonoBehaviour
{
    public int Tubattle;
    public GameObject Batu;
    public GameObject TUcover;
    public GameObject Batu2;
    public GameObject Batu3;
    public GameObject Batu4;
    public GameObject Batu5;
    public GameObject Batu6;
    public GameObject Batu7;
    public GameObject Batu8;
    public GameObject Batu9;
    public GameObject Batu10;
    public GameObject Batu11;
    public GameObject Batu12;
    public GameObject Batu13;
    public GameObject Batu14;
    public GameObject Batu15;
    public GameObject Uiarrow;
    public GameObject Uiarrow2;
    public GameObject Uiarrow3;
    public GameObject Uiarrow4;
    public GameObject Uiarrow5;


    // Start is called before the first frame update
    void Start()
    {
        Tubattle = 0;
        TUcover.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tubattle += 1;
        }
        if (Tubattle == 1)
        {
            Batu.SetActive(true);
            Uiarrow.SetActive(true);
        }
        if (Tubattle == 2)
        {
            Batu.SetActive(false);
            Batu2.SetActive(true);
            Uiarrow.SetActive(true);

        }
        if (Tubattle == 3)
        {
            Batu2.SetActive(false);
            Batu3.SetActive(true);
            Uiarrow.SetActive(true);

        }
        if (Tubattle == 4)
        {
            Batu3.SetActive(false);
            Batu4.SetActive(true);
            Uiarrow.SetActive(false);
            
            

        }
        if (Tubattle == 5)
        {
            Batu4.SetActive(false);
            Batu5.SetActive(true);
            
            Uiarrow2.SetActive(true);
            TUcover.SetActive(false);

        }
        if (Tubattle == 9)
        {
            Batu5.SetActive(false);
            Batu6.SetActive(true);

            Uiarrow2.SetActive(false);
            TUcover.SetActive(true);

        }
        if (Tubattle == 10)
        {
            Batu6.SetActive(false);
            Batu7.SetActive(true);

            Uiarrow.SetActive(true);
           

        }
        if (Tubattle == 11)
        {
            Batu7.SetActive(false);
            Batu8.SetActive(true);
            Uiarrow.SetActive(false);
            Uiarrow3.SetActive(true);
            TUcover.SetActive(false);


        }
        if (Tubattle == 13)
        {
            Batu8.SetActive(false);
            Batu9.SetActive(true);
            Uiarrow3.SetActive(false);
            Uiarrow2.SetActive(true);
            TUcover.SetActive(false);


        }
        if (Tubattle == 16)
        {
            Batu8.SetActive(false);
            Batu9.SetActive(true);
            Uiarrow2.SetActive(false);
            Uiarrow3.SetActive(true);
            TUcover.SetActive(false);


        }
        if (Tubattle == 17)
        {
            Batu8.SetActive(false);
            Batu9.SetActive(true);
            Uiarrow3.SetActive(false);
            Uiarrow2.SetActive(true);
            TUcover.SetActive(false);


        }
        if (Tubattle == 19)
        {
            Batu9.SetActive(false);
            Batu10.SetActive(true);
            Uiarrow2.SetActive(false);
            Uiarrow4.SetActive(true);

            TUcover.SetActive(false);

        }
        if (Tubattle == 23)
        {
            Batu10.SetActive(false);
            Batu11.SetActive(true);
            Uiarrow4.SetActive(true);

            TUcover.SetActive(false);


        }
        if (Tubattle == 24)
        {
            Batu11.SetActive(false);
            Batu13.SetActive(true);
            Uiarrow4.SetActive(false);
            Uiarrow5.SetActive(true);
            TUcover.SetActive(false);


        }
        if (Tubattle == 31)
        {
            Batu13.SetActive(false);
            Batu14.SetActive(true);
            Uiarrow5.SetActive(false);
            
            TUcover.SetActive(false);


        }




    }
}
