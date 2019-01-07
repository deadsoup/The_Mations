using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class StageManager : MonoBehaviour
{
    public GameObject PrefabButton;

    public GameObject ButtonGroup;

    public List<Button> StageButtons;

    //public GameObject[] StageButton = new GameObject[13];


    public bool Setonce;
    

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
           // SetStageButton();
        }
    }
}
