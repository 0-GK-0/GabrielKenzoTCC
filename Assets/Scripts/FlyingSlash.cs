using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSlash : MonoBehaviour
{
    [Header("Values")]
    public float speed;
    public int dmg;
    Transform self;
    
    private void Start(){
        self = GetComponent<Transform>();
    }
    private void Update(){
        self.position += Vector3.forward * speed * Time.deltaTime;
    }
}
