using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class textcon : MonoBehaviour
{
    Text flashingText;
    // Start is called before the first frame update
    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(BlinkText());
        
    }
    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.5f);
            flashingText.text = "화면을 터치 해주세요";
            yield return new WaitForSeconds(.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
