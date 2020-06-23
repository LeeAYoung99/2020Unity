using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameGlassDestroy : MonoBehaviour
{

    int MouseClickCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClickCount++;

            if (MouseClickCount >= 3)
            {
                Destroy(gameObject);
                MouseClickCount = 0;
            }
        }


    }
    

}
