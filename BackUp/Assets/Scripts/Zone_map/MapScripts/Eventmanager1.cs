using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventmanager1 : MonoBehaviour
{
    public List<GameObject> Event = new List<GameObject>();


    public static Eventmanager1 instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        print(TutoDirector.Tuto);
    }

    public void EventText(int eventIdx)
    {
        Event[eventIdx].SetActive(true);

        
    }
    public void BatteEvent()
    {
        if (TutoDirector.Tuto == 1)
        {
            SceneManager.LoadScene("DH_Battle");
        }
       
        else if  (TutoDirector.Tuto < 1)
        {
            SceneManager.LoadScene("DH_Battle");
        }
    }
}
