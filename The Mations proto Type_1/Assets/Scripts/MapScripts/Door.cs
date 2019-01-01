using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform originPos;
    public Vector3 destPos;

    // Start is called before the first frame update
    void Start()
    {
        originPos = GameObject.Find("BSD1").GetComponent<Transform>();
        destPos = new Vector3(-2.0f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (MapManager.instance.currPassageIdx != MapManager.instance.maxPassage)
            {
                MapManager.instance.currPassageIdx += 1;
                collision.transform.position = (originPos.position - destPos);

                MapManager.instance.moveP(MapManager.instance.currPassageIdx - 1);

                Debug.Log("통로 이동");
            }
            else
            {
                Debug.Log("더못가염");
            }
        }
    }
}
