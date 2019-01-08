using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player1;
    GameObject player2;

	// Use this for initialization
	void Start () {
        this.player1 = GameObject.Find("Player");
        
    }
	
	// Update is called once per frame
	void Update () {

        
        
            Vector3 playerPos = this.player1.transform.position;
            transform.position = new Vector3(
             playerPos.x, playerPos.y, transform.position.z);
        
      

    }
}
