using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadDirector : MonoBehaviour { // 타이틀화면 게임로드창 관련

    GameObject AutoMap;
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
        SceneManager.LoadScene("CharScene11");
    }
    public void Click3()
    {
        SceneManager.LoadScene("GameScene");
    }
    void Start()
    {
        this.AutoMap = GameObject.Find("Canvas").transform.Find("Load").transform.Find("LoadScene").transform.Find("AutoMap").gameObject;
        this.StickMap = GameObject.Find("Canvas").transform.Find("Load").transform.Find("LoadScene").transform.Find("StickMap").gameObject;
        this.AutoClear = GameObject.Find("Canvas").transform.Find("Load").transform.Find("LoadScene").transform.Find("AutoClear").gameObject;
        this.StickClear = GameObject.Find("Canvas").transform.Find("Load").transform.Find("LoadScene").transform.Find("StickClear").gameObject;
        LoadScene = GameObject.Find("Canvas").transform.Find("Load").transform.Find("LoadScene").gameObject;
    }
    void Update()
    { //\r\n 는 텍스트줄을 다음줄로 가는 것
        this.AutoMap.GetComponent<Text>().text = "Map" +
            "\r\n" + 000 + "          NoData";
        this.AutoMap.GetComponent<Text>().fontSize = 23;



        this.StickMap.GetComponent<Text>().text = "Map" +
            "\r\n" + 000+ "           NoData";
        this.StickMap.GetComponent<Text>().fontSize = 23;


        this.AutoClear.GetComponent<Text>().text = "Clear Tile" +
            "\r\n" + 000 + "          NoData";
        this.AutoClear.GetComponent<Text>().fontSize = 23;

        this.StickClear.GetComponent<Text>().text = "Clear Tile" +
            "\r\n" + 000 + "          NoData";
        this.StickClear.GetComponent<Text>().fontSize = 23;
    }
}
