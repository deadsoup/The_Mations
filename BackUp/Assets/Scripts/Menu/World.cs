using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    public GameObject WayTile;
    public GameObject Character1;
    public GameObject Character6;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    public GameObject Character5;

    public void ClickWorld()
    {
        SceneManager.LoadScene("bin+yong");
    }
    private void Start()
    {
        StartDirector.count = true;
        //battle.reItems = 1;

        //Reward.reward1 = Random.Range(1, 6);
        //Reward.reward2 = Random.Range(1, 6);
        //Reward.reward3 = Random.Range(1, 6);
    }
    private void Update()
    {
        if (CharUiDirector.Character == 2)
        {
            Character1.SetActive(true);
        }
        if (CharUiDirector.Character == 1)
        {
            Character6.SetActive(true);
        }
        if (CharUiDirector.Character == 3)
        {
            Character2.SetActive(true);
        }
        if (CharUiDirector.Character == 4)
        {
            Character3.SetActive(true);
        }
        if (CharUiDirector.Character == 5)
        {
            Character4.SetActive(true);
        }
        if (CharUiDirector.Character == 6)
        {
            Character5.SetActive(true);
        }

    }
   
}
