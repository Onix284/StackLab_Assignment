using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currrentWayPointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currrentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currrentWayPointIndex++;
            if(currrentWayPointIndex >= waypoints.Length)
            {
                currrentWayPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currrentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
