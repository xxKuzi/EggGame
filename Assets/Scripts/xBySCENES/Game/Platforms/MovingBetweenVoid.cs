using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBetweenVoid : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] int numberOfWaypoints = 1;
    [SerializeField] int speed = 3;
    int currentWaypointIndex = 0;


    void Update()
    {
      if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex == numberOfWaypoints)
            {
                currentWaypointIndex = 0;
            }
            
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);

    }
}
