using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoint : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar opponentCar;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        opponentCar= GetComponent<OpponentCar>();
    }
    private void Start()
    {
        opponentCar.LocateDestination(currentWaypoint.GetPos());
    }
    private void Update()
    {
        if (opponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            opponentCar.LocateDestination(currentWaypoint.GetPos());
        }
    }
}
