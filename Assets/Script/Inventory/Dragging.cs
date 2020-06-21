using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Dragging : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform itemTr;
    private Transform inventoryTr;
    private Transform itemListTr;
    private CanvasGroup canvasGroup;
    public static GameObject draggingItem = null;
    public static Vector2 defaultposition;

    public Sprite newitem;
    public Sprite newitem2;
    public Image item1;
    public Image item2;
    public bool is_Combine;
    bool Beam_Trigger;
    bool Item1_Trigger;
    bool Item2_Trigger;

    public GameObject beam_light;
    public GameObject b_light;
    //public GameObject Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10;
    // Start is called before the first frame update
    void Start()
    {
        Item1_Trigger = false;
        Item2_Trigger = false;
        itemTr = GetComponent<Transform>();
        inventoryTr = GameObject.Find("Inventory").GetComponent<Transform>();
        itemListTr = GameObject.Find("ItemList").GetComponent<Transform>();
        canvasGroup = GetComponent<CanvasGroup>();
        is_Combine = false; //Item1 조합이 안되어있는 상태
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("BoolManager").GetComponent<BoolManager>().is_Combine == true)//아이템이 조합이 되고
        {
            if (GameObject.Find("ClickManager").GetComponent<ClickManager>().beam == true)//beam Camera활성화 된 상태에서
            {
                if (this.transform.position.x >= 820 && this.transform.position.x <= 1300)
                {
                    if (this.transform.position.y >= 470 && this.transform.position.y <= 840)//빔프로젝터 좌표 범위에 아이템을 가져가면
                    {
                        Beam_Trigger = true;//EndDrag에서 사용할 bool 값 true
                    }
                    else
                        Beam_Trigger = false;
                }
                else
                    Beam_Trigger = false;
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
        if (Item1_Trigger == true)
        {

            Destroy(gameObject, 0);
            GameObject.Find("BoolManager").GetComponent<BoolManager>().is_Combine = true; //이제 Item1이 조합이 된 상태
            item1.sprite = newitem;
        }
        if(Item2_Trigger == true)
        {
            Destroy(gameObject, 0);
            GameObject.Find("BoolManager").GetComponent<Stage2BoolManager>().is_Combine = true;
            item2.sprite = newitem2;
        }
        if (Beam_Trigger == true)
        {
            Destroy(this.gameObject, 0);//빔프로젝터 좌표범위에서 드래그를 멈추고 드롭을 한다면 아이템 삭제.
            Debug.Log("AS");
            beam_light.SetActive(true);
            b_light.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item1")
        {
            Item1_Trigger = true;
        }
        if (other.gameObject.tag == "Item2")
        {
            Item2_Trigger = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item1")
        {
            Item1_Trigger = false;
        }
        if (other.gameObject.tag == "Item2")
        {
            Item2_Trigger = false;
        }
    }
}
