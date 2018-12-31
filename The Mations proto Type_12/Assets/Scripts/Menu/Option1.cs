using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Option1 : MonoBehaviour
{

    
    public GameObject OptionPopup;
    public GameObject Close;
    public GameObject TitleGo;
    public static int Coin;





    public void Click()
    {


        OptionPopup.SetActive(true);
        Close.SetActive(true);

        if (StartDirector.count == true)
        {
            TitleGo.SetActive(true);
            

        }
        if (StartDirector.count == false)
        {


            TitleGo.SetActive(false);

        }


    }
    public void Click2()
    {

        OptionPopup.SetActive(false);

    }

}