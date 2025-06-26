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
    bool isDead = false;

    float move;
    float turn;
    public bool canInput = true;

    private void Start()
    {
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
        if (isDead) return;
        
        transform.LookAt(otherPlayer);
        //Vector3 movement = transform.forward * move * speed;
        if (canInput)
        {
            moveDirection = orientation.forward * move + orientation.right * turn;
            moveDirection = moveDirection.normalized * speed;
            //transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);
            rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

            //rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        }
        if (healthh.health <= 0)
        {
            Death();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
    public void Death()
    {
        isDead = true;
        transform.position = win.losePos.position;
        otherPlayer.position = win.winPos.position;
        win.Winn(otherPlayerName, otherPlayerWinCam);
        rb.isKinematic = true;
        canInput = false;
        player2Mov.canInput = false;
    }
    public void Knockback(float knockback, Vector3 atkDirection)
    {
        canInput = false;
        rb.velocity = Vector3.zero;
        Vector3 knockbackDirection = rb.transform.position - atkDirection;
        rb.AddForce(knockbackDirection.normalized * knockback, ForceMode.Impulse);
        if(!isDead)StartCoroutine(knockbackCoroutine());
    }

    private IEnumerator knockbackCoroutine()
    {
        yield return new WaitForSeconds(0.20f);
        canInput = true;
    }
}
