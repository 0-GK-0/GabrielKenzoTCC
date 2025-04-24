using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSlash : MonoBehaviour
{
    [Header("Values")]
    public float speed;
    public Rigidbody rb;
    public int dmg;
    GameObject self;
    
    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Background")){
            Destroy(self);
        }
    }
}