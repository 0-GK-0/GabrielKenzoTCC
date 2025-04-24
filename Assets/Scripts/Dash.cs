using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody rb;
    public Transform orientation;
    public Transform player;
    private float currentCooldown = 0;
    public Atks atks;
    public PlayerMov playerMov;

    [Header("Attack3 - Movement")]
    public int dmg3;
    public int hpLoss3;
    public float cooldown3;
    public KeyCode attack3;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }
    private void Update(){
        if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
        else
            if(Input.GetKeyDown(attack3)) GoDash();
    }
    public void GoDash(){
        currentCooldown = cooldown3;
        atks.DamagePercentage(hpLoss3);
        playerMov.speedControl = false;

        playerMov.speedControl = true;
    }
}
