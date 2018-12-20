using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapmove : MonoBehaviour
{
    bool lbutton = false;
    bool rbutton = false;
    public static int c;
    public int d;
    // Use this for initialization
    void Start()
    {
    }
    public void LButtonDown()
    {
        lbutton = true;
    }
    public void RButtonDown()
    {
        rbutton = true;
    }
    public void LButtonUp()
    {
        lbutton = false;
    }
    public void RButtonUp()
    {
        rbutton = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) ) // 체인지 게타원
        {
            c = 1;
            Debug.Log("위쪽 통로 " );
        }

        if (Input.GetKeyDown(KeyCode.W) ) // 체인지 게타투
        {
            c = 2;
            Debug.Log("아래 통로 " );
        }
        if (Input.GetKeyDown(KeyCode.E)) // 체인지 게타투
        {
            c = 3;
            Debug.Log("오른쪽 통로");
        }
        if (Input.GetKeyDown(KeyCode.R)) // 체인지 게타투
        {
            c = 4;
            Debug.Log("왼쪽 통로 ");
        }
        if (c == 1)
        {
            if (lbutton)
            {
                transform.Translate(0, -15 * Time.deltaTime, 0);
            }
            if (rbutton)
            {
                transform.Translate(0, 15 * Time.deltaTime, 0);

            }
        }
        if (c == 2)
        {
            if (lbutton)
            {
                transform.Translate(0, 15 * Time.deltaTime, 0);
            }
            if (rbutton)
            {
                transform.Translate(0, -15 * Time.deltaTime, 0);

            }
        }
        if (c == 3)
        {
            if (lbutton)
            {
                transform.Translate(15 * Time.deltaTime, 0, 0);
            }
            if (rbutton)
            {
                transform.Translate(-15 * Time.deltaTime, 0, 0);

            }
        }
        if (c == 4)
        {
            if (lbutton)
            {
                transform.Translate(-15 * Time.deltaTime, 0, 0);
            }
            if (rbutton)
            {
                transform.Translate(15 * Time.deltaTime, 0, 0);

            }
        }
    }
}