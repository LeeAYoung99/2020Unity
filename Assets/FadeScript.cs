using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float f_time = 1f;
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        time = 0;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / f_time;
            alpha.a = Mathf.Lerp(0,4, time);//시간에따라 흐려짐
            Panel.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1f);
        while (alpha.a >0f)
        {
            time += Time.deltaTime / f_time;
            alpha.a = Mathf.Lerp(4, 0, time);//시간에따라 흐려짐
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null; 
    }
}
