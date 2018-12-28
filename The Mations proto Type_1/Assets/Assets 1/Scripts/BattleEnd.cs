using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEnd : MonoBehaviour
{

    public void Click()
    {
        SceneManager.LoadScene("bin+yong");
    }
    public void Click1()
    {
       
        SceneManager.LoadScene("TutoRialMapScene");
        TutoDirector.Tuto = 2;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
