using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutoEvent : MonoBehaviour
{

    void Start()
    {
        TutoDirector.Tuto = 1;
    }
    void Update()
    {
    }
    
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (TutoDirector.Tuto == 1)
        {
            SceneManager.LoadScene("YJ_Battle_Tuto");
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D2(Collider2D collision)
    {
        if (TutoDirector.Tuto == 2)
        {
            SceneManager.LoadScene("GameScene");
            Destroy(gameObject);
        }
    }

}