using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
public class ButtonManager : MonoBehaviour
{
    public GameObject trashpanel;
    // Start is called before the first frame update
    void Start()
    {
        trashpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeTrashPanel()
    {
        trashpanel.SetActive(false);
    }
}
