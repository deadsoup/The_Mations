using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
  
    public GameObject Character1;
    public GameObject Character6;
    
    public GameObject Character3;
    
  
    public void Start()
    {
       //테스트용 나중에 지워야됨 
       // npc.ArchivePoint[0] = 200;
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
            Character3.SetActive(true);
        }
        

    }
   
}
