using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header("Waypoint Status")]
    public Waypoint previousWaypoint;
    public Waypoint nextWaypoint;

    [Range(0f, 5f)]
    public float waypointWidth = 1f;

    public Vector3 GetPos()
    {
        Vector3 minBound = transform.position + transform.right * waypointWidth / 2f;
        Vector3 maxBoudn = transform.position - transform.right * waypointWidth / 2f;

        return Vector3.Lerp(minBound,maxBoudn,Random.Range(0f,1f));

    }
}
