using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkill : MonoBehaviour
{
    public int stun_per;
    public int sleep_per;
    public int burn_per;
    public int blood_per;

    battle Battle;

    

    private void Start()
    {
        Battle = GameObject.Find("Battle").transform.GetChild(0).GetComponent<battle>();
    }

    public void enemyAttak()
    {
        if (Battle.player1.activeSelf == true && Battle.player2.activeSelf == false && Battle.player3.activeSelf == false)
        {
            npc.eActiongage -= 10.0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            Battle.edamage = npc.atk[battle.i] + randomDamage;
            if (Battle.edamage <= 0) { Battle.edamage = 0; }

            npc.Hp[battle.c] -= Battle.edamage;
            Battle.Monster.SetTrigger("Atk");

            FloatingTextController.CreateFloatingText2(Battle.edamage.ToString(), transform);

        }

        if (Battle.player1.activeSelf == true && Battle.player2.activeSelf == true && Battle.player3.activeSelf == false)
        {
            int random = Random.Range(battle.switching[0], 2);
            npc.eActiongage -= 10.0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            Battle.edamage = npc.atk[battle.i] + randomDamage;
            if (Battle.edamage <= 0) { Battle.edamage = 0; }

            npc.Hp[random] -= Battle.edamage;
            Battle.Monster.SetTrigger("Atk");

            if (random == 0) { FloatingTextController.CreateFloatingText2(Battle.edamage.ToString(), transform); }
            if (random == 1) { FloatingTextController.CreateFloatingText3(Battle.edamage.ToString(), transform); }

        }

        if (Battle.player1.activeSelf == true && Battle.player2.activeSelf == true && Battle.player3.activeSelf == true)
        {
            int random = Random.Range(battle.switching[0], 3);
            npc.eActiongage -= 10.0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            Battle.edamage = npc.atk[battle.i] + randomDamage;
            if (Battle.edamage <= 0) { Battle.edamage = 0; }

            npc.Hp[random] -= Battle.edamage;
            Battle.Monster.SetTrigger("Atk");
            if (random == 0) { FloatingTextController.CreateFloatingText2(Battle.edamage.ToString(), transform); }
            if (random == 1) { FloatingTextController.CreateFloatingText3(Battle.edamage.ToString(), transform); }
            if (random == 2) { FloatingTextController.CreateFloatingText4(Battle.edamage.ToString(), transform); }
        }

        if (npc.eActiongage <= 0)
        {

            npc.eActiongage = 0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount = 0f;
            npc.eAction = false;
            npc.action = true;
            Debug.Log("턴 완료");
            if (npc.action == true)
            {
                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                npc.actiongage = 10.1f;
                npc.eActiongage = 10f;

                Battle.attackButton.SetActive(true);
                Battle.skipButton.SetActive(true);
                Battle.diceTriger = true;
                Battle.Dice.SetActive(true);

            }
        }
    }


    public void EnemySkill_1() // 블러드
    {
        blood_per = 100;

        if (Battle.player1.activeSelf == true && Battle.player2.activeSelf == false && Battle.player3.activeSelf == false)
        {
            npc.eActiongage -= 10.0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            if (blood_per >= Random.Range(1, 101))
            {
                npc.unitCondition[battle.c].condition_Blood = true;
                npc.unitCondition[battle.c].left_Blood = 2;
            }

            Battle.edamage = npc.atk[battle.i] + randomDamage;
            if (Battle.edamage <= 0) { Battle.edamage = 0; }

            npc.Hp[battle.c] -= Battle.edamage;
            Battle.Monster.SetTrigger("Atk");

            FloatingTextController.CreateFloatingText2(Battle.edamage.ToString(), transform);

        }

        if (Battle.player1.activeSelf == true && Battle.player2.activeSelf == true && Battle.player3.activeSelf == false)
        {
            int random = Random.Range(battle.switching[0], 2);
            npc.eActiongage -= 10.0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            if (blood_per >= Random.Range(1, 101))
            {
                npc.unitCondition[random].condition_Blood = true;
                npc.unitCondition[random].left_Blood = 2;
            }

            Battle.edamage = npc.atk[battle.i] + randomDamage;
            if (Battle.edamage <= 0) { Battle.edamage = 0; }

            npc.Hp[random] -= Battle.edamage;
            Battle.Monster.SetTrigger("Atk");

            if (random == 0) { FloatingTextController.CreateFloatingText2(Battle.edamage.ToString(), transform); }
            if (random == 1) { FloatingTextController.CreateFloatingText3(Battle.edamage.ToString(), transform); }

        }

        if (Battle.player1.activeSelf == true && Battle.player2.activeSelf == true && Battle.player3.activeSelf == true)
        {
            int random = Random.Range(battle.switching[0], 3);
            npc.eActiongage -= 10.0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount -= 0.3f;

            int randomDamage = Random.Range(1, 7);

            if (blood_per >= Random.Range(1, 101))
            {
                npc.unitCondition[random].condition_Blood = true;
                npc.unitCondition[random].left_Blood = 2;
            }

            Battle.edamage = npc.atk[battle.i] + randomDamage;
            if (Battle.edamage <= 0) { Battle.edamage = 0; }

            npc.Hp[random] -= Battle.edamage;
            Battle.Monster.SetTrigger("Atk");
            if (random == 0) { FloatingTextController.CreateFloatingText2(Battle.edamage.ToString(), transform); }
            if (random == 1) { FloatingTextController.CreateFloatingText3(Battle.edamage.ToString(), transform); }
            if (random == 2) { FloatingTextController.CreateFloatingText4(Battle.edamage.ToString(), transform); }
        }

        if (npc.eActiongage <= 0)
        {

            npc.eActiongage = 0f;
            Battle.eActionGage.GetComponent<Image>().fillAmount = 0f;
            npc.eAction = false;
            npc.action = true;
            Debug.Log("턴 완료");
            if (npc.action == true)
            {
                Debug.Log("A = 공격 / S = 스킬 / C = 캐릭터1 / D= 캐릭터2 / Space = 스킵");
                npc.actiongage = 10.1f;
                npc.eActiongage = 10f;

                Battle.attackButton.SetActive(true);
                Battle.skipButton.SetActive(true);
                Battle.diceTriger = true;
                Battle.Dice.SetActive(true);

            }
        }
    }
}
