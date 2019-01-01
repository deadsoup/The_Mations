using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject Clear;
    Rigidbody2D rigid2d;
    Animator animator;
    AudioSource audio1;
    float jumpForce = 1.0f;
    float walkForce = 30.8f;
    float maxWalkSpeed = 4.0f;
    //public  AudioClip audio2;
    void OnTriggerEnter2D(Collider2D other)
    {
        Click1();

    }
   
    public void Click1()
    {
        Clear.SetActive(true);

    }
    public void Click2()
    {
        Clear.SetActive(false);

    }
    public void LoadWorldMap()
    {
        SceneManager.LoadScene("SampleScene1");
    }

    // Use this for initialization
    void Start ()
    {
        this.rigid2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.audio1 = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)&& this.rigid2d.velocity.y == 0)
        {
            this.animator.SetTrigger("AtkTrigger");
            this.rigid2d.AddForce(transform.up * jumpForce);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            audio1.Play();
           
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs(this.rigid2d.velocity.x);
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2d.AddForce(transform.right * key * this.walkForce);
        }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1,1 );
        }
        this.animator.speed = speedx / 2.0f;
        if (this.rigid2d.velocity.x == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else { this.animator.speed = 1.0f; }
        if(transform.position.x<-20|| transform.position.x > 20)
        {
            SceneManager.LoadScene("Pyj_GameScene");
        }
        //DontDestroyOnLoad(gameObject);

    }
}
