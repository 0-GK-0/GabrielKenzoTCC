using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [Header("Values")]
    public float speed1;
    public float jumpForce1;
    public float hpLossPerAtk;
    public int hp1;
    public int dmg1;
    public int range1;

    [Header("References")]
    private Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void Update(){

    }
    void FixedUpdate(){

    }

    void Jump(){

    }

}
