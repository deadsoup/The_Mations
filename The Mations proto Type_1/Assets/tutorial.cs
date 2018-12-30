using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour {

    public GameObject Tutorial;
    public GameObject Yes;
    public GameObject Cancle;


    public void SkipButton()
    {
        Tutorial.SetActive(true);
    }
    public void TutorialYes()
    {
        Tutorial.SetActive(false);
        SceneManager.LoadScene("TutoRialScene");
    }
    public void TutorialCancle()
    {
        Tutorial.SetActive(false);
        SceneManager.LoadScene("CharScene11");
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
