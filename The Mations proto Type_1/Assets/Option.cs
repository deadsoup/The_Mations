using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Option : MonoBehaviour {

    public GameObject Start;
    public GameObject Load;
    public GameObject OptionPopup;
    public GameObject Close;
    public GameObject TitleGo;
    public static int Coin;





    public void Click()
    {
        Coin = 1;
       
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
        Start.SetActive(false);
        Load.SetActive(false);

    }
    public void Click2()
    {
        Coin = 0;
        OptionPopup.SetActive(false);
        
        if (StartDirector.count == false)
        {
            Start.SetActive(true);
            Load.SetActive(true);
        }
    }
  
}
