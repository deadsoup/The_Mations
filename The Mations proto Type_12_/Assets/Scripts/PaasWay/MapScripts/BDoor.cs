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
            if (MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].prevPassage == -1)
            {
                Debug.Log("더못가염");
            }
            else
            {
                // 이전맵 번호로 이동
                MapManager.instance.currPassage = MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].prevPassage;
                collision.transform.position = (originPos.position - destPos);
                // 미니맵 p아이콘 이동
                MapManager.instance.moveP(MapManager.instance.currPassage);
                Debug.Log("통로 이동");

            }
        }
      
    }
}
