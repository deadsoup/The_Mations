using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontroller : MonoBehaviour {
    bool lbutton = false;
    bool rbutton = false;
	// Use this for initialization
	void Start () {
    }
    public void LButtonDown()
    {
        lbutton = true;
    }
    public void RButtonDown()
    {
        rbutton = true;
    }
    public void LButtonUp()
    {
        lbutton = false;
    }
    public void RButtonUp()
    {
        rbutton = false;
    }
    // Update is called once per frame
    void Update () {

        if (lbutton)
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0);
        }
        if(rbutton)
        {
            transform.Translate(3 * Time.deltaTime, 0, 0);

        }
       
	}
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.position = new Vector2(3.4f,-13.77f); //이동 시킬 좌표 값

        minimapmove.c = 2; //미니맵 좌표 변경
        Debug.Log("통로 이동");
    }
    */

}
