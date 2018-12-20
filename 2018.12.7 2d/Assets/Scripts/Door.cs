using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            this.Player.transform.position = new Vector2(43.41f,0.91f); //이동 시킬 좌표 값

            minimapmove.c = 2; //미니맵 좌표 변경
            Debug.Log("통로 이동");
        }
    }
}
