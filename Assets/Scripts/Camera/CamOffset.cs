using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOffset : MonoBehaviour
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10);
    [SerializeField] private float smoothness = 5f;
    [SerializeField] private Transform centerSpot;
    private void LateUpdate() {
        if (p1 == null || p2 == null) return;

        Vector3 center = (p1.position + p2.position) / 2f;

        Vector3 distanceOfPlayers = p1.position - p2.position;

        Debug.Log(distanceOfPlayers.magnitude);

        if (distanceOfPlayers.magnitude > 10f)
        {
            offset.x = Vector3.Distance(p1.position, p2.position) / 1.95f;
            offset.y = Vector3.Distance(p1.position, p2.position) / 10f;
        }
        Vector3 destino = offset;

        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * smoothness);

        transform.LookAt(centerSpot);
    }
}