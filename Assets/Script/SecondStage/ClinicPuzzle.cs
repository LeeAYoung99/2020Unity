using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClinicPuzzle : MonoBehaviour
{
    public Camera ClinicCam;
    public GameObject A, AA, B;
    public GameObject ItemA, ItemB,ItemBA,ItemAB;
    public bool isA, isB;
    // Start is called before the first frame update
    void Start()
    {
        ItemBA.SetActive(false);
        ItemAB.SetActive(false);
        isA = false;
        isB = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("CameraManager").GetComponent<CameraManager>().clinic == true)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = ClinicCam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "ClinicA")
                    {
                        Destroy(A, 0);
                        Destroy(AA, 0);
                        ItemA.SetActive(true);
                        isA = true;
                    }
                    if (hit.transform.gameObject.tag == "ClinicB")
                    {
                        Destroy(B, 0);
                        ItemB.SetActive(true);
                        isB = true;
                    }
                }
                
            }
            
        }
    }
}
