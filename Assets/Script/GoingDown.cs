using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingDown : MonoBehaviour
{
    float speed;
    public GameObject newspaper;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(newspaper.transform.position.y>-507)
        {
            newspaper.transform.Translate(new Vector3(0, -1, 0) * speed);
        }
    }
}
