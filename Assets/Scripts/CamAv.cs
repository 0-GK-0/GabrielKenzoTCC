using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAv : MonoBehaviour
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10);
    [SerializeField] private float smoothness = 5f;

    private void LateUpdate(){
        if (p1 == null || p2 == null) return;

        Vector3 center = (p1.position + p2.position) / 2f;
        

        offset.x = Vector3.Distance(p1.position, p2.position);
        Vector3 destino = center + offset;

        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * smoothness);
        transform.LookAt(center);
    }
}
