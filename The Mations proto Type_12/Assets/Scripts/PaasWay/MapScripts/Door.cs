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
            collision.transform.position = (originPos.position - destPos);

            // 처음 세이프존 진입시 미니맵 클리어 체크
            if(MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].ClearMap == false)
            {
                MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].ClearMap = true;
            }

            // 미니맵 클리어(초록불) 체크
            MapManager.instance.CheckClearMap();
            Debug.Log("통로 이동");
        }
    }
}
