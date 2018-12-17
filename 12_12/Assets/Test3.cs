using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Test3 : MonoBehaviour
{
    //플레이어 클래스
    public class PlayerInfo 
    {
        public int Id;
        public string Name;
        public double Gold;
        public PlayerInfo(int id, string name, double gold)
        {
            Id = id;
            Name = name;
            Gold = gold;

        }




    }

    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();

    //public playerInfo[] playerList = new playerInfo[5];


    void SaveJson()
    {
        print("Save Json File");
        playerInfoList.Add(new PlayerInfo(1, "아리수", 100));
        playerInfoList.Add(new PlayerInfo(1, "김수한무", 1000));
        playerInfoList.Add(new PlayerInfo(1, "김한수", 10000));
        playerInfoList.Add(new PlayerInfo(1, "무리수", 100000));

        JsonData jsonData = JsonMapper.ToJson(playerInfoList);

        File.WriteAllText(Application.dataPath + "/JsonData/PlayerInfoData.json", jsonData.ToString()); 
        //파일에 전부 텍스트로 쓴다 (어플리케이션가 설치된 주소를 기록 + "Json파일을 설치할 폴더 위치와 파일명 기입", 그리고 jsonData를 문자열로 해달라)

    }
    string jsonString;

    void LoadJson()
    {

        jsonString = "";
        jsonString = File.ReadAllText(Application.dataPath + "/JsonData/PlayerInfoData.json");
        JsonData playerData = JsonMapper.ToObject(jsonString);
        



        for (int i = 0; i < playerData.Count; i++)
        {
            print(playerData[i]["Id"] + "," + playerData[i]["Name"] + "," + playerData[i]["Gold"]);
        }




    }

    // Start is called before the first frame update
    void Start()
    {
        //SaveJson();
        LoadJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
