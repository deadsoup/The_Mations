using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing2 : MonoBehaviour {

    public GameObject Text3;
    public GameObject Text4;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (Testing.count >= 4)
            {
                Text4.SetActive(false);
                Text3.SetActive(true);
            }
        }
    }
}
