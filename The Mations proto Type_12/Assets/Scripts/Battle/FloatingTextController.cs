using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    public static GameObject popupText;
    public static GameObject popupText2;
    public static GameObject popupText3;
    public static GameObject popupText4;
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

    public static void Initialize3()
    {

        canvas = GameObject.Find("Canvas");
        if (!popupText3)
        {
            print("Initialize");
            popupText3 = Resources.Load<GameObject>("Battle_Resource/Prefabs/Damage3");

            //Instantiate(popupText, transform.position, transform.rotation);
        }
    }

    public static void Initialize4()
    {

        canvas = GameObject.Find("Canvas");
        if (!popupText4)
        {
            print("Initialize");
            popupText4 = Resources.Load<GameObject>("Battle_Resource/Prefabs/Damage4");

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
        instance.GetComponent<FloatingText>().SetText(text);
    }
    public static void CreateFloatingText3(string text, Transform location)
    {
        print("CreateFloatingText");
        GameObject instance = Instantiate(popupText3);
        instance.transform.SetParent(canvas.transform, false);
        instance.GetComponent<FloatingText>().SetText(text);
    }

    public static void CreateFloatingText4(string text, Transform location)
    {
        print("CreateFloatingText");
        GameObject instance = Instantiate(popupText4);
        instance.transform.SetParent(canvas.transform, false);
        instance.GetComponent<FloatingText>().SetText(text);
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
