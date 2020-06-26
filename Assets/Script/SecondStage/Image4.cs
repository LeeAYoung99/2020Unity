using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Image4 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform itemTr;
    private Transform inventoryTr;
    private Transform itemListTr;
    private CanvasGroup canvasGroup;
    public static GameObject draggingItem = null;
    public static Vector2 defaultposition;
    //public GameObject ItemB;

    public bool is_Combine;
  

    bool ItemA_Trigger;
    //public GameObject Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10;
    // Start is called before the first frame update
    void Start()
    {

        itemTr = GetComponent<Transform>();
        inventoryTr = GameObject.Find("Inventory").GetComponent<Transform>();
        itemListTr = GameObject.Find("ItemList").GetComponent<Transform>();
        canvasGroup = GetComponent<CanvasGroup>();
        is_Combine = false; //Item1 조합이 안되어있는 상태
        ItemA_Trigger = false;

    }

    // Update is called once per frame
    void Update()
    {

        
        if (GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().isA == true)
        {

            if (GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().isB == true)
            {

                

                if (GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().ItemA.transform.position.x >= 770 &&
                    GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().ItemA.transform.position.x <= 930)
                {
                    
                    if (GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().ItemA.transform.position.y >= 900 &&
                    GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().ItemA.transform.position.y <= 1080)
                    {
                        ItemA_Trigger = true;
                        
                    }
                    else
                        ItemA_Trigger = false;
                }
                else
                    ItemA_Trigger = false;
            }
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inventoryTr);
        draggingItem = this.gameObject;
        canvasGroup.blocksRaycasts = false;
        defaultposition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemTr.position = Input.mousePosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingItem = null;

        canvasGroup.blocksRaycasts = true;
        if (itemTr.parent == inventoryTr)
        {
            itemTr.SetParent(itemListTr.transform);
        }
        else
        {
            this.transform.position = defaultposition;
        }

        if (ItemA_Trigger == true)
        {
            Destroy(gameObject, 0);
            GameObject.Find("Clinicpuzzle").GetComponent<ClinicPuzzle>().ItemAB.SetActive(true);
            GameObject.Find("BoolManager").GetComponent<Stage2BoolManager>().ClearA = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }
}
