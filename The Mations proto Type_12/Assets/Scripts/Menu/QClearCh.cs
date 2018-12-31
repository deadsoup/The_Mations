using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QClearCh : MonoBehaviour
{

    public int count;
    public int count2;
    public int count3;
    public int count4;
    public GameObject QclearCh;
    public GameObject QuestReward;
    public GameObject ClearButton;
    public GameObject QclearCh2;
    public GameObject QuestReward2;
    public GameObject ClearButton2;
    public GameObject QclearCh3;
    public GameObject QuestReward3;
    public GameObject ClearButton3;
    public GameObject QclearCh4;
    public GameObject QuestReward4;
    public GameObject ClearButton4;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        count2 = 0;
        count3 = 0;
        count4 = 0;
    }
    public void Click()
   {
        if (count == 1)
        {
            QuestReward.SetActive(true);
            
        }
   }
    public void Click2()
    {
        if (count2 == 1)
        {
            QuestReward2.SetActive(true);

        }
    }
    public void Click3()
    {
        if (count3 == 1)
        {
            QuestReward3.SetActive(true);

        }
    }
    public void Click4()
    {
        if (count4 == 1)
        {
            QuestReward4.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 1)
        {
            QclearCh.SetActive(true);
            ClearButton.SetActive(true);
        }
        if (count2 == 1)
        {
            QclearCh2.SetActive(true);
            ClearButton2.SetActive(true);
        }
        if (count3 == 1)
        {
            QclearCh3.SetActive(true);
            ClearButton3.SetActive(true);
        }
        if (count4 == 1)
        {
            QclearCh4.SetActive(true);
            ClearButton4.SetActive(true);
        }
    }
}
