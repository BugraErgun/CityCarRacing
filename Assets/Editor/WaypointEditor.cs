using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[InitializeOnLoad()]
public class WaypointEditor 
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmos(Waypoint waypoint,GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.blue * .5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, -.5f);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.waypointWidth / 2f), 
            waypoint.transform.position   - (waypoint.transform.right * waypoint.waypointWidth / 2f));

        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;
            Vector3 offSet = waypoint.transform.right * waypoint.waypointWidth / 2f;
            Vector3 offSetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offSet, waypoint.previousWaypoint.transform.position + offSetTo);
        }
        if (waypoint.nextWaypoint != null)
        {
            Gizmos.color = Color.yellow;
            Vector3 offSet = waypoint.transform.right * -waypoint.waypointWidth / 2f;
            Vector3 offSetTo = waypoint.previousWaypoint.transform.right * -waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offSet, waypoint.previousWaypoint.transform.position + offSetTo);
        }
    }
}
