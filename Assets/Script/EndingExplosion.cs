using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingExplosion : MonoBehaviour
{
    //public GameObject expEffect;
    //private int hitCount;
    private Rigidbody rb;
   
    public float expRadius = 10.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Explosion"))
        {
            ExpBarrel();
        }
    }
    private void ExpBarrel()
    {
        //Instantiate(expEffect, transform.position, Quaternion.identity);
        rb.mass = 1.0f;
        rb.AddForce(Vector3.up * 1000.0f);

        //IndirectDamage(transform.position);
    }
  

}
