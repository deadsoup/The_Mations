using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMG : MonoBehaviour
{
    public AudioClip AttackSE; //
    public AudioClip[] Unique_SkillSE; //

    public AudioClip WalkSE; //
    public AudioClip[] SkillSE; //
    public AudioClip DiceSE; //
    public AudioClip ButtonSE; //
    public AudioClip DeadSE;
    public AudioClip VictorySE; //

    AudioSource aud;

    public static AudioMG instance;

    void Awake()
    {
        if (AudioMG.instance == null)
        { AudioMG.instance = this; }

        AttackSE = Resources.Load<AudioClip>("Sound/Battle_SE/Basic_Attack_sound");
        Unique_SkillSE[0] = Resources.Load<AudioClip>("Sound/Battle_SE/Loving_you_sound"); // 여자
        Unique_SkillSE[1] = Resources.Load<AudioClip>("Sound/Battle_SE/Dark_berserker_sound"); // 남자
        Unique_SkillSE[2] = Resources.Load<AudioClip>("Sound/Battle_SE/Hearts_Skill_sound"); // 개 변신
        Unique_SkillSE[3] = Resources.Load<AudioClip>("Sound/Battle_SE/Weidog_Skill_sound"); // 개 변신 공격
        SkillSE[0] = Resources.Load<AudioClip>("Sound/Battle_SE/Pyrokinesis_sound");
        SkillSE[1] = Resources.Load<AudioClip>("Sound/Battle_SE/Rainpos_power_sound");
        SkillSE[2] = Resources.Load<AudioClip>("Sound/Battle_SE/Nightmare_lolubai_sound");
        SkillSE[3] = Resources.Load<AudioClip>("Sound/Battle_SE/Infinite_manaring_sound");
        SkillSE[4] = Resources.Load<AudioClip>("Sound/Battle_SE/Awake_burning_sound");
        SkillSE[5] = Resources.Load<AudioClip>("Sound/Battle_SE/only_one_sound");
        DiceSE = Resources.Load<AudioClip>("Sound/SE/dice");

        WalkSE = Resources.Load<AudioClip>("Sound/SE/Player_Walk");

        ButtonSE= Resources.Load<AudioClip>("Sound/SE/button_click");

        VictorySE = Resources.Load<AudioClip>("Sound/SE/Battle_Victory");
    }

    void Start()
    {
        aud = GetComponent<AudioSource>();
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

    public void playWalkSE()
    {
        aud.PlayOneShot(WalkSE);

    }

    public void playVictorySE()
    {
        aud.PlayOneShot(VictorySE);

    }


    public void play_Skill(int num)
    {
        if (num == 0)
        {
            aud.PlayOneShot(SkillSE[num]);
        }

        if (num == 1)
        {
            aud.PlayOneShot(SkillSE[num]);
        }

        if (num == 2)
        {
            aud.PlayOneShot(SkillSE[num]);
        }

        if (num == 3)
        {
            aud.PlayOneShot(SkillSE[num]);
        }

        if (num == 4)
        {
            aud.PlayOneShot(SkillSE[num]);
        }

        if (num == 5)
        {
            aud.PlayOneShot(SkillSE[num]);
        }
    }

    public void play_Unique_Skill(int num)
    {
        if (num == 0)
        {
            aud.PlayOneShot(Unique_SkillSE[num]);
        }

        if (num == 1)
        {
            aud.PlayOneShot(Unique_SkillSE[num]);
        }

        if (num == 2)
        {
            aud.PlayOneShot(Unique_SkillSE[num]);
        }

        if (num == 3)
        {
            aud.PlayOneShot(Unique_SkillSE[num]);
        }
    }

}
