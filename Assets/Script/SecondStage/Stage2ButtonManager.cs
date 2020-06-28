using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2ButtonManager : MonoBehaviour
{
    public GameObject ClinicPanel;
    public bool ClosePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseClinicPanel()
    {
        ClosePanel = true;
        ClinicPanel.SetActive(false);
        Debug.Log("ASDF");
    }
}
