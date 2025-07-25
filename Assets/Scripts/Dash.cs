using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] private Rigidbody rb;
    public Transform player;
    private float currentCooldown = 0;
    public Atks atks;
    public PlayerMovv playerMov;
    public Health healthh;
    public float dashForce;

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }
        else if (Input.GetKeyDown(atks.attack3) && currentCooldown <= 0)
        {
            GoDash(playerMov.moveDirection);
        }
    }
    public void GoDash(Vector3 dashDirection)
    {
        currentCooldown = atks.cooldown3;
        if(healthh.health > 1)atks.DamagePercentage(atks.hpLoss3);
        if (dashDirection != Vector3.zero)
        {
            rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(transform.forward * dashForce*20, ForceMode.Impulse);
        }
    }
}
