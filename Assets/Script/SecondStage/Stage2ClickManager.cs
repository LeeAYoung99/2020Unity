using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2ClickManager : MonoBehaviour
{
    public Camera medicineCamera;
    public GameObject Item1, Item2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("CameraManager").GetComponent<CameraManager>().medicine == true)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = medicineCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Medicine1")
                    {
                        Destroy(hit.transform.gameObject, 0);
                        Item1.SetActive(true);
                    }
                    if (hit.transform.gameObject.tag == "Medicine2")
                    {
                        Destroy(hit.transform.gameObject, 0);
                        Item2.SetActive(true);
                    }
                }
            }
        }
    }
}