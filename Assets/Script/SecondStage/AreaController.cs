﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("CameraManager").GetComponent<CameraManager>().medicine == true)
        {
            this.gameObject.SetActive(false);
        }
        else
            this.gameObject.SetActive(true);
    }
}
