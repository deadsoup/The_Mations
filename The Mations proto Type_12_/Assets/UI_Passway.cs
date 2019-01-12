using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Passway : MonoBehaviour
{
    public SaveBattleScene saveBattleScene;

    public Sprite[] UI_charSlot;

    public GameObject[] UI_change;

    public Sprite[] UI_Fullshot;

    public GameObject[] UI_Fullshot_getta;

    public battle Battle;

    public movecontroller Movecontroller;

    public void setting(int num)
    {
        int[] player = new int[3];
        player[0] = saveBattleScene.Player1_ID;
        player[1] = saveBattleScene.Player2_ID;
        player[2] = saveBattleScene.Player3_ID;

        if (saveBattleScene.player[num] == true)
        {
            for (int i = 0; i < 3; i++)
            {
                if (player[num] == i)
                {
                    UI_change[num].GetComponent<Image>().sprite = UI_charSlot[i];
                    if (SceneManager.GetActiveScene().name == "Passway")
                    {
                        UI_Fullshot_getta[num].GetComponent<Image>().sprite = UI_Fullshot[i];
                    }
                }
            }
        }
        else
        {
            UI_change[num].SetActive(false);
        }
    }
    

    void Start()
    {
        setting(0);
        setting(1);
        setting(2);
        Battle.Status1();
        if (SceneManager.GetActiveScene().name == "Passway")
        {
            Movecontroller.ChangeSprite();
        }
    }

    void Update()
    {
        
    }
}
