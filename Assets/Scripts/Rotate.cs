using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Values")]
    public float rotationSpeed;
    public float despawnTime = 5f;
    public Transform me;
    GameObject self;

    private void Start()
    {
        self = this.gameObject;
    }
    private void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0) Destroy(self);
        me.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
