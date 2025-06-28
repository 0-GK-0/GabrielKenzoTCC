using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingAtkBetter : MonoBehaviour
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
    public GameObject upBeam;
    public float timeToDespawn;

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
            Vector3 beamPos = new Vector3(rb.position.x, -0.75f, rb.position.z);
            Instantiate(upBeam, beamPos, rb.rotation);
            Destroy(self);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerToHit ) || other.gameObject.CompareTag(otherPlayerAtk) || other.gameObject.CompareTag("Background"))
        {
            Vector3 beamPos = new Vector3(rb.position.x, -0.75f, rb.position.z);
            Quaternion beamRot = Quaternion.Euler(0, 0, 0);
            Instantiate(upBeam, beamPos, beamRot);
            Destroy(self);
        }
    }
}
