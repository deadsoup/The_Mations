using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStory : MonoBehaviour
{
    public GameObject Char1Story;
    public GameObject Char2Story;
    public GameObject Char3Story;
    public GameObject Char4Story;
    public GameObject Char5Story;
    public GameObject Char6Story;




    private void Update()
    {
        if(CharUiDirector.Character == 1)
        {
            Char1Story.SetActive(true);
        }
        if (CharUiDirector.Character == 2)
        {
            Char2Story.SetActive(true);
        }
        if (CharUiDirector.Character == 3)
        {
            Char3Story.SetActive(true);
        }
        if (CharUiDirector.Character == 4)
        {
            Char4Story.SetActive(true);
        }
        if (CharUiDirector.Character == 5)
        {
            Char5Story.SetActive(true);
        }
        if (CharUiDirector.Character == 6)
        {
            Char6Story.SetActive(true);
        }


        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
