using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SDoor : MonoBehaviour
{
    public Transform originPos;
    public Vector3 destPos;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        originPos = GameObject.Find("BD1").GetComponent<Transform>();
        destPos = new Vector3(-2.0f, 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            if (collision.gameObject.name == "Player")
            {
                if (MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage[0] == -1)
                {
                    Debug.Log("더못가염");
                }
                // 다음에 가야할 길이 1개일때
                else if (MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage.Count == 1)
                {
                    MapManager.instance.currPassage = MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage[0];
                    collision.transform.position = (originPos.position - destPos);
                    MapManager.instance.CheckEventTrg();

                    // 미니맵 p아이콘 이동
                    MapManager.instance.moveP(MapManager.instance.currPassage);
                    Debug.Log("통로 이동");
                }
                else if (MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage.Count > 1)
                {

                    count = MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage.Count;

                    MapManager.instance.BranchingPaths.SetActive(true);

                    for (int i = 1; i < MapManager.instance.BranchiButton.Count; i++)
                    {
                        MapManager.instance.BranchiButton[i].gameObject.SetActive(false);
                    }

                    for (int i = 1; i < count + 1; i++)
                    {
                        MapManager.instance.BranchiButton[i].gameObject.SetActive(true);
                        MapManager.instance.BranchiButton[i].gameObject.GetComponentInChildren<Text>().text =
                            MapManager.instance.StageInfo.BranchiText[i - 1];
                    }

                    //int randomIdx = Random.Range(0, MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage.Count);

                    //MapManager.instance.currPassage = MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage[randomIdx];
                    //collision.transform.position = (originPos.position - destPos);
                    //MapManager.instance.CheckEventTrg();

                    //// 미니맵 p아이콘 이동
                    //MapManager.instance.moveP(MapManager.instance.currPassage);
                }
            }
            // 이벤트 트리거 체크
            MapManager.instance.CheckEventTrg();
        }
       
    }

    // 갈림길에서 선택해서 통로이동
    public void SetNextPassage(int nextPassage)
    {

    
        
            GameObject player = GameObject.Find("Player");

            MapManager.instance.currPassage = MapManager.instance.StageInfo.passageInfos[MapManager.instance.currPassage].nextPassage[nextPassage];
            MapManager.instance.playerPos.position = (originPos.position - destPos);
            MapManager.instance.CheckEventTrg();

            //// 미니맵 p아이콘 이동
            MapManager.instance.moveP(MapManager.instance.currPassage);
        
     
    }

}
