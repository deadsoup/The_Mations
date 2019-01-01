using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Option : MonoBehaviour { // 타이틀화면 옵션창 관련

    public GameObject start;
    public GameObject Load;
    public GameObject OptionPopup;
    public GameObject Close;
    public GameObject TitleGo;
    public static int Coin;


    private void Start()
    {
        OptionPopup = GameObject.Find("Canvas").transform.Find("OptionsPopup").gameObject;
        start = GameObject.Find("Canvas").transform.Find("Start").gameObject;
        Load = GameObject.Find("Canvas").transform.Find("Load").gameObject;
        Close = OptionPopup.transform.Find("Close").gameObject;
        TitleGo = OptionPopup.transform.Find("TitleGo").gameObject;
    }


    public void Click()
    {
        
       
        OptionPopup.SetActive(true);
        Close.SetActive(true);
        
        if (StartDirector.count ==true )
        {
            TitleGo.SetActive(true);
            
        }
        if (StartDirector.count == false)
        {
            

            TitleGo.SetActive(false);
           
        }
        start.SetActive(false);
        Load.SetActive(false);


    }
    public void Click2()
    {
        
        OptionPopup.SetActive(false);
        
        if (StartDirector.count == false)
        {
            start.SetActive(true);
            Load.SetActive(true);
        }
    }
  
}
