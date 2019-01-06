using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartDirector : MonoBehaviour {

   public static bool count;
    public void LoadStoryScene()
    {
            SceneManager.LoadScene("StoryScene");
        
    }
     void Update()
    {
        count = false;
        
    }
}
