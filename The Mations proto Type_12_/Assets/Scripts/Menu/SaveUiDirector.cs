using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUiDirector : MonoBehaviour
{

    public GameObject AutoGood;
    public GameObject StickGood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AutoGood.SetActive(false);
            StickGood.SetActive(false);
        }
    }
}
