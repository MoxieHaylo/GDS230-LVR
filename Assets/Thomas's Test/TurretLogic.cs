using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLogic : MonoBehaviour
{

    public GameObject[] waypoints;
    int myCurrentWaypoint;
    public GameObject myProjectile;
    public bool isMoving;
    public float WaitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        myCurrentWaypoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        

       
    }

    private void FixedUpdate()
    {
        if (isMoving == true)
        {
            MoveToWaypoint();
        }

        

        if(isMoving == false)
        {
            StartCoroutine("Fire", WaitTime);
            shootProjectile();
        }
    }

    void MoveToWaypoint()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[myCurrentWaypoint].transform.position, 0.15f);

        if (Vector3.Distance(this.transform.position, waypoints[myCurrentWaypoint].transform.position) < 0.01f)
        {
            isMoving = false;
            myCurrentWaypoint = Random.Range(0, waypoints.Length);
        }
    }

    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count);
        
        yield return null;
    }
   


    void shootProjectile()
    {
        GameObject newProjectile = Instantiate(myProjectile, this.transform.position, this.transform.rotation);

        isMoving = true;
    }
    
}
