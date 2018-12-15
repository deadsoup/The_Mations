using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Option : MonoBehaviour {

    public GameObject OptionPopup;
    public GameObject Close;

    // public void LoadOptionsScene()
    // {
    //  SceneManager.LoadScene("OptionScene");
    //  }
    // Use this for initialization

    public void Click()
    {
        OptionPopup. SetActive( true);
        Close.SetActive(true);
    }
    public void Click2()
    {
        OptionPopup.SetActive(false);
        Close.SetActive(false);
    }
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
