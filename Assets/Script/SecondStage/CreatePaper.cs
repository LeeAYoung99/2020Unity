using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePaper : MonoBehaviour
{
    public GameObject paper;
    public GameObject Panel;
    
    // Start is called before the first frame update
    void Start()
    {
        paper.SetActive(false);
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("BoolManager").GetComponent<Stage2BoolManager>().ClearA == true)
        {
            if(GameObject.Find("BoolManager").GetComponent<Stage2BoolManager>().ClearB == true)
            {
                paper.SetActive(true);
                Panel.SetActive(true);
            }
        }
        if(GameObject.Find("ButtonManager").GetComponent<Stage2ButtonManager>().ClosePanel == true)
        {
            Panel.SetActive(false);
        }
    }
}
