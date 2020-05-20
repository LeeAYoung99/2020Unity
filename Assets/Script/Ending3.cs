using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending3 : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float f_time = 1f;
    float currentTime;

    void Awake()
    {
        Panel.gameObject.SetActive(true);
        currentTime = 0f;

        time = 0;
    }

    void Update()
    {
        if(currentTime<=4f)
        {
            currentTime += Time.deltaTime;
        }
        
        if(currentTime>4f)
        {
            Fade();
        }
        
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += (Time.deltaTime / f_time)/100;
            
            alpha.a = Mathf.Lerp(0, 4, time);//시간에따라 흐려짐
            Panel.color = alpha;
            yield return null;
        }
        //time = 0;
        yield return new WaitForSeconds(1f);

        /*
         while (alpha.a > 0f)
        {
            time += Time.deltaTime / f_time;
            alpha.a = Mathf.Lerp(4, 0, time);//시간에따라 흐려짐
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
         */




        if (alpha.a > 0f) Debug.Log("NextScene");

        yield return null;
    }
}
