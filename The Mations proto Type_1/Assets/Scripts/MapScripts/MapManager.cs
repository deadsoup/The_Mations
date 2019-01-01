using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTriggerInfo
{
    public string name;
    public bool IsClear;
    
    // 필요정보에따라서 변수 추가
}

public class MapManager : MonoBehaviour
{
    // 확인용 텍스트(삭제해도되요)
    public Text text;
    // 현재 맵 번호
    public int currPassageIdx = 1;
    // 스테이지 최대 맵 크기
    public int maxPassage = 3;
    // 이벤트 트리거 오브젝트 받아올 변수
    public GameObject eventObj;

    // 미니맵 클리어?? 체크용 변수
    public List<GameObject> ClearPassages = new List<GameObject>();

    public Transform miniP;

    // 이벤트 트리거 정보 관리할 List변수
    public List<EventTriggerInfo> events = new List<EventTriggerInfo>();

    public static MapManager instance = null;

    private void Awake()
    {
        // 다른 스크립트에서 접근할수있는 인스턴스 생성
        if (instance == null)
            instance = this;

        eventObj = GameObject.Find("EventTriggr");


        for (int i = 0; i < maxPassage; i++)
        {
            EventTriggerInfo InitEvent = new EventTriggerInfo();
            InitEvent.IsClear = false;

            events.Add(InitEvent);
        }
        // 이부분은 나중에 문서화하면 편하게 가능...
        events[0].name = "통로1 이벤트 클리어";
        events[1].name = "통로2 이벤트 클리어";
        events[2].name = "통로3 이벤트 클리어";

        SetClearPassage();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 텍스트 지울떄 지워도됩니다.
        text.text = "현재통로 : " + currPassageIdx.ToString();
    }

    // 해당 통로에 진입할떄 이벤트 트리거가
    // 완료되었는지 체크하는 함수
    public void CheckEventTrg()
    {
        if(events[currPassageIdx - 1].IsClear == false)
        {
            eventObj.SetActive(true);
        }
        else
        {
            eventObj.SetActive(false);
        }
    }

    // 이벤트 트리거와 충돌할때 발생하는 함수
    public void StartEventTrg()
    {
        // 이벤트 트리거 확인용 로그
        Debug.Log(string.Format("{0} 번통로 전투 시작", currPassageIdx.ToString()));
        Debug.Log(events[currPassageIdx - 1].name);

        var rnd = Random.Range(0, 2);
        if (TutoDirector.Tuto == 1)
        {
            Eventmanager1.instance.BatteEvent();
            Debug.Log("전투 출력");
        }
        else if (rnd == 0&&TutoDirector.Tuto == 0)
        {
            var SetEvent = Random.Range(0, 2);
            Eventmanager1.instance.EventText(SetEvent);
            Debug.Log("이벤트 출력" + SetEvent.ToString());
        }
        else
        {
            Eventmanager1.instance.BatteEvent();
            Debug.Log("전투 출력");
        }
       

        //if (SetEvent == 1)
        //{
        //    GameObject EventText1 = GameObject.Find("Eventmanager");
        //    EventText1.GetComponent<Eventmanager1>().EventText1();
        //    Debug.Log("이벤트 1 출력");

        //}
        //if (SetEvent == 2)
        //{
        //    GameObject EventText2 = GameObject.Find("Eventmanager");
        //    EventText2.GetComponent<Eventmanager1>().EventText2();
        //    Debug.Log("이벤트 2 출력");
        //}


        // 해당 통로의 이벤트 트리거 완료처리
        events[currPassageIdx - 1].IsClear = true;
        eventObj.SetActive(false);
        // 미니맵 불켜줌
        ClearPassages[currPassageIdx - 1].SetActive(true);
    }

    public void moveP(int passage)
    {
        miniP.position = ClearPassages[passage].transform.position;
    }

    private void SetClearPassage()
    {
        GameObject group = GameObject.Find("Pminimap");

        var childrens = group.GetComponentsInChildren<Transform>();

        // 미니맵 관련 오브젝트 검출
        for(int i = 0; i < childrens.Length; i++)
        {
            ClearPassages.Add(childrens[i].gameObject);
        }

        // 미니맵과 P는 리스트에서 제거
        ClearPassages.RemoveAt(ClearPassages.Count - 1);
        ClearPassages.RemoveAt(0);

        // ClearPassage 오프해줌
        for(int i = 0; i < ClearPassages.Count; i++)
        {
            ClearPassages[i].SetActive(false);
        }
    }
}
