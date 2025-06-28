using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBeam : MonoBehaviour
{
    [Header("Values")]
    public string playerToHit = "Player1";
    public Rigidbody rb;
    public int dmg;
    public string otherPlayerAtk = "AttackP1";
    public float knockback = 10f;
    public float knockbackUp = 20f;
    GameObject self;
    public float timeToDespawn = 1f;

    private void Awake()
    {
        self = this.gameObject;
    }
    private void Update()
    {
        timeToDespawn -= 1f * Time.deltaTime;
        if (timeToDespawn <= 0) Destroy(self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerToHit))
        {
            Health enemy = other.GetComponent<Health>();
            enemy.Dmg(dmg);
            PlayerMovv player = other.GetComponent<PlayerMovv>();
            player.Knockback(knockback, knockbackUp,rb.transform.position);
        }
    }
}
