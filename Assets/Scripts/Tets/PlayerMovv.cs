using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovv : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public string horizontalInput = "HorizontalP";
    public string verticalInput = "VerticalP";
    public float speed;
    public float rotationSpeed;
    [SerializeField] private Health healthh;
    [SerializeField] private PlayerMovv player2Mov;
    [SerializeField] private Win win;
    public string otherPlayerName;
    public GameObject otherPlayerWinCam;
    public Transform otherPlayer;
    public Transform orientation;
    public Vector3 moveDirection;
    public float jumpForce;
    public float jumpCooldown;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool readyToJump = true;
    bool grounded;
    [Header("KeyBinds")]
    public KeyCode jumpKey;

    float move;
    float turn;
    public bool canInput = true;

    private void Start() {
        canInput = true;
    }
    private void Update()
    {
        turn = Input.GetAxisRaw(horizontalInput);
        move = Input.GetAxisRaw(verticalInput);
        
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void FixedUpdate()
    {
        transform.LookAt(otherPlayer);
        /*Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -40f, 40f);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -9999, 9999);
        currentRotation.z = Mathf.Clamp(currentRotation.z, -40f, 40f);

        transform.rotation = Quaternion.Euler(currentRotation);*/
        
        //Vector3 movement = transform.forward * move * speed;
        if (canInput)
        {
            //transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);
            //rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
            moveDirection = orientation.forward * move + orientation.right * turn;

            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        if (healthh.health <= 0)
            {
                Death();
            }
    }
    private void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump(){
        readyToJump = true;
    }
    public void Death()
    {
        rb.freezeRotation = false;
        rb.AddForce(0, 0, 1, ForceMode.Impulse);
        win.Winn(otherPlayerName, otherPlayerWinCam);
        canInput = false;
        player2Mov.canInput = false;
    }
    public void Knockback(float knockback) {
        
    }
}
