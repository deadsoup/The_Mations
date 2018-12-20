using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anitest : MonoBehaviour
{
    Animator aniTest;

    public int AniNum;


    // Start is called before the first frame update
    void Start()
    {
       aniTest = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            AniNum++;
        }
        if (AniNum == 4)
        {
            AniNum = 0;
        }
        aniTest.SetInteger("AniNum", AniNum);
        
        
    }
}
