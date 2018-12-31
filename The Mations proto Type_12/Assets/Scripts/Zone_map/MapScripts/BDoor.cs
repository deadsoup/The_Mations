using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDoor : MonoBehaviour
{
    public Transform originPos;
    public Vector3 destPos;

    // Start is called before the first frame update
    void Start()
    {
        originPos = GameObject.Find("SafezoneDoor").GetComponent<Transform>();
        destPos = new Vector3(+2.0f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.position = (originPos.position - destPos);
            Debug.Log("통로 이동");
        }
    }
}
