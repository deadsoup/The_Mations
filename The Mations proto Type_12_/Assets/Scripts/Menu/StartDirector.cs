using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartDirector : MonoBehaviour {

   public static bool count;
    public void LoadStoryScene()

    {/*
        if (!Directory.Exists(Application.persistentDataPath + "/Json"))
        {
        }
        else
        {*/
     //SceneManager.LoadScene("GameScene");
     //}
        SceneManager.LoadScene("StoryScene");
    }
     void Update()
    {
        count = false;
        
    }
}
