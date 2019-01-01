using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    public static GameObject popupText;
    public static GameObject popupText2;
    private static GameObject canvas;


    public static void Initialize()
    {
        
        canvas = GameObject.Find("Canvas");
        if (!popupText)
        {
            print("Initialize");
            popupText = Resources.Load<GameObject>("Battle_Resource/Prefabs/Damage");

            //Instantiate(popupText, transform.position, transform.rotation);
        }
    }

    public static void Initialize2()
    {

        canvas = GameObject.Find("Canvas");
        if (!popupText2)
        {
            print("Initialize");
            popupText2 = Resources.Load<GameObject>("Battle_Resource/Prefabs/Damage2");

            //Instantiate(popupText, transform.position, transform.rotation);
        }
    }






    public static void CreateFloatingText(string text, Transform location)
    {
        print("CreateFloatingText");
        GameObject instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        instance.GetComponent<FloatingText>().SetText(text);
    }

    public static void CreateFloatingText2(string text, Transform location)
    {
        print("CreateFloatingText");
        GameObject instance = Instantiate(popupText2);
        instance.transform.SetParent(canvas.transform, false);
        instance.GetComponent<FloatingText>().SetText2(text);
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
