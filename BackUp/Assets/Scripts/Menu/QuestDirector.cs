using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDirector : MonoBehaviour
{
    public static int count;
    public GameObject QuestText;
    public GameObject QuestEffect;
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
        // QuestDirector.count = 11;
        QuestDirector.count = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;
        }
        else if (count == 1)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 2)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 3)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 4)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 5)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 6)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 7)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 8)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 9)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 10)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 11)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;

        }
        else if (count == 12)
        {
            this.QuestText.GetComponent<Text>().text = "정화된 지역구 수(" + count + " / 12)";
            this.QuestText.GetComponent<Text>().fontSize = 19;
            QuestEffect.SetActive(true);
        }
        DontDestroyOnLoad(gameObject);
    }

}
