using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackDirector : MonoBehaviour {

    Party party;


    public void LoadBackScene()
    {
        

            SceneManager.LoadScene("MainScene");
    }
    public void SkipScene()
    {
        if (CharCount.Charcount == 0)
        {
            print("1번 캐릭 생성");
            party.playerSelect1(0);
        }
        if (CharCount.Charcount == 1)
        { party.playerSelect1(1); }
        if (CharCount.Charcount == 2)
        { party.playerSelect1(2); }
        SceneManager.LoadScene("CharStoryScene");
    }
    // Use this for initialization
    void Start () {
		party = GameObject.Find("PartySystem").GetComponent<Party>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
