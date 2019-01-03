using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // 체인지 게타원
        {

            PlayerPrefs.SetInt("C", EventTriggr.c);
            PlayerPrefs.Save();
            
            Debug.Log("세이브 됨 ");
        }
        if (Input.GetKeyDown(KeyCode.W)) // 체인지 게타원
        {

            EventTriggr.c = PlayerPrefs.GetInt("C");

            Debug.Log("로드 됨 ");
            Debug.Log(EventTriggr.c);
        }

    }
}
