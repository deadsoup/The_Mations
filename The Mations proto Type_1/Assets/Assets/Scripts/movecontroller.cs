using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontroller : MonoBehaviour {
    bool lbutton = false;
    bool rbutton = false;
    Rigidbody2D rigid2d;
    Animator animator;
    float walkForce = 30.8f;
    float maxWalkSpeed = 4.0f;
    // Use this for initialization
    void Start ()
    {
        rigid2d = this.GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
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
    void Update ()
    {
        var key = 0;
        if (lbutton)
        {
            key = -1;
        }
        else if(rbutton)
        {
            key = 1;
        }
        float speedx = Mathf.Abs(this.rigid2d.velocity.x);
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2d.AddForce(transform.right * key * this.walkForce);
        }

//        this.animator.speed = speedx / 2.0f;
        if (this.rigid2d.velocity.x == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else { this.animator.speed = 1.0f; }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
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
