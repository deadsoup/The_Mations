using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDirector : MonoBehaviour
{
    public static int count;
    public GameObject QuestText;
    public GameObject QuestCh;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            this.QuestText.GetComponent<Text>().text = "전투 승리 1회 달성(" + 0 + " / 1)";
        }
        else if (count == 1)
        {
            this.QuestText.GetComponent<Text>().text = "전투 승리 1회 달성(" + count + " / 1)";
            QuestCh.SetActive(true);
        }
        DontDestroyOnLoad(gameObject);
    }
    
}
