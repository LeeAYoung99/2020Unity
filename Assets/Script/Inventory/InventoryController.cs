using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip open;
    public AudioClip close;

    public GameObject inventory;
    public GameObject closebutton;
    public GameObject openbutton;
    public GameObject Left1, Left2, Left3, Right1, Right2, Right3, Boss, Book, Wall, Beam;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        closebutton.SetActive(false);
        inventory.SetActive(false);
       
    }
    public void OpenInventory()
    {
        audioSource.clip = open;
        audioSource.Play(); //오디오 재생

        
        inventory.SetActive(true);
        closebutton.SetActive(true);

        openbutton.SetActive(false);
        Left1.SetActive(false);
        Left2.SetActive(false);
        Left3.SetActive(false);
        Right1.SetActive(false);
        Right2.SetActive(false);
        Right3.SetActive(false);
        Boss.SetActive(false);
        Book.SetActive(false);
        Wall.SetActive(false);
        Beam.SetActive(false);
    }
    public void CloseInventory()
    {
        audioSource.clip = close;
        audioSource.Play(); //오디오 재생

        inventory.SetActive(false);
        closebutton.SetActive(false);
        openbutton.SetActive(true);

        openbutton.SetActive(true);
        Left1.SetActive(true);
        Left2.SetActive(true);
        Left3.SetActive(true);
        Right1.SetActive(true);
        Right2.SetActive(true);
        Right3.SetActive(true);
        Boss.SetActive(true);
        Book.SetActive(true);
        Wall.SetActive(true);
        Beam.SetActive(true);
    }
}
