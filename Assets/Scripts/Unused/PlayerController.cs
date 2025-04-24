using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*public string playerPrefix;
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
    }

    void HandleMovement()
    {
        float h = Input.GetAxis(playerPrefix + "_Horizontal");
        float v = Input.GetAxis(playerPrefix + "_Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    void HandleAttack()
    {
        if (Input.GetButtonDown(playerPrefix + "_Attack1"))
            GetComponent<Attack>().ExecuteAttack(AttackType.Light);
        if (Input.GetButtonDown(playerPrefix + "_Attack2"))
            GetComponent<Attack>().ExecuteAttack(AttackType.Medium);
        if (Input.GetButtonDown(playerPrefix + "_Attack3"))
            GetComponent<Attack>().ExecuteAttack(AttackType.Special);
    }*/
}