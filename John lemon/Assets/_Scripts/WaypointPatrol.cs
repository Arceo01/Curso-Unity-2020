using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private int currentWayPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[currentWayPointIndex].position);

    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWayPointIndex].position);
        }
    }
}
