using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMG : MonoBehaviour
{
    public AudioClip AttackSE;
    public AudioClip[] Unique_SkillSE;

    public AudioClip[] SkillSE;
    public AudioClip DiceSE;
    public AudioClip ButtonSE;
    public AudioClip DeadSE;

    AudioSource aud;

    public static AudioMG instance;

    void Awake()
    {
        if (AudioMG.instance == null)
            AudioMG.instance = this;
    }

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void playDead()
    {
        aud.PlayOneShot(DeadSE);
    }

    public void playAttack()
    {
        aud.PlayOneShot(AttackSE);
    }

    public void playDice()
    {
        aud.PlayOneShot(DiceSE);
    }

    public void playButton()
    {
        aud.PlayOneShot(ButtonSE);

    }


}
