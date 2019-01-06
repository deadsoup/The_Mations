using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace ParkYJ.Coroutine
{
    public class Fade : MonoBehaviour
    {
        public float animTime = 2f;
        private Image fadeImage;
        private float start = 0f;
        private float end = 1f;
        private float time = 0f;
        private float start2 = 1f;
        private float end2 = 0f;
        private float time2 = 0f;
        private bool isPlaying = false;
        public GameObject Button;
       

       void Awake()                                                                                                                                                                                                                       
        {
            fadeImage = GetComponent<Image>();
        }
        public void StartFadeAnim()
        {
            if (isPlaying == true)
                 return;
            
            StartCoroutine(PlayFadeout());

        }
     
        IEnumerator PlayFadeout()
        {
            Button.SetActive(false);
            isPlaying = true;

            Color color = fadeImage.color;
            time = 0f;
            color.a = Mathf.Lerp(start, end, time);

            while (color.a < 1f)
            {
                time += Time.deltaTime / animTime;
                color.a = Mathf.Lerp(start, end, time);
                fadeImage.color = color;
                yield return null;

            }
            isPlaying = false;
          

        }
      
    }
}
