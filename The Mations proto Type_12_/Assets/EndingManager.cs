using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    public List<GameObject> obj = new List<GameObject>();
    Color32 col;
    int num;

    IEnumerator Alpha()
    {
        col = obj[num].GetComponent<Image>().color;
        for (byte i = 0; i < 250; i += 10) //어둡다가 발게
        {
            col.a = i;
            obj[num].GetComponent<Image>().color = col;
            yield return new WaitForSeconds(.1f);
        }
        StartCoroutine(AlphaDown());
    }
    IEnumerator AlphaDown()
    {
        col = obj[num].GetComponent<Image>().color;
        {
            for (byte i = 250; i > 0; i -= 10) // 밝다가 어둡게
            {
                col.a = i;
                obj[num].GetComponent<Image>().color = col;
                yield return new WaitForSeconds(.1f);
            }
            if (num < obj.Count)
            {
                obj[num++].SetActive(false);
                obj[num].SetActive(true);
                StartCoroutine(Alpha());
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
            } 
        }
    }
    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            obj.Add(transform.GetChild(i).gameObject);
        StartCoroutine(Alpha());
    }

    void ChangObj()
    {
        obj[0].SetActive(false);
        obj[1].SetActive(true);
    }
}
