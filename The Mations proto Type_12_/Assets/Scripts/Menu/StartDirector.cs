using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartDirector : MonoBehaviour {

   public static bool count;
    public void LoadStoryScene()

    {
        //SceneManager.LoadScene("StoryScene");
        if(!Directory.Exists(Application.persistentDataPath + "/Json"))
        {
            SceneManager.LoadScene("StoryScene");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }

    }
     void Update()
    {
        count = false;
        
    }
}
