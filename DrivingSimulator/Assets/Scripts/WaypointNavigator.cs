using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    CarNavigationController controller;
    public WayPoint currentWaypoint;

    private void Awake()
    {
        controller = GetComponent<CarNavigationController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.reachedDestination)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}
