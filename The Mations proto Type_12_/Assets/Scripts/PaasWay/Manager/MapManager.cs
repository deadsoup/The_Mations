using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DataInfo;


public class MapManager : MonoBehaviour
{
    // 확인용 텍스트(삭제해도되요)
    public Text text;

    // 이벤트 트리거 오브젝트 받아올 변수
    public GameObject eventObj;

    // 플레이어 위치변수
    public Transform playerPos;
    public Transform miniP;

    public Vector3 vec3;

    public static MapManager instance = null;

    // 현재 스테이지 통로 정보
    public StageInfo StageInfo = new StageInfo();
    // 현재 스테이지
    public int currStage;

    // 현재 통로위치
    public int currPassage;

    // 세이프존 체크
    //public bool IsSafe

    // 미니맵 초록불
    public GameObject clearPassage;
    // 미니맵 클리어?? 체크용 변수
    public List<GameObject> clearPassages = new List<GameObject>();

    // 받아올 미니맵 이미지
    public Sprite newSprite;
    // 적용할 미니맵 이미지
    public Image minimapImage;

    // 갈림길 버튼 오브젝트
    public GameObject BranchingPaths;
    // 버튼할당
    public List<Button> BranchiButton = new List<Button>();

    // 나가기 버튼
    public GameObject ExitButton;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        // 다른 스크립트에서 접근할수있는 인스턴스 생성
        if (instance == null)
            instance = this;

        // 현재 스테이지 번호받아옴
        currStage = GameManager.instance.currStage;

        // 현재 통로위치 받아옴
        currPassage = GameManager.instance.lastPassage;

        // 맵매니저에 필요한 정보를 게임 매니저로 부터 할당
        // Load역할이 되는거심니다.
        StageInfo = GameManager.instance.StageInfos[currStage];

        eventObj = GameObject.Find("EventTriggr");

        // 초록불들어오는거 정보세팅
        SetClearPassage();
        // 미니맵 P 위치 세팅
        moveP(GameManager.instance.lastPassage);

        // 플레이어 위치정보 받아옴
        playerPos.position = GameManager.instance.lastPos;

        // 전투에서 돌아올때 현재 이벤트 트리거 체크
        CheckEventTrg();

        // 미니맵 리소스(이미지)할당
        newSprite = Resources.Load<Sprite>(StageInfo.minimapResources);
        minimapImage.overrideSprite = newSprite;

        // 갈림길 버튼 할당
        SetButton();
    }
    // Update is called once per frame
    void Update()
    {
        // 텍스트 지울떄 지워도됩니다.
        text.text = string.Format(" 현재스테이지 : {1}", currPassage.ToString(), currStage);

    }
    // 해당 통로에 진입할떄 이벤트 트리거가
    // 완료되었는지 체크하는 함수
    public void CheckEventTrg()
    {
        if(StageInfo.passageInfos[currPassage].ClearTrg == false)
        {
            eventObj.SetActive(true);
        }
        else
        {
            eventObj.SetActive(false);
        }
    }

    //클리어 통로 오브젝트 위치를 찾아서 미니맵 p 아이콘에 대입
    public void moveP(int passage)
    {
        miniP.position = clearPassages[passage].transform.position;
    }

    // 이벤트 트리거와 충돌할때 발생하는 함수
    public void StartEventTrg()
    {
        // 이벤트 트리거 확인용 로그
        Debug.Log(string.Format("{0} 번통로 트리거 시작", currPassage.ToString()));
        Debug.Log(StageInfo.passageInfos[currPassage].name);

        // 전투, 이벤트 시작처리
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            int SetEvent = 0;


            //####################
            // 이벤트 트리거 완성되면
            // 주석풀어야함

            // 스테이지 1이상 6이하
            //if (currStage <= 6 && currStage >= 1)
            //{
            //    SetEvent = Random.Range(0, 5); // 이벤트 번호 0 ~ 4
            //}
            //// 스테이지 7이상 12이하
            //else if(currStage <= 12 && currStage >= 7)
            //{
            //    SetEvent = Random.Range(5, 10); // 이벤트 번호 5 ~ 9
            //}

            Eventmanager1.instance.EventText(SetEvent);
            Debug.Log("이벤트 출력" + SetEvent.ToString());
        }
        else
        {
            // 전투씬 넘어가기전 플레이어 위치정보 저장
            GameManager.instance.lastPos = playerPos.position;
            // 게임매니저한테 정보를 넘김 (중간정보 세이브기능)
            GameManager.instance.SaveData(StageInfo, currStage, currPassage);

            Move.mobIdx = StageInfo.MonsterList[Random.Range(0, StageInfo.MonsterList.Count)] + 10;
            Debug.Log("몬스터 번호 : " + Move.mobIdx.ToString());
            Eventmanager1.instance.BatteEvent();
            Debug.Log("전투 출력");
        }
        // 해당 통로의 이벤트 트리거 완료처리
        StageInfo.passageInfos[currPassage].ClearTrg = true;
        eventObj.SetActive(false);
    }


    private void SetClearPassage()
    {
        GameObject group = GameObject.Find("Pminimap");

        float startX = -75.3f;
        float startY = 57.2f;

        float intervalX = 50.2f;
        float intervalY = 34.9f;

        // 미니맵 정보 16개 세팅
        for (int i = 0; i < 16; i++)
        {
            GameObject tempClearPassage = Instantiate(clearPassage, group.transform);
            tempClearPassage.transform.localPosition = new Vector3(startX + (i % 4) * intervalX, startY - (i / 4) * intervalY, 0.0f);
            tempClearPassage.SetActive(false);
            clearPassages.Add(tempClearPassage);
        }

        // 미니맵 클리어(초록불) 체크
        CheckClearMap();

        // 하이어라키 목록에서 제일 아래로 밀어줌
        miniP.SetAsLastSibling();
    }

    // 미니맵 클리어(초록불) 체크
    public void CheckClearMap()
    {
        for (int i = 0; i < clearPassages.Count; i++)
        {
            if (StageInfo.passageInfos[i].ClearMap == true)
                clearPassages[i].SetActive(true);
            else
                clearPassages[i].SetActive(false);
            
        }

        if(currPassage == StageInfo.endPassageIdx)
        {
            ExitButton.SetActive(true);
        }
        else
        {
            ExitButton.SetActive(false);
        }
    }

    // 갈림길 버튼 할당
    private void SetButton()
    {
        var obj = BranchingPaths.GetComponentsInChildren<Button>();
        for(int i = 0; i < obj.Length; i++)
        {
            BranchiButton.Add(obj[i]);
        }
    }

    // 월드맵씬
    public void ExitBattleScene()
    {
        if(GameManager.instance.StageInfos[currStage].FirstClear == false)
        {
            GameManager.instance.StageInfos[currStage].FirstClear = true;
            QuestDirector.count += 1;

            
        }

        SceneManager.LoadScene("GameScene");
    }

}
