using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfPuzzle : MonoBehaviour
{
    public GameObject med1,med2;
    public GameObject  med1Des, med2Des;
    Vector3  med1InitPos, med2InitPos;
    //Vector3 frame1DesPos, frame2DesPos, med1DesPos, med2DesPos;
    bool med1Correct, med2Correct=false;
    // Start is called before the first frame update
    void Start()
    {
        med1InitPos = med1.transform.position;
        med2InitPos = med2.transform.position;
        
        //med1DesPos = med1Des.transform.position;
        //med2DesPos = med2Des.transform.position;
    }

    public void Dragmed1()
    {
        med1.transform.position = Input.mousePosition;
    }
    public void Dragmed2()
    {
        med2.transform.position = Input.mousePosition;
    }

    public void Dropmed1()
    {
        float dis = Vector3.Distance(med1.transform.position, med1Des.transform.position);
        if (dis < 30)
        {
            med1.transform.position = med1Des.transform.position;
            Debug.Log("Correct");
            med1Correct = true;
        }
        else
        {
            med1.transform.position = med1InitPos;
            Debug.Log("InCorrect");
            med2Correct = true;
        }

    }
    public void Dropmed2()
    {
        float dis = Vector3.Distance(med2.transform.position, med2Des.transform.position);
        if (dis < 30)
        {
            med2.transform.position = med2Des.transform.position;
            Debug.Log("Correct");
        }
        else
        {
            med2.transform.position = med2InitPos;
            Debug.Log("InCorrect");
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (med2Correct && med1Correct)
        {
            Debug.Log("Success");
        }
    }
}
