using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBookshelf : MonoBehaviour
{
    public GameObject bookshelf;
    bool is_click;
    bool is_ing;
    public float a;

    public AudioSource audioSource;
    public AudioClip shelf;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        is_click = false;
        is_ing = false;
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /**/

    }

    public void Move()
    {
        
        if (is_click == false)
        {
            a += 0.00005f;
            bookshelf.transform.Translate(0, 0, a);

            audioSource.Play(); //오디오 재생
            if (a > 0.025)
            {
                //SceneManager.LoadScene("SciFi_Industrial_SampleLayout");
                is_click = true;
                a = 0f;
            }
        }

    }
}
