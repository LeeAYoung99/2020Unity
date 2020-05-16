﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ScriptText_Opening_2 : MonoBehaviour
{
    private Text St;

    public string currentText;
    string myText;

    public bool textActive; //텍스트가 타자 작동중인지 아닌지에 대한 함수입니다.

    int i;
    int myTime;

    public AudioSource audioSource;
    public AudioClip bgm;



    // Start is called before the first frame update
    void Start()
    {
        myText = "학창시절부터 내세울 게 없었던 나는 대학을 졸업하자마자\n아무 회사에 서류를 무작정 넣고 다녔고";
        currentText = "";
        textActive = true;
        St = GameObject.Find("Script").GetComponent<Text>();

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = bgm; //오디오에 bgm이라는 파일 연결
        audioSource.playOnAwake = false;

        myTime = 0;



    }
    /*
     IEnumerator Sleep(float time)
    {
      
        yield return new WaitForSeconds(time);

    }
         */


    // Update is called once per frame
    void Update()
    {
        myTime++;
        if (Input.GetMouseButtonDown(0))
        {
            if (textActive == true)
            {
                textActive = false;
            }
            else
            {
                //Debug.Log("NextScene");
                SceneManager.LoadScene("Prologue3");
            }

        }

        if (textActive == true)
        {

            if (currentText == myText || i > myText.Length)
            {
                textActive = false;
            }


            //Thread.Sleep(140);
            // StartCoroutine(Sleep(10f));


            if (myTime > 38)
            {
                myTime = 0;
                if (i < myText.Length)
                {
                    currentText += myText[i];
                }

                if (myText[i] != ' ')
                {
                    audioSource.Play(); //오디오 재생
                }

                i++;

            }
                

        }
        else
        {
            currentText = myText;

        }
        St.text = currentText;


    }




}

