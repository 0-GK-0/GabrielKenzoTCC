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
    public string otherPlayerAtk = "AttackP1";
    public float knockback;
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
        if (other.gameObject.CompareTag(playerToHit))
        {
            Destroy(self);
            Health enemy = other.GetComponent<Health>();
            enemy.Dmg(dmg);
            PlayerMovv player = other.GetComponent<PlayerMovv>();
            player.Knockback(knockback, rb.transform.position);
        }
        else if (other.gameObject.CompareTag("Background") || other.gameObject.CompareTag(otherPlayerAtk))
        {
            Destroy(self);
        }
    }
}