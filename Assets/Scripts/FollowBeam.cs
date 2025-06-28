using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBeam : MonoBehaviour
{
    public Transform whatToLook;
    [SerializeField] Transform me;
    [Header("Values")]
    public string playerToHit = "Player1";
    public float speed;
    public Rigidbody rb;
    public string otherPlayerAtk = "AttackP1";
    GameObject self;
    public GameObject upBeam;
    public float timeToDespawn;
    public float timeToFollow = 2f;

    private void Awake()
    {
        self = this.gameObject;
    }
    private void Update()
    {
        if (whatToLook == null) whatToLook = GameObject.FindWithTag(playerToHit).transform;
        rb.position = new Vector3(rb.position.x, -1f, rb.position.z);
        timeToDespawn -= 1f * Time.deltaTime;
        timeToFollow -= 1f * Time.deltaTime;
        if (timeToDespawn >= 0)
        {
            if (timeToFollow > 0)
            {
                Vector3 direction = whatToLook.position - rb.position;
                rb.velocity = direction.normalized * speed;
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
        else
        {
            Vector3 beamPos = new Vector3(rb.position.x, -0.75f, rb.position.z);
            Quaternion beamRot = Quaternion.Euler(0, 0, 0);
            Instantiate(upBeam, beamPos, beamRot);
            Destroy(self);
        }
    }
}
