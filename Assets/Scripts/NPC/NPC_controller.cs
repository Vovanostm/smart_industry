using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_controller : MonoBehaviour
{
    public GameObject path;
    public NavMeshAgent agent;

    public Transform waypoints;

    public int waypointNum = 0;

    void Start()
    {
        path = GameObject.Find("Path");
        waypoints = path.transform;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.destination = waypoints.GetChild(0).position;
    }


    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            waypointNum++;
            if (waypointNum < waypoints.childCount)
            {
                agent.destination = waypoints.GetChild(waypointNum).position;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
