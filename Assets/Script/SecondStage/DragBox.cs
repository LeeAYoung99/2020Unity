using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragBox : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    Vector3 position;
    public Camera ClinicCamera;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnMouseDrag()
    {
        Vector3 currentPos = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Input.mousePosition.z);
        Vector3 objPosition = ClinicCamera.ScreenToWorldPoint(currentPos);
        transform.position = objPosition;
    }*/
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 startPos = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Input.mousePosition.z);
    }
    public void OnDrag(PointerEventData eventData)
    {
        /*Vector3 currentPos = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Input.mousePosition.z);
        Vector3 objPosition = ClinicCamera.ScreenToWorldPoint(currentPos);
        transform.position = objPosition;*/
        this.position = Input.mousePosition;
    }
    IEnumerator MouseDrag()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 mouseDragPosition = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, Input.mousePosition.z);
            Vector3 worldObjPos = ClinicCamera.ScreenToWorldPoint(mouseDragPosition);
            this.transform.position = worldObjPos;
            yield return null;
        }
    }

    
}
