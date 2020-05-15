using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameClickCount : MonoBehaviour
{
    int MouseClickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClickCount++;
        }
        if (MouseClickCount >= 3)
        {
            Destroy(gameObject);
        }
    }
}
