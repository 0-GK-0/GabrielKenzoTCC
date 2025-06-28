using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public Transform whatToLook;
    [SerializeField] Transform me;
    [Header("Values")]
    public string playerToHit = "Player1";
    public float speed;
    public Rigidbody rb;
    public int dmg;
    public string otherPlayerAtk = "AttackP1";
    GameObject self;
    public float timeToLaunch;
    public float timeToDespawn;
    float timeToGrow = 0.5f;
    public float knockback;
    public float knockbackUp;

    private void Awake()
    {
        self = this.gameObject;
        timeToLaunch -= 9f;
        timeToDespawn = timeToLaunch + 3f;
    }
    private void Update()
    {
        if (whatToLook == null) whatToLook = GameObject.FindWithTag(playerToHit).transform;
        timeToLaunch -= 1f * Time.deltaTime;
        if (timeToLaunch >= 0)
        {
            me.LookAt(whatToLook);
        }
        else
        {
            rb.velocity = transform.forward * speed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerToHit))
        {
            Destroy(self);
            Health enemy = other.GetComponent<Health>();
            enemy.Dmg(dmg);
            PlayerMovv player = other.GetComponent<PlayerMovv>();
            player.Knockback(knockback, knockbackUp, rb.transform.position);
        }
        else if (other.gameObject.CompareTag("Background") || other.gameObject.CompareTag(otherPlayerAtk))
        {
            Destroy(self);
        }
    }
}
