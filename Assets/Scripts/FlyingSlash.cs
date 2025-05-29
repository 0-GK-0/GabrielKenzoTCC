using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSlash : MonoBehaviour
{
    [Header("Values")]
    public string playerToHit = "Player1";
    public float speed;
    public Rigidbody rb;
    public int dmg;
    GameObject self;
    
    private void Awake(){
        self = this.gameObject;
    }
    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(playerToHit)){
            Destroy(self);
            Health enemy = other.GetComponent<Health>();
            enemy.Dmg(dmg);
        }
        else if(other.gameObject.CompareTag("Background")){
            Destroy(self);
        }
    }
}