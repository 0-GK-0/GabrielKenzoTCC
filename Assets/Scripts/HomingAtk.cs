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
                me.localScale = new Vector3(me.localScale.x + 4 * Time.deltaTime, me.localScale.y + 4 * Time.deltaTime, me.localScale.z + 4 * Time.deltaTime);
                timeToGrow -= Time.deltaTime;
            }
            else
            {
                if (me.localScale.magnitude > 0.1)
                {
                    me.localScale = new Vector3(me.localScale.x - Time.deltaTime, me.localScale.y - Time.deltaTime, me.localScale.z - Time.deltaTime);
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
        }
        else if (other.gameObject.CompareTag("Background") || other.gameObject.CompareTag(otherPlayerAtk))
        {
            Destroy(self);
        }
    }
}
