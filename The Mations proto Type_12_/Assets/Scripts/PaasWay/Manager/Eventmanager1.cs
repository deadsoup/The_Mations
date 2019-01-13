using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eventmanager1 : MonoBehaviour
{
    public List<GameObject> Event = new List<GameObject>();

    SaveBattleScene saveBattleScene;

    public static Eventmanager1 instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (SceneManager.GetActiveScene().name == "Passway")
        {
            saveBattleScene = GameObject.Find("EventSystem").GetComponent<SaveBattleScene>();

        }
    }

    public void EventText(int eventIdx)
    {
        Event[eventIdx].SetActive(true); 
    }

    public void BatteEvent()
    {
        saveBattleScene.saveJson();
        SceneManager.LoadScene("DH_Battle");
    }

    public void HpRecovery(float amount)
    {
        for(int i = 0; i < 3; i++)
        {
            npc.Hp[battle.switching[i]] += (int)((float)npc.MaxHp[battle.switching[i]] * amount);
            if(npc.Hp[battle.switching[i]] > npc.MaxHp[battle.switching[i]])
            {
                npc.Hp[battle.switching[i]] = npc.MaxHp[battle.switching[i]];
            }
        }
    }

    public void MpRecovery(float amount)
    {
        for (int i = 0; i < 3; i++)
        {
            npc.Mp[battle.switching[i]] += (int)((float)npc.MaxMp[battle.switching[i]] * amount);
            if (npc.Mp[battle.switching[i]] > npc.MaxMp[battle.switching[i]])
            {
                npc.Mp[battle.switching[i]] = npc.MaxMp[battle.switching[i]];
            }
        }
    }

    public void AddExp(int amount)
    {
        npc.ArchivePoint[0] += amount;
        if(npc.ArchivePoint[0] >= 500)
        {
            npc.ArchivePoint[0] -= 500;
            npc.SkillPoint += 1;
        }
    }

    public void Trap(float amount)
    {
        for (int i = 0; i < 3; i++)
        {
            npc.Hp[battle.switching[i]] -= (int)((float)npc.MaxHp[battle.switching[i]] * amount);
            if (npc.Hp[battle.switching[i]] <= 0)
            {
                npc.Hp[battle.switching[i]] = 1;
            }
        }
    }
}

