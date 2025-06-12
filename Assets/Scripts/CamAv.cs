using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAv : MonoBehaviour
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10);
    [SerializeField] private float smoothness = 5f;
    private void LateUpdate() {
        if (p1 == null || p2 == null) return;

        // Vector3 p1ToP2 = p2.position - p1.position;
        // Debug.DrawLine(p1.position, p1.position + p1ToP2, Color.red);

        // Vector3 center = p1.position + (p1ToP2 / 2f);
        // transform.LookAt(center);

        Vector3 center = (p1.position + p2.position) / 2f;

        Vector3 distanceOfPlayers = p1.position - p2.position;

        Debug.Log(distanceOfPlayers.magnitude);

        if (distanceOfPlayers.magnitude > 10f)
        {
            offset.x = Vector3.Distance(p1.position, p2.position) / 1.95f;
            offset.y = Vector3.Distance(p1.position, p2.position) / 10f;
        }
        Vector3 destino = center + offset;

        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * smoothness);

        float newXPos = Mathf.Clamp(transform.position.x, 0f, 40f);
        float newYPos = Mathf.Clamp(transform.position.y, 0f, 40f);
        float newZPos = Mathf.Clamp(transform.position.z, 0f, 40f);

        transform.position = new(newXPos, newYPos, newZPos);
        transform.LookAt(center);
    }
}
