using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform whatToLook;
    [SerializeField] Transform me;
    private void Update()
    {
        me.LookAt(whatToLook);
    }
}
