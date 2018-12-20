using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class FloatingText : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;
    public Text damageText;
    public Text damageText2;


    // Start is called before the first frame update
    void OnEnable()
    {
        print("Test2");
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        AnimatorClipInfo[] clipInfo2 = animator.GetCurrentAnimatorClipInfo(0);
        damageText = animator.GetComponent<Text>();
        damageText2 = animator.GetComponent<Text>();
        Debug.Log(clipInfo.Length);
        Destroy(gameObject, clipInfo[0].clip.length);
    }


    public void SetText(string text)
    {
        print("SetTest");
        damageText.text = text;
    }

    public void SetText2(string text)
    {
        print("SetTest");
        damageText2.text = text;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
