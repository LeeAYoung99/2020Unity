using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrashCan : MonoBehaviour
{
    public bool is_can;
    public GameObject item;
    public GameObject trashpanel;
    public Camera left1;
    //public Sprite newitem;
    // Start is called before the first frame update
    void Start()
    {
        //item.SetActive(false);
        is_can = false;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("ClickManager").GetComponent<ClickManager>().left1 == true && is_can == false)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = left1.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "trash")
                    {
                        item.SetActive(true);
                        is_can = true;
                        trashpanel.SetActive(true);
                    }
                }
            }
        }
    }
}
