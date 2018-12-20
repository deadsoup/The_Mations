using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventTriggr : MonoBehaviour
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
            Debug.Log("전투시작");
            Destroy(gameObject);
        }
    }
}
