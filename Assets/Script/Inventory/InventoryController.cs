using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //public AudioSource openAS;
    //public AudioSource closeAS;

    //public AudioClip open;
    //public AudioClip close;

    public GameObject inventory;
    public bool isInven;
    public GameObject closebutton;
    public GameObject openbutton;
    public GameObject Left1, Left2, Left3, Right1, Right2, Right3, Boss, Book, Wall, Beam;
    private void Start()
    {
        //openAS = GetComponent<AudioSource>();
        //closeAS = GetComponent<AudioSource>();
        closebutton.SetActive(false);
        inventory.SetActive(false);

    }
    public void OpenInventory()
    {
        // openAS.clip = open;
        // openAS.Play(); //오디오 재생


        inventory.SetActive(true);
        isInven = true;
        closebutton.SetActive(true);

        openbutton.SetActive(false);
        
    }
    public void CloseInventory()
    {
        //closeAS.clip = close;
        //closeAS.Play(); //오디오 재생

        inventory.SetActive(false);
        isInven = false;
        closebutton.SetActive(false);
        openbutton.SetActive(true);

      
        
    }
}
