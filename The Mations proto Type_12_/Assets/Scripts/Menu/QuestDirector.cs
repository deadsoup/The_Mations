using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestDirector : MonoBehaviour
{
    public static int count;
    public GameObject QuestText;
    public GameObject QuestEffect;
    public GameObject Ending;

    // 클리어맵 카운트 계산
    public bool isCheckClear;


    public void EndingGo()
    {
        Ending.SetActive(true);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // QuestDirector.count = 0;
        // QuestDirector.count = 1;
        // QuestDirector.count = 2;
        // QuestDirector.count = 3;
        // QuestDirector.count = 4;
        // QuestDirector.count = 5;
        // QuestDirector.count = 6;
        // QuestDirector.count = 7;
        // QuestDirector.count = 8;
        // QuestDirector.count = 9;
        // QuestDirector.count = 10;
        // QuestDirector.count = 12;
        //QuestDirector.count = 0;

        //if (GameManager.instance.StageInfos[0].FirstClear == true)

        // 클리어 카운트 계산
        QuestDirector.count = 0;
        isCheckClear = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (isCheckClear == false && GameManager.instance.StageInfos.Count != 0)
        {
            for (int i = 0; i < GameManager.instance.StageInfos.Count; i++)
            {
                if (GameManager.instance.StageInfos[i].FirstClear == true)
                {
                    QuestDirector.count += 1;
                }
            }
            isCheckClear = true;
        }

        if (count == 0)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;
        }
        else if (count == 1)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 2)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 3)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 4)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 5)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 6)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 7)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 8)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 9)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 10)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 11)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 12)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 (" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;
            QuestEffect.SetActive(true);
        }
        //DontDestroyOnLoad(gameObject);
    }

}
