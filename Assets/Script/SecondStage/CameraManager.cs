using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera MainCamera, LiquidCamera, MedicineCamera, Main2Camera, ClinicRoomCamera, RadioactivityCamera, MedicineChestCamera;

    public bool main, liquid, medicine, main2, clinic, radio, chest;

    // Start is called before the first frame update
    void Start()
    {
        main = true;
        liquid = false;
        medicine = false;
        main2 = false;
        clinic = false;
        radio = false;
        chest = false;

        LiquidCamera.gameObject.SetActive(false);
        MedicineCamera.gameObject.SetActive(false);
        Main2Camera.gameObject.SetActive(false);
        ClinicRoomCamera.gameObject.SetActive(false);
        RadioactivityCamera.gameObject.SetActive(false);
        MedicineChestCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (main == true)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Liquid")
                    {
                        LiquidCamera.gameObject.SetActive(true);

                        MainCamera.gameObject.SetActive(false);
                        MedicineCamera.gameObject.SetActive(false);
                        Main2Camera.gameObject.SetActive(false);
                        ClinicRoomCamera.gameObject.SetActive(false);
                        RadioactivityCamera.gameObject.SetActive(false);
                        MedicineChestCamera.gameObject.SetActive(false);

                        main = false;
                        liquid = true;
                        
                    }
                    
                    if (hit.transform.gameObject.tag == "Main2")
                    {
                        Main2Camera.gameObject.SetActive(true);

                        MainCamera.gameObject.SetActive(false);
                        LiquidCamera.gameObject.SetActive(false);
                        MedicineCamera.gameObject.SetActive(false);
                        ClinicRoomCamera.gameObject.SetActive(false);
                        RadioactivityCamera.gameObject.SetActive(false);
                        MedicineChestCamera.gameObject.SetActive(false);

                        main2 = true;
                        main = false;
                    }
                    
                    
                }

            }
            if(main2 == true)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = Main2Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Clinic")
                    {
                        ClinicRoomCamera.gameObject.SetActive(true);

                        MainCamera.gameObject.SetActive(false);
                        LiquidCamera.gameObject.SetActive(false);
                        MedicineCamera.gameObject.SetActive(false);
                        Main2Camera.gameObject.SetActive(false);
                        RadioactivityCamera.gameObject.SetActive(false);
                        MedicineChestCamera.gameObject.SetActive(false);

                        clinic = true;
                        main2 = false;
                        main = false;
                    }
                    if (hit.transform.gameObject.tag == "RadioActivity")
                    {
                        RadioactivityCamera.gameObject.SetActive(true);

                        MainCamera.gameObject.SetActive(false);
                        LiquidCamera.gameObject.SetActive(false);
                        MedicineCamera.gameObject.SetActive(false);
                        Main2Camera.gameObject.SetActive(false);
                        ClinicRoomCamera.gameObject.SetActive(false);
                        MedicineChestCamera.gameObject.SetActive(false);

                        radio = true;
                        main2 = false;
                        main = false;
                    }
                    
                }
            }
            if (liquid == true)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = LiquidCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "Medicine")
                    {
                        MedicineCamera.gameObject.SetActive(true);

                        MainCamera.gameObject.SetActive(false);
                        LiquidCamera.gameObject.SetActive(false);
                        Main2Camera.gameObject.SetActive(false);
                        ClinicRoomCamera.gameObject.SetActive(false);
                        RadioactivityCamera.gameObject.SetActive(false);
                        MedicineChestCamera.gameObject.SetActive(false);

                        main = false;
                        liquid = false;
                        medicine = true;
                    }
                }
            }
            if(radio == true)
            {
                RaycastHit hit = new RaycastHit();

                Ray ray = RadioactivityCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    if (hit.transform.gameObject.tag == "MedicineChest")
                    {
                        MedicineChestCamera.gameObject.SetActive(true);

                        MainCamera.gameObject.SetActive(false);
                        LiquidCamera.gameObject.SetActive(false);
                        MedicineCamera.gameObject.SetActive(false);
                        Main2Camera.gameObject.SetActive(false);
                        ClinicRoomCamera.gameObject.SetActive(false);
                        RadioactivityCamera.gameObject.SetActive(false);

                        chest = true;
                        radio = false;
                        main2 = false;
                        main = false;
                    }
                }
            }
        }
    }
}
