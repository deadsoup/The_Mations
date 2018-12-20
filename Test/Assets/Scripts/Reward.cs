using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reward : MonoBehaviour
{

    [System.Serializable]
    public class RewardScript
    {
        public RewardScriptData[] data;
    }

    [System.Serializable]
    public class RewardScriptData
    {
        public int Id;
        public string Name;
        public string Text;
        public int MaxHp;
        public int MaxMp;
        public int Str;
        public int Dex;
        public int Wis;
    }

    RewardScript reward;




    void Awake()
    {
        reward = JsonUtility.FromJson<RewardScript>(File.ReadAllText(Application.dataPath + "/ItemData.json"));
    }
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Inven.Id.Length; i++)
        {
            Inven.Id[i] = reward.data[i].Id;
            Inven.Name[i] = reward.data[i].Name;
            Inven.Text[i] = reward.data[i].Text;
            Inven.MaxHp[i] = reward.data[i].MaxHp;
            Inven.MaxMp[i] = reward.data[i].MaxMp;
            Inven.Str[i] = reward.data[i].Str;
            Inven.Dex[i] = reward.data[i].Dex;
            Inven.Wis[i] = reward.data[i].Wis;
        }






    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
