using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov2D : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public string horizontalInput = "HorizontalP";
    public string verticalInput = "VerticalP";
    public float speed;
    public float rotationSpeed;

    float move;
    float turn;

    private void Update(){
        turn = Input.GetAxis(horizontalInput);
        move = Input.GetAxis(verticalInput);
    }
    private void FixedUpdate(){
        Vector3 movement = transform.forward * move * speed;
        transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
