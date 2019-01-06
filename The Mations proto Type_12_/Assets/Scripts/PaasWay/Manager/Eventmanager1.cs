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

    public void EventText(int eventIdx)
    {
        Event[eventIdx].SetActive(true); 
    }

    public void BatteEvent()
    {
        SceneManager.LoadScene("DH_Battle");
    }
}

