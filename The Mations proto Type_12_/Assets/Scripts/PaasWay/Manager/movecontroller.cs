using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movecontroller : MonoBehaviour {
    bool lbutton = false;
    bool rbutton = false;

    // 캐릭터 현재 스프라이트
    public SpriteRenderer spriteRenderer;
    // 넣어줄 스프라이트 목록
    public Sprite[] sprite;

    // 캐릭터 현재 애니메이터
    public Animator animator;
    // 넣어줄 애니메이션 목록
    public RuntimeAnimatorController[] animatorClips;

    // 이동 애니메이션 헤쉬값
    private readonly int hashMove = Animator.StringToHash("IsMove");


    private float moveSpeed = 10.0f;
 
    // Use this for initialization
    void Start () {

        ChangeSprite(CharCount.Charcount);

    }
    public void LButtonDown()
    {
        animator.SetBool(hashMove, true);
        lbutton = true;
    }
    public void RButtonDown()
    {
        animator.SetBool(hashMove, true);
        rbutton = true;
    }
    public void LButtonUp()
    {
        animator.SetBool(hashMove, false);
        lbutton = false;
    }
    public void RButtonUp()
    {
        animator.SetBool(hashMove, false);
        rbutton = false;
    }

    // Update is called once per frame
    void Update () {

        if (lbutton)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if(rbutton)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }

	}

    // 애니메이션 교체 함수
    public void ChangeSprite(int charIdx)
    {
        spriteRenderer.sprite = sprite[charIdx];
        animator.runtimeAnimatorController = animatorClips[charIdx];
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
