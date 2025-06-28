using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingAtk : MonoBehaviour
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
    public float timeToDespawn;
    float timeToGrow = 0.5f;
    public float knockback;
    public float knockbackUp;

    private void Awake()
    {
        self = this.gameObject;
    }
    private void Update()
    {
        if (whatToLook == null) whatToLook = GameObject.FindWithTag(playerToHit).transform;
        timeToDespawn -= 1f * Time.deltaTime;
        if (timeToDespawn >= 0)
        {
            me.LookAt(whatToLook);
            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
            if (timeToGrow > 0f)
            {
                me.localScale = new Vector3(me.localScale.x + 7 * Time.deltaTime, me.localScale.y + 7 * Time.deltaTime, me.localScale.z + 7 * Time.deltaTime);
                timeToGrow -= Time.deltaTime;
            }
            else
            {
                if (me.localScale.magnitude > 0.1)
                {
                    me.localScale = new Vector3(me.localScale.x - 2*Time.deltaTime, me.localScale.y - 2*Time.deltaTime, me.localScale.z - 2*Time.deltaTime);
                }
                else Destroy(self);
            }
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
