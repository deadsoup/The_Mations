using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject PrefabButton;

    public GameObject ButtonGroup;

    public List<Button> StageButtons;

    private bool Setonce;

    // Start is called before the first frame update
    void Start()
    {
        Setonce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Setonce == false)
        {
            SetStageButton();
        }
    }

    private void SetStageButton()
    {
        int count = GameManager.instance.StageInfos.Count;

        for(int i = 0; i < count; i++)
        {
            GameObject tempObj = Instantiate(PrefabButton, ButtonGroup.transform);

            int tempNum = i;

            tempObj.name = "Stage " + tempNum.ToString();
            tempObj.GetComponentInChildren<Text>().text = "Stage " + tempNum.ToString();
            tempObj.GetComponent<Button>().onClick.AddListener(() => GameManager.instance.InStage(tempNum));
            StageButtons.Add(tempObj.GetComponent<Button>());

            if(Setonce == false)
            Setonce = true;
        }
    }
}
