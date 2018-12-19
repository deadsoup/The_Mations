using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDirector : MonoBehaviour {

    public GameObject AutoMap;
    public GameObject StickMap;
    public GameObject AutoClear;
    public GameObject StickClear;
    public GameObject LoadScene;
    public void LoadCharScene()
    {
        LoadScene.SetActive(true);
    }
   public void Click1()
    {
        LoadScene.SetActive(false);
    }
    public void Click2()
    {
        SceneManager.LoadScene("Pyj_GameScene");
    }
    public void Click3()
    {
        SceneManager.LoadScene("GameScene");
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

            "              " + 000+ "          NoData";
        this.AutoClear.GetComponent<Text>().text = "Clear Tile          " +

            "              " + 000 + "          NoData";
        this.StickClear.GetComponent<Text>().text = "Clear Tile          " +

            "              " + 000 + "          NoData";
    }
}
