using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackDirector : MonoBehaviour {

    public void LoadBackScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void SkipScene()
    {
        SceneManager.LoadScene("CharStoryScene");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
