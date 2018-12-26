using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.IO;

public class RewardDatabase : MonoBehaviour
{
    public List<Equip> database = new List<Equip>();
    private JsonData itemData;


    public List<Equip> playerInfoList = new List<Equip>();

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/ItemData.json"));
        ContructItemDatabase();
        //saveJson();
    }



    public Equip FetchItemByID(int id)
    {
        print("패치아이템");
        for (int i = 0; i < database.Count; i++)
        {
            print("패치아이템.카운트");
            if (database[i].Id == id)
                return database[i];
        }
        return null;
    }




    /*
    void saveJson()
    {
        playerInfoList.Add(new Equip(0, 1, "단검", "보통", "작은 칼이다. 피해량 + 1", 0, 0, 1, 0, 0, "W_Dagger001", false));
        playerInfoList.Add(new Equip(1, 1, "톱", "보통", "목재용 톱. 피해량 + 1", 0, 0, 1, 0, 0, "W_Sword007", false));
        playerInfoList.Add(new Equip(2, 1, "권총", "보통", "소구경 권총. 피해량 + 2", 0, 0, 2, 0, 0, "W_Gun001", false));
        playerInfoList.Add(new Equip(3, 1, "장검", "고급", "서양식 양날검. 피해량 + 3", 0, 0, 3, 0, 0, "W_Sword001", false));
        playerInfoList.Add(new Equip(4, 1, "레이저검", "고급", "**워즈의 광선검. 피해량 + 3", 0, 0, 3, 0, 0, "W_Sword017", false));
        playerInfoList.Add(new Equip(5, 1, "병건", "희귀", "병-건. 피해량 + 4", 0, 0, 4, 0, 0, "I_Cannon01", false));

        JsonData jsonData = JsonMapper.ToJson(playerInfoList);

        File.WriteAllText(Application.dataPath + "/ItemData.json", jsonData.ToString());
    }
    */


    void ContructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add
                (new Equip(
                    (int)itemData[i]["Id"],
                    (int)itemData[i]["Type"],
                    itemData[i]["Name"].ToString(),
                    itemData[i]["Grade"].ToString(),
                    itemData[i]["Text"].ToString(),
                    (int)itemData[i]["MaxHp"],
                    (int)itemData[i]["MaxMp"],
                    (int)itemData[i]["Str"],
                    (int)itemData[i]["Dex"],
                    (int)itemData[i]["Wis"],
                    itemData[i]["IconName"].ToString(),
                    (bool)itemData[i]["Stackable"]));


        }
    }

}

