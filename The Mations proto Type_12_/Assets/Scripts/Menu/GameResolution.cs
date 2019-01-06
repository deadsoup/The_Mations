using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResolution: MonoBehaviour
{

    /*  UI -------------
     *  1- 메인화면
     *  2- 배경설명화면
     *  3- 게임진행튜토리얼 -월드맵
     *  4- 게임진행튜토리얼 -통로
     *  5- 게임진행튜토리얼 -전투
     *  
     *  6- 월드맵
     *  7- 통로
     *  8- 전투
     *  
     *  System --------
     *  메뉴
     *  1- 화면 전환
     *  2- 게임 불러오기
     *  3- 게임 사운드 볼륨 조절
     *  
     *  월드맵
     *  1- 지역정보 팝업
     *  2- 캐릭터 정보
     
         */

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1280, 720, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
