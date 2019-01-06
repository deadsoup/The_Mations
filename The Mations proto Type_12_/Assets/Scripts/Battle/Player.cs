using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Player : MonoBehaviour {



    [System.Serializable]
    public class PlayerScript
    {
        public PlayerScripttData[] data;
    }

    [System.Serializable]
    public class PlayerScripttData
    {
        public int Id;
        public string Name;
        public int MaxHp;
        public int Hp;
        public int MaxMp;
        public int Mp;
        public int Str;
        public int Dex;
        public int Wis;
    }
     
    public PlayerScript player;




    /*
    public void getActionGage()
    {
        npc.actiongage -= actiongage;
        
    }

    public float setActionGage()
    {
        return npc.actiongage;
    }
    */
    void load()
    {
        string filePath = Application.streamingAssetsPath + "/PlayerInfoData.json";
        string jsonString;
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            jsonString = reader.text;
        }
        else
        {
            jsonString = File.ReadAllText(filePath);
        }
        player = JsonUtility.FromJson<PlayerScript>(jsonString);
    }




    // Use this for initialization
    void Start ()
    {
        Debug.Log(Application.persistentDataPath + "/Json/PlayerInfoData.json");
        //player = JsonUtility.FromJson<PlayerScript>(File.ReadAllText(Application.persistentDataPath + "/Json/PlayerInfoData.json"));
        load();

        npc.Id[0] = player.data[0].Id;
        npc.name[0] = player.data[0].Name;
        npc.MaxHp[0] = player.data[0].MaxHp;
        npc.Hp[0] = player.data[0].Hp;
        npc.MaxMp[0] = player.data[0].MaxMp;
        npc.Mp[0] = player.data[0].Mp;
        npc.Str[0] = player.data[0].Str;
        npc.Dex[0] = player.data[0].Dex;
        npc.Wis[0] = player.data[0].Wis;




        npc.Id[1] = player.data[1].Id;
        npc.name[1] = player.data[1].Name;
        npc.MaxHp[1] = player.data[1].MaxHp;
        npc.Hp[1] = player.data[1].Hp;
        npc.MaxMp[1] = player.data[1].MaxMp;
        npc.Mp[1] = player.data[1].Mp;
        npc.Str[1] = player.data[1].Str;
        npc.Dex[1] = player.data[1].Dex;
        npc.Wis[1] = player.data[1].Wis;

        npc.Id[2] = player.data[2].Id;
        npc.name[2] = player.data[2].Name;
        npc.MaxHp[2] = player.data[2].MaxHp;
        npc.Hp[2] = player.data[2].Hp;
        npc.MaxMp[2] = player.data[2].MaxMp;
        npc.Mp[2] = player.data[2].Mp;
        npc.Str[2] = player.data[2].Str;
        npc.Dex[2] = player.data[2].Dex;
        npc.Wis[2] = player.data[2].Wis;




    }
	
	// Update is called once per frame
	void Update ()
    {/*
        if (npc.actiongage >= 3.0f && action == true && Hp > 0)
        {
            Attak();
            Debug.Log("현재 남은 액션 게이지 = " + npc.actiongage + "다");
            Debug.Log(name + "은 " + npc.name[2] + "에게 " + damage + "를 가했다.");
            Debug.Log(npc.name[2] + "은 " + npc.Hp[2] + "가 남았다.");
            Debug.Log(action);
        }*/
    }
}
