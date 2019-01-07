using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataInfo
{
    // 인스펙터창 확인용 코드 (삭제해도되용)
    [System.Serializable]
    public class PassageInfo
    {
        public string name;
        public bool ClearTrg;
        public bool ClearMap;
        public int prevPassage;

        // 넘어갈 통로좌표(2개이상부터 갈림길)
        public List<int> nextPassage = new List<int>();

        //public PassageInfo(string Name, bool clearTrg, int PrevPassage, params int[] NextPassage)
        //{
        //    name = Name;
        //    ClearTrg = clearTrg;
        //    ClearMap = false;
        //    prevPassage = PrevPassage;

        //    for(int i = 0; i < NextPassage.Length; i++)
        //    {
        //        nextPassage.Add(NextPassage[i]);
        //    }
        //}

    }
    [System.Serializable]
    public class StageInfo
    {
        // 현재 맵 번호
        public int startPassageIdx;
        // 스테이지 최대 맵 크기
        public int endPassageIdx;

        public bool FirstClear;

        // 배경맵 이미지 리소스주소
        public string backgroundResources;
        // 미니맵 이미지 리소스주소
        public string minimapResources;

        // 통로 정보들 관리하는 목록
        public List<PassageInfo> passageInfos = new List<PassageInfo>();


    }
}
