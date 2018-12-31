using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveDirector : MonoBehaviour
{

    public GameObject SaveScene;
    public GameObject AutoMap;
    public GameObject StickMap;
    public GameObject AutoClear;
    public GameObject StickClear;
    public GameObject AutoGood;
    public GameObject StickGood;


    public void SaveCharScene()
    {
        if (Option.Coin == 0)
        { 
        SaveScene.SetActive(true);
        }
    }
    public void Click1()
    {
        if (Option.Coin == 0)
        {
            SaveScene.SetActive(false);
        }
    }
    public void Click2()
    {
        if (Option.Coin == 0)
        {
            AutoGood.SetActive(true);
        }
    }
    public void Click3()
    {
        if (Option.Coin == 0)
        {
            StickGood.SetActive(true);
        }
    }
    void Start()
    {
        //this.AutoMap = GameObject.Find("AutoMap");
        //this.StickMap = GameObject.Find("StickMap");
        //this.AutoClear = GameObject.Find("AutoClear");
        //this.StickClear = GameObject.Find("StickClear");
    }
    void Update()
    {
        this.AutoMap.GetComponent<Text>().text = "Map          " +

            "              " + 000 + "          NoData";
        this.StickMap.GetComponent<Text>().text = "Map          " +

            "              " + 000 + "          NoData";
        this.AutoClear.GetComponent<Text>().text = "Clear Tile          " +

            "              " + 000 + "          NoData";
        this.StickClear.GetComponent<Text>().text = "Clear Tile          " +

            "              " + 000 + "          NoData";
        
    }

}
