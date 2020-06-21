using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackManager : MonoBehaviour
{
    public Camera MainCamera, LiquidCamera, MedicineCamera, Main2Camera, ClinicRoomCamera, RadioactivityCamera, MedicineChestCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickBack()
    {
        if (GameObject.Find("CameraManager").GetComponent<CameraManager>().liquid == true ||
            GameObject.Find("CameraManager").GetComponent<CameraManager>().main2 == true)
        {
            MainCamera.gameObject.SetActive(true);

            LiquidCamera.gameObject.SetActive(false);
            MedicineCamera.gameObject.SetActive(false);
            Main2Camera.gameObject.SetActive(false);
            ClinicRoomCamera.gameObject.SetActive(false);
            RadioactivityCamera.gameObject.SetActive(false);
            MedicineChestCamera.gameObject.SetActive(false);

            GameObject.Find("CameraManager").GetComponent<CameraManager>().main = true;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().liquid = false;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().main2 = false;
        }
        else if (GameObject.Find("CameraManager").GetComponent<CameraManager>().medicine == true)
        {
            LiquidCamera.gameObject.SetActive(true);

            MainCamera.gameObject.SetActive(false);
            MedicineCamera.gameObject.SetActive(false);
            Main2Camera.gameObject.SetActive(false);
            ClinicRoomCamera.gameObject.SetActive(false);
            RadioactivityCamera.gameObject.SetActive(false);
            MedicineChestCamera.gameObject.SetActive(false);

            GameObject.Find("CameraManager").GetComponent<CameraManager>().liquid = true;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().medicine = false;
        }
        else if (GameObject.Find("CameraManager").GetComponent<CameraManager>().clinic == true ||
            GameObject.Find("CameraManager").GetComponent<CameraManager>().radio == true)
        {
            Debug.Log("AAAAAA");
            Main2Camera.gameObject.SetActive(true);

            LiquidCamera.gameObject.SetActive(false);
            MedicineCamera.gameObject.SetActive(false);
            MainCamera.gameObject.SetActive(false);
            ClinicRoomCamera.gameObject.SetActive(false);
            RadioactivityCamera.gameObject.SetActive(false);
            MedicineChestCamera.gameObject.SetActive(false);

            GameObject.Find("CameraManager").GetComponent<CameraManager>().main2 = true;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().clinic = false;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().radio = false;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().chest = false;
        }
        else if(GameObject.Find("CameraManager").GetComponent<CameraManager>().chest == true)
        {
            Debug.Log("BBBBB");
            RadioactivityCamera.gameObject.SetActive(true);

            LiquidCamera.gameObject.SetActive(false);
            MedicineCamera.gameObject.SetActive(false);
            MainCamera.gameObject.SetActive(false);
            ClinicRoomCamera.gameObject.SetActive(false);
            Main2Camera.gameObject.SetActive(false);
            MedicineChestCamera.gameObject.SetActive(false);

            GameObject.Find("CameraManager").GetComponent<CameraManager>().chest = false;
            GameObject.Find("CameraManager").GetComponent<CameraManager>().radio = true;
        }
    }
}
