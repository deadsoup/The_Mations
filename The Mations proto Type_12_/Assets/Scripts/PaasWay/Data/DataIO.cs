using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml;
using System.Text;
using System;
using DataInfo;

public class DataIO : MonoBehaviour
{
    public List<StageInfo> StageInfos = new List<StageInfo>();

    public static DataIO instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        StartCoroutine(Process("StagelnfoReal.xml"));
    }

    private void Start()
    {
 
        

    }

    // 데이터저장
    public static void Write(List<StageInfo> StageInfo, string filePath)
    {
        XmlDocument Document = new XmlDocument();
        XmlElement ItemListElement = Document.CreateElement("StageInfo");
        Document.AppendChild(ItemListElement);

        int index = 0;

        foreach (StageInfo stageData in StageInfo)
        {
            XmlElement StageElement = Document.CreateElement("StageList");

            StageElement.SetAttribute("Index",index.ToString());
            StageElement.SetAttribute("StartPassage", stageData.startPassageIdx.ToString());
            StageElement.SetAttribute("EndPassage", stageData.endPassageIdx.ToString());
            StageElement.SetAttribute("BackgroundName", stageData.backgroundResources);
            StageElement.SetAttribute("MinimapName", stageData.minimapResources);

            for(int i = 0; i < 16; i++)
            {
                StageElement.SetAttribute("PassageName_" + i.ToString(), stageData.passageInfos[i].name);
                StageElement.SetAttribute("prevePassage_" + i.ToString(), stageData.passageInfos[i].prevPassage.ToString());
                for(int j = 0; j < 3; j++)
                {
                    StageElement.SetAttribute("nextPassage_" + i.ToString() + "_" + j.ToString(), stageData.passageInfos[i].nextPassage[j].ToString());
                }
            }


            index++;
            ItemListElement.AppendChild(StageElement);
        }
        Document.Save(filePath);
    }

    // 데이터 읽기
    public void Read(string filePath)
    {
        XmlDocument Document = new XmlDocument();

        StringReader stringreader = new StringReader(filePath);
        //stringreader.Read(); BOM 제거한 데이터로 파싱

        XmlNodeList xmlNodeList = null;
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            Document.LoadXml(stringreader.ReadToEnd());
        }
        catch (Exception e)
        {
            Document.LoadXml(filePath);
        }

        // 최상위 노드 선택
        xmlNodeList = Document.SelectNodes("StageInfo");

        List<StageInfo> ItemList = new List<StageInfo>();

        foreach (XmlNode node in xmlNodeList)
        {
            // 자식이 있을때 반복
            if (node.Name.Equals("StageInfo") && node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {

                    StageInfo StageInfo = new StageInfo();
                    StageInfo.startPassageIdx = int.Parse(child.Attributes.GetNamedItem("StartPassage").Value);
                    StageInfo.endPassageIdx = int.Parse(child.Attributes.GetNamedItem("EndPassage").Value);
                    StageInfo.backgroundResources = child.Attributes.GetNamedItem("BackgroundName").Value;
                    StageInfo.minimapResources = child.Attributes.GetNamedItem("MinimapName").Value;
                    StageInfo.FirstClear = false;

                    for (int i = 0; i < 16; i++)
                    {
                        PassageInfo passageInfo = new PassageInfo();

                        passageInfo.name = child.Attributes.GetNamedItem("PassageName_" + i.ToString()).Value;
                        passageInfo.prevPassage = int.Parse(child.Attributes.GetNamedItem("prevePassage_" + i.ToString()).Value);
                        passageInfo.ClearMap = false;
                        passageInfo.ClearTrg = false;

                        for (int j = 0; j < 3; j++)
                        {
                            int temp;
                            temp = int.Parse(child.Attributes.GetNamedItem("nextPassage_" + i.ToString() + "_" + j.ToString()).Value);
                            if (j == 0)
                                passageInfo.nextPassage.Add(temp);
                            if (j >= 1 && temp != -1)
                                passageInfo.nextPassage.Add(temp);
                        }

                        StageInfo.passageInfos.Add(passageInfo);
                    }
                    ItemList.Add(StageInfo);
                }
            }

        }

        GameManager.instance.StageInfos = ItemList;
    }



    IEnumerator Process(string strName)
    {
        string strPath = string.Empty;

#if (UNITY_EDITOR || UNITY_STANDALONE_WIN) 
        {
            strPath += ("file:///");
            strPath += (Application.streamingAssetsPath + "/" + strName);
        }
#elif UNITY_ANDROID
            strPath = "jar:file://" + Application.dataPath + "!/assets/" + strName;
#endif
        {
            WWW www = new WWW(strPath);

            yield return www;

            //Debug.Log("Read Content :" + www.text);
            Read(www.text);
        }
    }
}


