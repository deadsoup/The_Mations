using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour { //게임 시작 후 나오는 게임배경설명에 사용되는 스크립트

    public GameObject Tutorial;
    public GameObject Yes;
    public GameObject Cancle;


    public void SkipButton()
    {
        Tutorial.SetActive(true);
    }
    public void GoTutoPassWay()
    {
        SceneManager.LoadScene("TutoPassWay");
    }
    public void TutorialYes()
    {
        Tutorial.SetActive(false);
        SceneManager.LoadScene("TutoRialScene");
    }
    public void TutorialCancle()
    {
        Tutorial.SetActive(false);
        SceneManager.LoadScene("CharScene");
    }
    
	// Use this for initialization
	void Start ()
    {
        Tutorial = GameObject.Find("Canvas").transform.Find("Tutorial").gameObject;
        Yes = GameObject.Find("Canvas").transform.Find("Tutorial").transform.Find("Yes").gameObject;
        Cancle = GameObject.Find("Canvas").transform.Find("Tutorial").transform.Find("Cancle").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
