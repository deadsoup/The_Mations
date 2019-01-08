using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 게임데이터 사용하기 위한 선언
using DataInfo;

public class GameManager : MonoBehaviour
{

    // 게임매니저 인스턴스 선언
    public static GameManager instance = null;

    // 들어갈 스테이지 정보 0부터 시작함
    public int currStage = 1;

    // 통로 데이터 처리하는 변수묶음
    public List<StageInfo> StageInfos = new List<StageInfo>();
    // 월드맵과 연결시켜주고 해당 번호에 해당하는 id 값을 불러오고 
    //배틀씬에 들어가면 월드맵ID에따라 몬스터Id(랜덤),보상id 출력 부탁욤

    // 플레이어 마지막 위치 저장하는 변수
    public Vector3 lastPos;
    // 플레이어 마지막 통로위치 저장하는 변수
    public int lastPassage;

    private void Awake()
    {
        // 게임매니저 인스턴스 생성
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        // 어느씬에서든 삭제를 하지 않음
        DontDestroyOnLoad(this.gameObject);

        // 마지막위치
        lastPos.x = -7.5f;
        lastPos.y = -0.07f;

        //StageInfos = DataIO.instance.Read("StagelnfoReal.xml");

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadPassaway();
        }
    }

    // 통로씬 넘어가는 함수
    public void InStage(int stageIdx)
    {
        // 플레이어 시작위치 초기화
        lastPos.x = -7.5f;
        lastPos.y = -0.07f;

        currStage = stageIdx;

        lastPassage = StageInfos[stageIdx].startPassageIdx;

        SceneManager.LoadScene("Passway");
    }

    // Passage씬 정보 저장하는 함수
    public void SaveData(StageInfo saveData, int currStage, int currPassage)
    {
        StageInfos[currStage] = saveData;
        lastPassage = currPassage;
    }

    public void LoadPassaway()
    {
        SceneManager.LoadScene("Passway");
    }
}
