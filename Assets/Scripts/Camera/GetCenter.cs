using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCenter : MonoBehaviour
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private float smoothness = 5f;
    private void LateUpdate()
    {
        if (p1 == null || p2 == null) return;

        Vector3 center = (p1.position + p2.position) / 2f;

        Vector3 distanceOfPlayers = p1.position - p2.position;

        Debug.Log(distanceOfPlayers.magnitude);
        Vector3 destino = distanceOfPlayers;

        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * smoothness);

        float newXPos = Mathf.Clamp(transform.position.x, 0f, 40f);
        float newYPos = Mathf.Clamp(transform.position.y, 0f, 40f);
        float newZPos = Mathf.Clamp(transform.position.z, 0f, 40f);

        transform.position = new(newXPos, newYPos, newZPos);

        float pointRot = p1.rotation.y / 2;

        transform.Rotate(0, pointRot, 0);
    }
}
