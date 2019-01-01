using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    GameObject player;
	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("Player"); 
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(
         playerPos.x , playerPos.y , transform.position.z);
	}
}
