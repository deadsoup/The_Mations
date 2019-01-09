using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventmanager1 : MonoBehaviour
{
    public List<GameObject> Event = new List<GameObject>();


    public static Eventmanager1 instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void EventText(int eventIdx)
    {
        Event[eventIdx].SetActive(true); 
    }

    public void BatteEvent()
    {
        SceneManager.LoadScene("DH_Battle");
    }

    public void HpRecovery(float amount)
    {
        for(int i = 0; i < 3; i++)
        {
            npc.Hp[i] += (int)((float)npc.MaxHp[i] * amount);
            if(npc.Hp[i] > npc.MaxHp[i])
            {
                npc.Hp[i] = npc.MaxHp[i];
            }
        }
    }

    public void MpRecovery(float amount)
    {
        for (int i = 0; i < 3; i++)
        {
            npc.Mp[i] += (int)((float)npc.MaxMp[i] * amount);
            if (npc.Mp[i] > npc.MaxMp[i])
            {
                npc.Mp[i] = npc.MaxMp[i];
            }
        }
    }

    public void AddExp(int amount)
    {
        npc.ArchivePoint[0] += amount;
        if(npc.ArchivePoint[0] >= 1000)
        {
            npc.ArchivePoint[0] -= 1000;
            npc.SkillPoint += 1;
        }
    }

    public void Trap(float amount)
    {
        for (int i = 0; i < 3; i++)
        {
            npc.Hp[i] -= (int)((float)npc.MaxHp[i] * amount);
            if (npc.Hp[i] <= 0)
            {
                npc.Hp[i] = 1;
            }
        }
    }
}

