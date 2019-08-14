using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{

    public GameObject[] waypoints;
    int myCurrentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        myCurrentWaypoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[myCurrentWaypoint].transform.position, 1f);

        if (Vector3.Distance(this.transform.position, waypoints[myCurrentWaypoint].transform.position)<0.01f)
        {
            myCurrentWaypoint = Random.Range(0, waypoints.Length);
        }
    }
}
